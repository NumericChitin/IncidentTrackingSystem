using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using WinFormsApp2.Data.Models;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private readonly IncidentManager _incidentManager;
        private readonly DatabaseService _dbService;
        private readonly FileLogger _fileLogger;

        private List<Incident> _allIncidents = new();
        private List<Technician> _allTechnicians = new();
        private List<Department> _departments = new();

        // Флаг, който ни казва дали в момента разглеждаме локален файл или базата
        private bool _isDataFromBackupFile = false;

        public Form1()
        {
            InitializeComponent();

            _incidentManager = new IncidentManager();
            _dbService = new DatabaseService();
            _fileLogger = new FileLogger();

            // Абониране за събития
            _incidentManager.IncidentCreated += _fileLogger.LogEvent;
            _incidentManager.IncidentAssigned += _fileLogger.LogEvent;
            _incidentManager.IncidentResolved += _fileLogger.LogEvent;
            _incidentManager.CriticalIncidentDetected += (s, e) =>
            {
                _fileLogger.LogEvent(s, e);
                MessageBox.Show(e.Message, "Критичен инцидент!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // Настройки на дизайна на таблиците
            ConfigureGridDesigns();

            textBoxFilterTechByName.ReadOnly = false;

            // Закачане на филтрите
            chebOnlyActive.CheckedChanged += (s, e) => RefreshGrids();
            chebFreeTechnicians.CheckedChanged += (s, e) => RefreshGrids();
            cboDepartments.SelectedIndexChanged += (s, e) => RefreshGrids();
            textBoxFilterTechByName.TextChanged += (s, e) => RefreshGrids();
            chebCritical.CheckedChanged += (s, e) => RefreshGrids();
        }

        private void ConfigureGridDesigns()
        {
            // Режим на селекция - целия ред при клик върху произволна клетка
            dgvIncidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTechnicians.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvIncidents.MultiSelect = false;
            dgvTechnicians.MultiSelect = false;

            // Запълване на пространството при техниците
            dgvTechnicians.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
        }

        // Бутонът вече действа като "Опресни от базата"
        private void buttonLoadDatabase_Click(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            MessageBox.Show("Данните от базата бяха опреснени успешно!", "Синхронизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                _allIncidents = _dbService.GetAllIncidents();
                _allTechnicians = _dbService.GetAllTechnicians();
                _departments = _dbService.GetDepartments();
                _isDataFromBackupFile = false; // Връщаме се в режим "База данни"

                cboDepartments.Items.Clear();
                cboDepartments.Items.Add("Всички отдели");
                cboDepartments.Items.AddRange(_departments.Select(d => d.Name).ToArray());
                cboDepartments.SelectedIndex = 0;

                RefreshGrids();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при връзка с базата: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrids()
        {
            // 1. Филтриране на Инциденти
            var filteredIncidents = _allIncidents.AsEnumerable();

            if (chebOnlyActive.Checked)
            {
                filteredIncidents = filteredIncidents.Where(i => i.DateResolved == null);
            }

            if (chebCritical.Checked)
            {
                filteredIncidents = filteredIncidents.Where(i => i.Type == 1); // 1 = Критичен
            }

            // Закачане към таблицата
            dgvIncidents.DataSource = filteredIncidents.Select(i => new {
                ID = i.Id,
                Тема = i.Name,
                Приоритет = ((IncidentPriority)i.Type).ToString().Replace("_", " "),
                Създаден = i.DateCreated,
                Решен = i.DateResolved,
                Описание = i.Description
            }).ToList();

            if (dgvIncidents.Columns["ID"] != null)
            {
                dgvIncidents.Columns["ID"].Width = 45;
            }

            // ДИНАМИЧНО ОЦВЕТЯВАНЕ НА РЕДОВЕТЕ В ТАБЛИЦАТА (ОБНОВЕНО)
            foreach (DataGridViewRow row in dgvIncidents.Rows)
            {
                if (row.Cells["ID"].Value is int incidentId)
                {
                    var incident = _allIncidents.FirstOrDefault(i => i.Id == incidentId);
                    if (incident != null)
                    {
                        // Условие 1: Инцидентът е РАЗРЕШЕН -> Зелен цвят (с най-високо предимство)
                        if (incident.DateResolved != null)
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                            row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.ForestGreen;
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        }
                        // Условие 2: Инцидентът е КРИТИЧЕН и активен -> Червен цвят
                        else if (incident.Type == 1)
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                            row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Crimson;
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        }
                        // Условие 3: Инцидентът е ЗАДАДЕН на техник и активен -> Жълт цвят
                        else if (_incidentManager.ActiveAssignments.ContainsKey(incident.Id))
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                            row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gold;
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        }
                        // Условие 4: Инцидентът е с НИСЪК ПРИОРИТЕТ и активен -> Син цвят
                        else if (incident.Type == 3)
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                            row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        }
                        // Условие 5: Стандартен (Нормален приоритет, активен и незададен) -> Бял цвят
                        else
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            row.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                        }
                    }
                }
            }

            // 2. Филтриране и визуализация на Техници
            var filteredTechs = _allTechnicians.AsEnumerable();

            if (chebFreeTechnicians.Checked)
            {
                filteredTechs = filteredTechs.Where(t => !_incidentManager.ActiveAssignments.ContainsValue(t.Id));
            }

            if (cboDepartments.SelectedIndex > 0)
            {
                var selectedDept = _departments[cboDepartments.SelectedIndex - 1];
                filteredTechs = filteredTechs.Where(t => t.DepartmentTechnicians.Any(dt => dt.DepartmentId == selectedDept.Id));
            }

            if (!string.IsNullOrWhiteSpace(textBoxFilterTechByName.Text))
            {
                filteredTechs = filteredTechs.Where(t => t.Name.Contains(textBoxFilterTechByName.Text, StringComparison.OrdinalIgnoreCase));
            }

            dgvTechnicians.DataSource = filteredTechs.Select(t => new {
                ID = t.Id,
                Име = t.Name,
                Статус = _incidentManager.ActiveAssignments.ContainsValue(t.Id) ? "Зает 🛠️" : "Свободен 🟢"
            }).ToList();

            if (dgvTechnicians.Columns["ID"] != null) dgvTechnicians.Columns["ID"].Width = 45;

            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            if (_incidentManager.ResolvedStats.Count == 0)
            {
                textBox1.Text = "Няма данни";
                textBox2.Text = "Няма данни";
                return;
            }

            var topTechId = _incidentManager.ResolvedStats.OrderByDescending(x => x.Value).First().Key;
            var bottomTechId = _incidentManager.ResolvedStats.OrderBy(x => x.Value).First().Key;

            textBox1.Text = _allTechnicians.FirstOrDefault(t => t.Id == topTechId)?.Name ?? "Няма данни";
            textBox2.Text = _allTechnicians.FirstOrDefault(t => t.Id == bottomTechId)?.Name ?? "Няма данни";
        }

        private void buttonAddIncident_Click(object sender, EventArgs e)
        {
            if (_isDataFromBackupFile)
            {
                MessageBox.Show("В момента сте в режим на преглед на файл. За да добавяте инциденти, натиснете бутона 'Зареди от база данни'.", "Забранено действие");
                return;
            }

            using var dialog = new AddIncidentForm();
            if (dialog.ShowDialog() == DialogResult.OK && dialog.CreatedIncident != null)
            {
                try
                {
                    _dbService.AddIncident(dialog.CreatedIncident);
                    _allIncidents.Add(dialog.CreatedIncident);
                    _incidentManager.CreateIncident(dialog.CreatedIncident);
                    RefreshGrids();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Грешка при запис: {ex.Message}", "Грешка");
                }
            }
        }

        // КОРИГИРАН: Използва CurrentRow вместо SelectedRows
        private void buttonAssignTechtoIncident_Click(object sender, EventArgs e)
        {
            if (dgvIncidents.CurrentRow == null || dgvTechnicians.CurrentRow == null)
            {
                MessageBox.Show("Моля, изберете ред от таблицата с инциденти и ред от таблицата с техници.", "Внимание");
                return;
            }

            int incidentId = (int)dgvIncidents.CurrentRow.Cells["ID"].Value;
            int techId = (int)dgvTechnicians.CurrentRow.Cells["ID"].Value;

            var incident = _allIncidents.First(i => i.Id == incidentId);
            var tech = _allTechnicians.First(t => t.Id == techId);

            if (incident.DateResolved != null)
            {
                MessageBox.Show("Избраният инцидент вече е затворен и решен.", "Внимание");
                return;
            }

            try
            {
                _incidentManager.AssignTechnician(incident, tech);
                RefreshGrids();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // КОРИГИРАН: Използва CurrentRow
        private void buttonMarkAsResolved_Click(object sender, EventArgs e)
        {
            if (dgvIncidents.CurrentRow == null) return;

            int incidentId = (int)dgvIncidents.CurrentRow.Cells["ID"].Value;
            var incident = _allIncidents.First(i => i.Id == incidentId);

            if (incident.DateResolved != null) return;

            try
            {
                _incidentManager.ResolveIncident(incident);

                // Ако сме в режим на база данни - записваме промяната трайно
                if (!_isDataFromBackupFile)
                {
                    _dbService.UpdateIncident(incident);
                }

                RefreshGrids();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка: {ex.Message}", "Грешка");
            }
        }

        private void buttonExportFile_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog() { Filter = "JSON Files (*.json)|*.json", DefaultExt = "json" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var dataToExport = _allIncidents.Select(i => new { i.Id, i.Name, i.Type, i.DateCreated, i.DateResolved, i.Description });
                string jsonString = JsonSerializer.Serialize(dataToExport, options);
                File.WriteAllText(sfd.FileName, jsonString);
                MessageBox.Show("Експортът е успешен!");
            }
        }

        // КОРИГИРАН: Вече не пренаписва базата данни автоматично!
        private void buttonImportFile_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog() { Filter = "JSON Files (*.json)|*.json" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string jsonString = File.ReadAllText(ofd.FileName);
                    var imported = JsonSerializer.Deserialize<List<Incident>>(jsonString);
                    if (imported != null)
                    {
                        _allIncidents = imported; // Заменяме списъка в паметта с този от файла
                        _isDataFromBackupFile = true; // Отбелязваме, че сме в "Режим файл"

                        RefreshGrids();
                        Text = "Система за управление [РЕЖИМ ПРЕГЛЕД НА ФАЙЛ]";
                        MessageBox.Show("Архивният файл е зареден в паметта за преглед. Базата данни НЕ е променяна.", "Импорт");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Грешка при импорт: {ex.Message}", "Грешка");
                }
            }
        }

        public enum IncidentPriority
        {
            Критичен = 1,
            Нормален = 2,
            Нисък_Приоритет = 3
        }
    }
}