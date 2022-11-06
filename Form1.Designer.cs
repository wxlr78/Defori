namespace WinFormsShingles
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.VerifiablePathTitleLabel = new System.Windows.Forms.Label();
            this.СomparablePathTitleLabel = new System.Windows.Forms.Label();
            this.VerifiablePathLabel = new System.Windows.Forms.Label();
            this.СomparablePathLabel = new System.Windows.Forms.Label();
            this.SelectVerifiablePathButton = new System.Windows.Forms.Button();
            this.SelectComparablePathButton = new System.Windows.Forms.Button();
            this.FileExtensionTitleLabel = new System.Windows.Forms.Label();
            this.CheckType = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.VerifiableFilesList = new System.Windows.Forms.ListBox();
            this.VerifiableFilesTitleLabel = new System.Windows.Forms.Label();
            this.СomparableFilesList = new System.Windows.Forms.ListBox();
            this.СomparableFilesTitleLabel = new System.Windows.Forms.Label();
            this.FileExtensionDocxCheck = new System.Windows.Forms.CheckBox();
            this.FileExtensionDocCheck = new System.Windows.Forms.CheckBox();
            this.FileExtensionOdtCheck = new System.Windows.Forms.CheckBox();
            this.FileExtensionTxtCheck = new System.Windows.Forms.CheckBox();
            this.QuickCheck = new System.Windows.Forms.RadioButton();
            this.BalancedCheck = new System.Windows.Forms.RadioButton();
            this.AccurateCheck = new System.Windows.Forms.RadioButton();
            this.ResultDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ResultDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // VerifiablePathTitleLabel
            // 
            this.VerifiablePathTitleLabel.AutoSize = true;
            this.VerifiablePathTitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VerifiablePathTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.VerifiablePathTitleLabel.Name = "VerifiablePathTitleLabel";
            this.VerifiablePathTitleLabel.Size = new System.Drawing.Size(134, 19);
            this.VerifiablePathTitleLabel.TabIndex = 0;
            this.VerifiablePathTitleLabel.Text = "Проверяемый путь:";
            // 
            // СomparablePathTitleLabel
            // 
            this.СomparablePathTitleLabel.AutoSize = true;
            this.СomparablePathTitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.СomparablePathTitleLabel.Location = new System.Drawing.Point(12, 40);
            this.СomparablePathTitleLabel.Name = "СomparablePathTitleLabel";
            this.СomparablePathTitleLabel.Size = new System.Drawing.Size(140, 19);
            this.СomparablePathTitleLabel.TabIndex = 1;
            this.СomparablePathTitleLabel.Text = "Сравниваемый путь:";
            // 
            // VerifiablePathLabel
            // 
            this.VerifiablePathLabel.AutoSize = true;
            this.VerifiablePathLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VerifiablePathLabel.Location = new System.Drawing.Point(158, 9);
            this.VerifiablePathLabel.Name = "VerifiablePathLabel";
            this.VerifiablePathLabel.Size = new System.Drawing.Size(78, 19);
            this.VerifiablePathLabel.TabIndex = 2;
            this.VerifiablePathLabel.Text = "Не выбран";
            // 
            // СomparablePathLabel
            // 
            this.СomparablePathLabel.AutoSize = true;
            this.СomparablePathLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.СomparablePathLabel.Location = new System.Drawing.Point(158, 40);
            this.СomparablePathLabel.Name = "СomparablePathLabel";
            this.СomparablePathLabel.Size = new System.Drawing.Size(78, 19);
            this.СomparablePathLabel.TabIndex = 3;
            this.СomparablePathLabel.Text = "Не выбран";
            // 
            // SelectVerifiablePathButton
            // 
            this.SelectVerifiablePathButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectVerifiablePathButton.Location = new System.Drawing.Point(447, 5);
            this.SelectVerifiablePathButton.Name = "SelectVerifiablePathButton";
            this.SelectVerifiablePathButton.Size = new System.Drawing.Size(75, 25);
            this.SelectVerifiablePathButton.TabIndex = 4;
            this.SelectVerifiablePathButton.Text = "Выбрать";
            this.SelectVerifiablePathButton.UseVisualStyleBackColor = true;
            this.SelectVerifiablePathButton.Click += new System.EventHandler(this.SelectVerifiablePathButton_Click);
            // 
            // SelectComparablePathButton
            // 
            this.SelectComparablePathButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectComparablePathButton.Location = new System.Drawing.Point(447, 36);
            this.SelectComparablePathButton.Name = "SelectComparablePathButton";
            this.SelectComparablePathButton.Size = new System.Drawing.Size(75, 25);
            this.SelectComparablePathButton.TabIndex = 5;
            this.SelectComparablePathButton.Text = "Выбрать";
            this.SelectComparablePathButton.UseVisualStyleBackColor = true;
            this.SelectComparablePathButton.Click += new System.EventHandler(this.SelectComparablePathButton_Click);
            // 
            // FileExtensionTitleLabel
            // 
            this.FileExtensionTitleLabel.AutoSize = true;
            this.FileExtensionTitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FileExtensionTitleLabel.Location = new System.Drawing.Point(12, 69);
            this.FileExtensionTitleLabel.Name = "FileExtensionTitleLabel";
            this.FileExtensionTitleLabel.Size = new System.Drawing.Size(141, 19);
            this.FileExtensionTitleLabel.TabIndex = 6;
            this.FileExtensionTitleLabel.Text = "Расширения файлов:";
            // 
            // CheckType
            // 
            this.CheckType.AutoSize = true;
            this.CheckType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckType.Location = new System.Drawing.Point(12, 97);
            this.CheckType.Name = "CheckType";
            this.CheckType.Size = new System.Drawing.Size(101, 19);
            this.CheckType.TabIndex = 11;
            this.CheckType.Text = "Вид проверки:";
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Start.Location = new System.Drawing.Point(447, 93);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 25);
            this.Start.TabIndex = 12;
            this.Start.Text = "Начать";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // VerifiableFilesList
            // 
            this.VerifiableFilesList.FormattingEnabled = true;
            this.VerifiableFilesList.ItemHeight = 15;
            this.VerifiableFilesList.Location = new System.Drawing.Point(12, 155);
            this.VerifiableFilesList.Name = "VerifiableFilesList";
            this.VerifiableFilesList.Size = new System.Drawing.Size(510, 244);
            this.VerifiableFilesList.TabIndex = 16;
            // 
            // VerifiableFilesTitleLabel
            // 
            this.VerifiableFilesTitleLabel.AutoSize = true;
            this.VerifiableFilesTitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VerifiableFilesTitleLabel.Location = new System.Drawing.Point(12, 133);
            this.VerifiableFilesTitleLabel.Name = "VerifiableFilesTitleLabel";
            this.VerifiableFilesTitleLabel.Size = new System.Drawing.Size(147, 19);
            this.VerifiableFilesTitleLabel.TabIndex = 17;
            this.VerifiableFilesTitleLabel.Text = "Проверяемые файлы:";
            // 
            // СomparableFilesList
            // 
            this.СomparableFilesList.FormattingEnabled = true;
            this.СomparableFilesList.ItemHeight = 15;
            this.СomparableFilesList.Location = new System.Drawing.Point(12, 425);
            this.СomparableFilesList.Name = "СomparableFilesList";
            this.СomparableFilesList.Size = new System.Drawing.Size(510, 244);
            this.СomparableFilesList.TabIndex = 18;
            // 
            // СomparableFilesTitleLabel
            // 
            this.СomparableFilesTitleLabel.AutoSize = true;
            this.СomparableFilesTitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.СomparableFilesTitleLabel.Location = new System.Drawing.Point(12, 403);
            this.СomparableFilesTitleLabel.Name = "СomparableFilesTitleLabel";
            this.СomparableFilesTitleLabel.Size = new System.Drawing.Size(153, 19);
            this.СomparableFilesTitleLabel.TabIndex = 19;
            this.СomparableFilesTitleLabel.Text = "Сравниваемые файлы:";
            // 
            // FileExtensionDocxCheck
            // 
            this.FileExtensionDocxCheck.AutoSize = true;
            this.FileExtensionDocxCheck.Location = new System.Drawing.Point(163, 70);
            this.FileExtensionDocxCheck.Name = "FileExtensionDocxCheck";
            this.FileExtensionDocxCheck.Size = new System.Drawing.Size(58, 19);
            this.FileExtensionDocxCheck.TabIndex = 21;
            this.FileExtensionDocxCheck.Text = "DOCX";
            this.FileExtensionDocxCheck.UseVisualStyleBackColor = true;
            this.FileExtensionDocxCheck.CheckedChanged += new System.EventHandler(this.FileExtensionDocxCheck_CheckedChanged);
            // 
            // FileExtensionDocCheck
            // 
            this.FileExtensionDocCheck.AutoSize = true;
            this.FileExtensionDocCheck.Location = new System.Drawing.Point(227, 70);
            this.FileExtensionDocCheck.Name = "FileExtensionDocCheck";
            this.FileExtensionDocCheck.Size = new System.Drawing.Size(51, 19);
            this.FileExtensionDocCheck.TabIndex = 22;
            this.FileExtensionDocCheck.Text = "DOC";
            this.FileExtensionDocCheck.UseVisualStyleBackColor = true;
            this.FileExtensionDocCheck.CheckedChanged += new System.EventHandler(this.FileExtensionDocCheck_CheckedChanged);
            // 
            // FileExtensionOdtCheck
            // 
            this.FileExtensionOdtCheck.AutoSize = true;
            this.FileExtensionOdtCheck.Location = new System.Drawing.Point(284, 70);
            this.FileExtensionOdtCheck.Name = "FileExtensionOdtCheck";
            this.FileExtensionOdtCheck.Size = new System.Drawing.Size(48, 19);
            this.FileExtensionOdtCheck.TabIndex = 23;
            this.FileExtensionOdtCheck.Text = "ODT";
            this.FileExtensionOdtCheck.UseVisualStyleBackColor = true;
            this.FileExtensionOdtCheck.CheckedChanged += new System.EventHandler(this.FileExtensionOdtCheck_CheckedChanged);
            // 
            // FileExtensionTxtCheck
            // 
            this.FileExtensionTxtCheck.AutoSize = true;
            this.FileExtensionTxtCheck.Location = new System.Drawing.Point(338, 70);
            this.FileExtensionTxtCheck.Name = "FileExtensionTxtCheck";
            this.FileExtensionTxtCheck.Size = new System.Drawing.Size(45, 19);
            this.FileExtensionTxtCheck.TabIndex = 24;
            this.FileExtensionTxtCheck.Text = "TXT";
            this.FileExtensionTxtCheck.UseVisualStyleBackColor = true;
            this.FileExtensionTxtCheck.CheckedChanged += new System.EventHandler(this.FileExtensionTxtCheck_CheckedChanged);
            // 
            // QuickCheck
            // 
            this.QuickCheck.AutoSize = true;
            this.QuickCheck.Location = new System.Drawing.Point(163, 97);
            this.QuickCheck.Name = "QuickCheck";
            this.QuickCheck.Size = new System.Drawing.Size(71, 19);
            this.QuickCheck.TabIndex = 25;
            this.QuickCheck.TabStop = true;
            this.QuickCheck.Text = "Быстрая";
            this.QuickCheck.UseVisualStyleBackColor = true;
            this.QuickCheck.CheckedChanged += new System.EventHandler(this.QuickCheck_CheckedChanged);
            // 
            // BalancedCheck
            // 
            this.BalancedCheck.AutoSize = true;
            this.BalancedCheck.Location = new System.Drawing.Point(240, 97);
            this.BalancedCheck.Name = "BalancedCheck";
            this.BalancedCheck.Size = new System.Drawing.Size(131, 19);
            this.BalancedCheck.TabIndex = 26;
            this.BalancedCheck.TabStop = true;
            this.BalancedCheck.Text = "Сбалансированная";
            this.BalancedCheck.UseVisualStyleBackColor = true;
            this.BalancedCheck.CheckedChanged += new System.EventHandler(this.BalancedCheck_CheckedChanged);
            // 
            // AccurateCheck
            // 
            this.AccurateCheck.AutoSize = true;
            this.AccurateCheck.Location = new System.Drawing.Point(377, 97);
            this.AccurateCheck.Name = "AccurateCheck";
            this.AccurateCheck.Size = new System.Drawing.Size(64, 19);
            this.AccurateCheck.TabIndex = 27;
            this.AccurateCheck.TabStop = true;
            this.AccurateCheck.Text = "Точная";
            this.AccurateCheck.UseVisualStyleBackColor = true;
            this.AccurateCheck.CheckedChanged += new System.EventHandler(this.AccurateCheck_CheckedChanged);
            // 
            // ResultDataGrid
            // 
            this.ResultDataGrid.AllowUserToAddRows = false;
            this.ResultDataGrid.AllowUserToDeleteRows = false;
            this.ResultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultDataGrid.Location = new System.Drawing.Point(528, 5);
            this.ResultDataGrid.Name = "ResultDataGrid";
            this.ResultDataGrid.RowTemplate.Height = 25;
            this.ResultDataGrid.Size = new System.Drawing.Size(724, 664);
            this.ResultDataGrid.TabIndex = 28;
            this.ResultDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultDataGrid_CellContentClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.ResultDataGrid);
            this.Controls.Add(this.AccurateCheck);
            this.Controls.Add(this.BalancedCheck);
            this.Controls.Add(this.QuickCheck);
            this.Controls.Add(this.FileExtensionTxtCheck);
            this.Controls.Add(this.FileExtensionOdtCheck);
            this.Controls.Add(this.FileExtensionDocCheck);
            this.Controls.Add(this.FileExtensionDocxCheck);
            this.Controls.Add(this.СomparableFilesTitleLabel);
            this.Controls.Add(this.СomparableFilesList);
            this.Controls.Add(this.VerifiableFilesTitleLabel);
            this.Controls.Add(this.VerifiableFilesList);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.CheckType);
            this.Controls.Add(this.FileExtensionTitleLabel);
            this.Controls.Add(this.SelectComparablePathButton);
            this.Controls.Add(this.SelectVerifiablePathButton);
            this.Controls.Add(this.СomparablePathLabel);
            this.Controls.Add(this.VerifiablePathLabel);
            this.Controls.Add(this.СomparablePathTitleLabel);
            this.Controls.Add(this.VerifiablePathTitleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Defori";
            ((System.ComponentModel.ISupportInitialize)(this.ResultDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label VerifiablePathTitleLabel;
        private Label СomparablePathTitleLabel;
        private Label VerifiablePathLabel;
        private Label СomparablePathLabel;
        private Button SelectVerifiablePathButton;
        private Button SelectComparablePathButton;
        private Label FileExtensionTitleLabel;
        private Label CheckType;
        private Button Start;
        private ListBox VerifiableFilesList;
        private Label VerifiableFilesTitleLabel;
        private ListBox СomparableFilesList;
        private Label СomparableFilesTitleLabel;
        private CheckBox FileExtensionDocxCheck;
        private CheckBox FileExtensionDocCheck;
        private CheckBox FileExtensionOdtCheck;
        private CheckBox FileExtensionTxtCheck;
        private RadioButton QuickCheck;
        private RadioButton BalancedCheck;
        private RadioButton AccurateCheck;
        private DataGridView ResultDataGrid;
    }
}