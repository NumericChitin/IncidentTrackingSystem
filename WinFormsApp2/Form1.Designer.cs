namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvIncidents = new DataGridView();
            dgvTechnicians = new DataGridView();
            cboDepartments = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonAddIncident = new Button();
            buttonAssignTechtoIncident = new Button();
            buttonMarkAsResolved = new Button();
            chebOnlyActive = new CheckBox();
            buttonExportFile = new Button();
            buttonImportFile = new Button();
            buttonLoadDatabase = new Button();
            chebFreeTechnicians = new CheckBox();
            folderBrowserDialog = new FolderBrowserDialog();
            textBoxFilterTechByName = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            chebCritical = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvIncidents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTechnicians).BeginInit();
            SuspendLayout();
            // 
            // dgvIncidents
            // 
            dgvIncidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIncidents.Location = new Point(14, 56);
            dgvIncidents.Margin = new Padding(3, 4, 3, 4);
            dgvIncidents.Name = "dgvIncidents";
            dgvIncidents.RowHeadersWidth = 51;
            dgvIncidents.Size = new Size(514, 400);
            dgvIncidents.TabIndex = 0;
            // 
            // dgvTechnicians
            // 
            dgvTechnicians.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTechnicians.Location = new Point(558, 148);
            dgvTechnicians.Margin = new Padding(3, 4, 3, 4);
            dgvTechnicians.Name = "dgvTechnicians";
            dgvTechnicians.RowHeadersWidth = 51;
            dgvTechnicians.Size = new Size(480, 308);
            dgvTechnicians.TabIndex = 1;
            // 
            // cboDepartments
            // 
            cboDepartments.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartments.Font = new Font("Segoe UI", 14F);
            cboDepartments.FormattingEnabled = true;
            cboDepartments.Location = new Point(558, 56);
            cboDepartments.Margin = new Padding(3, 4, 3, 4);
            cboDepartments.Name = "cboDepartments";
            cboDepartments.Size = new Size(479, 39);
            cboDepartments.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(163, 37);
            label1.TabIndex = 3;
            label1.Text = "Инциденти:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(558, 12);
            label2.Name = "label2";
            label2.Size = new Size(97, 37);
            label2.TabIndex = 4;
            label2.Text = "Отдел:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(558, 104);
            label3.Name = "label3";
            label3.Size = new Size(127, 37);
            label3.TabIndex = 5;
            label3.Text = "Техници:";
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ActiveBorder;
            label4.Location = new Point(543, 31);
            label4.Name = "label4";
            label4.Size = new Size(1, 600);
            label4.TabIndex = 6;
            label4.Text = "label4";
            // 
            // buttonAddIncident
            // 
            buttonAddIncident.Font = new Font("Segoe UI", 14F);
            buttonAddIncident.Location = new Point(14, 464);
            buttonAddIncident.Margin = new Padding(3, 4, 3, 4);
            buttonAddIncident.Name = "buttonAddIncident";
            buttonAddIncident.Size = new Size(169, 79);
            buttonAddIncident.TabIndex = 7;
            buttonAddIncident.Text = "Регистрирай инцидент";
            buttonAddIncident.UseVisualStyleBackColor = true;
            buttonAddIncident.Click += buttonAddIncident_Click;
            // 
            // buttonAssignTechtoIncident
            // 
            buttonAssignTechtoIncident.Font = new Font("Segoe UI", 14F);
            buttonAssignTechtoIncident.Location = new Point(187, 464);
            buttonAssignTechtoIncident.Margin = new Padding(3, 4, 3, 4);
            buttonAssignTechtoIncident.Name = "buttonAssignTechtoIncident";
            buttonAssignTechtoIncident.Size = new Size(169, 79);
            buttonAssignTechtoIncident.TabIndex = 8;
            buttonAssignTechtoIncident.Text = "Задай за решаване";
            buttonAssignTechtoIncident.UseVisualStyleBackColor = true;
            buttonAssignTechtoIncident.Click += buttonAssignTechtoIncident_Click;
            // 
            // buttonMarkAsResolved
            // 
            buttonMarkAsResolved.Font = new Font("Segoe UI", 14F);
            buttonMarkAsResolved.Location = new Point(359, 464);
            buttonMarkAsResolved.Margin = new Padding(3, 4, 3, 4);
            buttonMarkAsResolved.Name = "buttonMarkAsResolved";
            buttonMarkAsResolved.Size = new Size(169, 79);
            buttonMarkAsResolved.TabIndex = 9;
            buttonMarkAsResolved.Text = "Означи като решен";
            buttonMarkAsResolved.UseVisualStyleBackColor = true;
            buttonMarkAsResolved.Click += buttonMarkAsResolved_Click;
            // 
            // chebOnlyActive
            // 
            chebOnlyActive.AutoSize = true;
            chebOnlyActive.Font = new Font("Segoe UI", 14F);
            chebOnlyActive.Location = new Point(354, 15);
            chebOnlyActive.Margin = new Padding(3, 4, 3, 4);
            chebOnlyActive.Name = "chebOnlyActive";
            chebOnlyActive.Size = new Size(190, 36);
            chebOnlyActive.TabIndex = 10;
            chebOnlyActive.Text = "Само активни";
            chebOnlyActive.UseVisualStyleBackColor = true;
            // 
            // buttonExportFile
            // 
            buttonExportFile.Font = new Font("Segoe UI", 14F);
            buttonExportFile.Location = new Point(14, 551);
            buttonExportFile.Margin = new Padding(3, 4, 3, 4);
            buttonExportFile.Name = "buttonExportFile";
            buttonExportFile.Size = new Size(169, 79);
            buttonExportFile.TabIndex = 11;
            buttonExportFile.Text = "Експорт във файл";
            buttonExportFile.UseVisualStyleBackColor = true;
            buttonExportFile.Click += buttonExportFile_Click;
            // 
            // buttonImportFile
            // 
            buttonImportFile.Font = new Font("Segoe UI", 14F);
            buttonImportFile.Location = new Point(187, 551);
            buttonImportFile.Margin = new Padding(3, 4, 3, 4);
            buttonImportFile.Name = "buttonImportFile";
            buttonImportFile.Size = new Size(169, 79);
            buttonImportFile.TabIndex = 12;
            buttonImportFile.Text = "Импорт от файл";
            buttonImportFile.UseVisualStyleBackColor = true;
            buttonImportFile.Click += buttonImportFile_Click;
            // 
            // buttonLoadDatabase
            // 
            buttonLoadDatabase.Font = new Font("Segoe UI", 14F);
            buttonLoadDatabase.Location = new Point(359, 551);
            buttonLoadDatabase.Margin = new Padding(3, 4, 3, 4);
            buttonLoadDatabase.Name = "buttonLoadDatabase";
            buttonLoadDatabase.Size = new Size(169, 79);
            buttonLoadDatabase.TabIndex = 13;
            buttonLoadDatabase.Text = "Зареди от база данни";
            buttonLoadDatabase.UseVisualStyleBackColor = true;
            buttonLoadDatabase.Click += buttonLoadDatabase_Click;
            // 
            // chebFreeTechnicians
            // 
            chebFreeTechnicians.AutoSize = true;
            chebFreeTechnicians.Font = new Font("Segoe UI", 14F);
            chebFreeTechnicians.Location = new Point(848, 108);
            chebFreeTechnicians.Margin = new Padding(3, 4, 3, 4);
            chebFreeTechnicians.Name = "chebFreeTechnicians";
            chebFreeTechnicians.Size = new Size(208, 36);
            chebFreeTechnicians.TabIndex = 14;
            chebFreeTechnicians.Text = "Само свободни";
            chebFreeTechnicians.UseVisualStyleBackColor = true;
            // 
            // textBoxFilterTechByName
            // 
            textBoxFilterTechByName.Font = new Font("Segoe UI", 14F);
            textBoxFilterTechByName.Location = new Point(809, 464);
            textBoxFilterTechByName.Margin = new Padding(3, 4, 3, 4);
            textBoxFilterTechByName.Name = "textBoxFilterTechByName";
            textBoxFilterTechByName.ReadOnly = true;
            textBoxFilterTechByName.Size = new Size(228, 39);
            textBoxFilterTechByName.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(559, 472);
            label5.Name = "label5";
            label5.Size = new Size(207, 28);
            label5.TabIndex = 16;
            label5.Text = "Търси техник по име:";
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(559, 510);
            label6.Name = "label6";
            label6.Size = new Size(183, 60);
            label6.TabIndex = 17;
            label6.Text = "Най-ползотворен техник днес:";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(559, 570);
            label7.Name = "label7";
            label7.Size = new Size(183, 60);
            label7.TabIndex = 18;
            label7.Text = "Най-безполезен техник днес:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.Location = new Point(748, 528);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(289, 39);
            textBox1.TabIndex = 19;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 14F);
            textBox2.Location = new Point(748, 588);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(289, 39);
            textBox2.TabIndex = 20;
            // 
            // chebCritical
            // 
            chebCritical.AutoSize = true;
            chebCritical.Font = new Font("Segoe UI", 14F);
            chebCritical.Location = new Point(204, 15);
            chebCritical.Margin = new Padding(3, 4, 3, 4);
            chebCritical.Name = "chebCritical";
            chebCritical.Size = new Size(144, 36);
            chebCritical.TabIndex = 21;
            chebCritical.Text = "Критични";
            chebCritical.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 657);
            Controls.Add(chebCritical);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBoxFilterTechByName);
            Controls.Add(chebFreeTechnicians);
            Controls.Add(buttonLoadDatabase);
            Controls.Add(buttonImportFile);
            Controls.Add(buttonExportFile);
            Controls.Add(chebOnlyActive);
            Controls.Add(buttonMarkAsResolved);
            Controls.Add(buttonAssignTechtoIncident);
            Controls.Add(buttonAddIncident);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboDepartments);
            Controls.Add(dgvTechnicians);
            Controls.Add(dgvIncidents);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Система за управление на инциденти 1.0";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvIncidents).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTechnicians).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvIncidents;
        private DataGridView dgvTechnicians;
        private ComboBox cboDepartments;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonAddIncident;
        private Button buttonAssignTechtoIncident;
        private Button buttonMarkAsResolved;
        private CheckBox chebOnlyActive;
        private Button buttonExportFile;
        private Button buttonImportFile;
        private Button buttonLoadDatabase;
        private CheckBox chebFreeTechnicians;
        private FolderBrowserDialog folderBrowserDialog;
        private TextBox textBoxFilterTechByName;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox1;
        private TextBox textBox2;
        private CheckBox chebCritical;
    }
}
