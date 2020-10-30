namespace Askona_IKEA_ECIS
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.FinishDate = new System.Windows.Forms.DateTimePicker();
            this.StartLabel = new System.Windows.Forms.Label();
            this.FinishLabel = new System.Windows.Forms.Label();
            this.StoreLabel = new System.Windows.Forms.Label();
            this.StoreCB = new System.Windows.Forms.ComboBox();
            this.PlanDataGrid = new System.Windows.Forms.DataGridView();
            this.ViewButton = new System.Windows.Forms.Button();
            this.ItemLabel = new System.Windows.Forms.Label();
            this.ItemCB = new System.Windows.Forms.ComboBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.OpenFD = new System.Windows.Forms.OpenFileDialog();
            this.FileBar = new System.Windows.Forms.ProgressBar();
            this.FillColorButton = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miLoadTranzact = new System.Windows.Forms.ToolStripMenuItem();
            this.miOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.miSupply = new System.Windows.Forms.ToolStripMenuItem();
            this.miMC = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportButton = new System.Windows.Forms.Button();
            this.FullChB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlanDataGrid)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartDate
            // 
            this.StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartDate.Location = new System.Drawing.Point(93, 27);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(175, 22);
            this.StartDate.TabIndex = 1;
            // 
            // FinishDate
            // 
            this.FinishDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FinishDate.Location = new System.Drawing.Point(306, 27);
            this.FinishDate.Name = "FinishDate";
            this.FinishDate.Size = new System.Drawing.Size(175, 22);
            this.FinishDate.TabIndex = 2;
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartLabel.Location = new System.Drawing.Point(12, 30);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(75, 16);
            this.StartLabel.TabIndex = 3;
            this.StartLabel.Text = "Анализ с";
            // 
            // FinishLabel
            // 
            this.FinishLabel.AutoSize = true;
            this.FinishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FinishLabel.Location = new System.Drawing.Point(274, 30);
            this.FinishLabel.Name = "FinishLabel";
            this.FinishLabel.Size = new System.Drawing.Size(26, 16);
            this.FinishLabel.TabIndex = 4;
            this.FinishLabel.Text = "по";
            // 
            // StoreLabel
            // 
            this.StoreLabel.AutoSize = true;
            this.StoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StoreLabel.Location = new System.Drawing.Point(12, 58);
            this.StoreLabel.Name = "StoreLabel";
            this.StoreLabel.Size = new System.Drawing.Size(76, 16);
            this.StoreLabel.TabIndex = 5;
            this.StoreLabel.Text = "Магазин:";
            // 
            // StoreCB
            // 
            this.StoreCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StoreCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StoreCB.FormattingEnabled = true;
            this.StoreCB.Location = new System.Drawing.Point(93, 55);
            this.StoreCB.Name = "StoreCB";
            this.StoreCB.Size = new System.Drawing.Size(65, 24);
            this.StoreCB.TabIndex = 3;
            // 
            // PlanDataGrid
            // 
            this.PlanDataGrid.AllowUserToAddRows = false;
            this.PlanDataGrid.AllowUserToDeleteRows = false;
            this.PlanDataGrid.AllowUserToResizeRows = false;
            this.PlanDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PlanDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.PlanDataGrid.ColumnHeadersHeight = 20;
            this.PlanDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.PlanDataGrid.Location = new System.Drawing.Point(5, 83);
            this.PlanDataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.PlanDataGrid.Name = "PlanDataGrid";
            this.PlanDataGrid.ReadOnly = true;
            this.PlanDataGrid.RowHeadersWidth = 4;
            this.PlanDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.PlanDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PlanDataGrid.Size = new System.Drawing.Size(1166, 473);
            this.PlanDataGrid.TabIndex = 0;
            // 
            // ViewButton
            // 
            this.ViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewButton.Location = new System.Drawing.Point(487, 50);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(125, 30);
            this.ViewButton.TabIndex = 5;
            this.ViewButton.Text = "Просмотр";
            this.ViewButton.UseVisualStyleBackColor = true;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // ItemLabel
            // 
            this.ItemLabel.AutoSize = true;
            this.ItemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ItemLabel.Location = new System.Drawing.Point(164, 58);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(34, 16);
            this.ItemLabel.TabIndex = 9;
            this.ItemLabel.Text = "МЦ:";
            // 
            // ItemCB
            // 
            this.ItemCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemCB.DropDownWidth = 325;
            this.ItemCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ItemCB.FormattingEnabled = true;
            this.ItemCB.Location = new System.Drawing.Point(204, 55);
            this.ItemCB.Name = "ItemCB";
            this.ItemCB.Size = new System.Drawing.Size(277, 24);
            this.ItemCB.TabIndex = 4;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CalculateButton.Location = new System.Drawing.Point(864, 49);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(150, 30);
            this.CalculateButton.TabIndex = 8;
            this.CalculateButton.Text = "Расчет";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // OpenFD
            // 
            this.OpenFD.FileName = "OpenFD";
            // 
            // FileBar
            // 
            this.FileBar.Location = new System.Drawing.Point(488, 27);
            this.FileBar.Name = "FileBar";
            this.FileBar.Size = new System.Drawing.Size(682, 20);
            this.FileBar.TabIndex = 0;
            this.FileBar.Visible = false;
            // 
            // FillColorButton
            // 
            this.FillColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FillColorButton.Location = new System.Drawing.Point(618, 50);
            this.FillColorButton.Name = "FillColorButton";
            this.FillColorButton.Size = new System.Drawing.Size(125, 30);
            this.FillColorButton.TabIndex = 6;
            this.FillColorButton.Text = "Закрасить";
            this.FillColorButton.UseVisualStyleBackColor = true;
            this.FillColorButton.Click += new System.EventHandler(this.FillColorButton_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miOptions});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1176, 24);
            this.MainMenu.TabIndex = 10;
            this.MainMenu.Text = "MainMenu";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLoadTranzact});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(48, 20);
            this.miFile.Text = "Файл";
            // 
            // miLoadTranzact
            // 
            this.miLoadTranzact.Name = "miLoadTranzact";
            this.miLoadTranzact.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miLoadTranzact.Size = new System.Drawing.Size(237, 22);
            this.miLoadTranzact.Text = "Загрузить транзакции";
            this.miLoadTranzact.Click += new System.EventHandler(this.MiLoadTranzact_Click);
            // 
            // miOptions
            // 
            this.miOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSupply,
            this.miMC});
            this.miOptions.Name = "miOptions";
            this.miOptions.Size = new System.Drawing.Size(56, 20);
            this.miOptions.Text = "Опции";
            // 
            // miSupply
            // 
            this.miSupply.Name = "miSupply";
            this.miSupply.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.miSupply.Size = new System.Drawing.Size(220, 22);
            this.miSupply.Text = "Загрузить отгрузки";
            this.miSupply.Click += new System.EventHandler(this.MiSupply_Click);
            // 
            // miMC
            // 
            this.miMC.Name = "miMC";
            this.miMC.Size = new System.Drawing.Size(220, 22);
            this.miMC.Text = "Каталог МЦ";
            this.miMC.Click += new System.EventHandler(this.MiMC_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExportButton.Location = new System.Drawing.Point(1020, 49);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(150, 30);
            this.ExportButton.TabIndex = 9;
            this.ExportButton.Text = "Экспорт в Excel";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // FullChB
            // 
            this.FullChB.AutoSize = true;
            this.FullChB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullChB.Location = new System.Drawing.Point(864, 27);
            this.FullChB.Name = "FullChB";
            this.FullChB.Size = new System.Drawing.Size(76, 20);
            this.FullChB.TabIndex = 7;
            this.FullChB.Text = "полный";
            this.FullChB.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 562);
            this.Controls.Add(this.FullChB);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.FillColorButton);
            this.Controls.Add(this.FileBar);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.ItemCB);
            this.Controls.Add(this.ItemLabel);
            this.Controls.Add(this.ViewButton);
            this.Controls.Add(this.PlanDataGrid);
            this.Controls.Add(this.StoreCB);
            this.Controls.Add(this.StoreLabel);
            this.Controls.Add(this.FinishLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.FinishDate);
            this.Controls.Add(this.StartDate);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MaximumSize = new System.Drawing.Size(1192, 1000);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Планирование 2020";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlanDataGrid)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.DateTimePicker FinishDate;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label FinishLabel;
        private System.Windows.Forms.Label StoreLabel;
        private System.Windows.Forms.DataGridView PlanDataGrid;
        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.Label ItemLabel;
        private System.Windows.Forms.ComboBox ItemCB;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.OpenFileDialog OpenFD;
        private System.Windows.Forms.ProgressBar FileBar;
        private System.Windows.Forms.Button FillColorButton;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miLoadTranzact;
        private System.Windows.Forms.ToolStripMenuItem miOptions;
        private System.Windows.Forms.ToolStripMenuItem miSupply;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.CheckBox FullChB;
        private System.Windows.Forms.ToolStripMenuItem miMC;
        public System.Windows.Forms.ComboBox StoreCB;
    }
}

