using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp2.Data.Models;

namespace WinFormsApp2
{
    public class AddIncidentForm : Form
    {
        public Incident? CreatedIncident { get; private set; }

        private TextBox txtName = new TextBox() { Location = new Point(120, 20), Width = 200 };
        private TextBox txtDesc = new TextBox() { Location = new Point(120, 60), Width = 200, Multiline = true, Height = 60 };
        private ComboBox cboUrgency = new ComboBox() { Location = new Point(120, 140), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
        private Button btnSave = new Button() { Text = "Запиши", Location = new Point(120, 180), Width = 90 };
        private Button btnCancel = new Button() { Text = "Отказ", Location = new Point(230, 180), Width = 90 };

        public AddIncidentForm()
        {
            Text = "Нов инцидент";
            Size = new Size(360, 260);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            Controls.Add(new Label() { Text = "Име:", Location = new Point(20, 20) });
            Controls.Add(txtName);
            Controls.Add(new Label() { Text = "Описание:", Location = new Point(20, 60) });
            Controls.Add(txtDesc);
            Controls.Add(new Label() { Text = "Спешност:", Location = new Point(20, 140) });
            Controls.Add(cboUrgency);

            cboUrgency.Items.AddRange(new string[] { "Критичен", "Нормален", "Нисък приоритет" });
            cboUrgency.SelectedIndex = 1;

            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("Моля, попълнете всички полета.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CreatedIncident = new Incident
            {
                Name = txtName.Text,
                Description = txtDesc.Text,
                DateCreated = DateOnly.FromDateTime(DateTime.Now),
                // Мапваме: Критичен (1), Нормален (2), Нисък (3)
                Type = cboUrgency.SelectedIndex + 1
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}