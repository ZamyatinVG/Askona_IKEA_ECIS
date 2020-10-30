namespace Askona_IKEA_ECIS
{
    partial class FormMC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMC));
            this.CatalogDGV = new System.Windows.Forms.DataGridView();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.MCPanel = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.VolumeTB = new System.Windows.Forms.TextBox();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.PriceTB = new System.Windows.Forms.TextBox();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.PalTypeTB = new System.Windows.Forms.TextBox();
            this.PalTypeLabel = new System.Windows.Forms.Label();
            this.PalCountTB = new System.Windows.Forms.TextBox();
            this.PalCountLabel = new System.Windows.Forms.Label();
            this.ArtNameTB = new System.Windows.Forms.TextBox();
            this.ArtNameLabel = new System.Windows.Forms.Label();
            this.ArtNoTB = new System.Windows.Forms.TextBox();
            this.ArtNoLabel = new System.Windows.Forms.Label();
            this.MCButtonPanel = new System.Windows.Forms.Panel();
            this.EditMCButton = new System.Windows.Forms.Button();
            this.RemoveMCButton = new System.Windows.Forms.Button();
            this.AddMCButton = new System.Windows.Forms.Button();
            this.StoreButtonPanel = new System.Windows.Forms.Panel();
            this.RemoveStoreButton = new System.Windows.Forms.Button();
            this.AddStoreButton = new System.Windows.Forms.Button();
            this.StorePanel = new System.Windows.Forms.Panel();
            this.CancelStoreButton = new System.Windows.Forms.Button();
            this.ApplyStoreButton = new System.Windows.Forms.Button();
            this.KodTB = new System.Windows.Forms.TextBox();
            this.KodLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CatalogDGV)).BeginInit();
            this.MCPanel.SuspendLayout();
            this.MCButtonPanel.SuspendLayout();
            this.StoreButtonPanel.SuspendLayout();
            this.StorePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CatalogDGV
            // 
            this.CatalogDGV.AllowUserToAddRows = false;
            this.CatalogDGV.AllowUserToDeleteRows = false;
            this.CatalogDGV.AllowUserToResizeRows = false;
            this.CatalogDGV.ColumnHeadersHeight = 20;
            this.CatalogDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.CatalogDGV.Location = new System.Drawing.Point(12, 12);
            this.CatalogDGV.Name = "CatalogDGV";
            this.CatalogDGV.ReadOnly = true;
            this.CatalogDGV.RowHeadersWidth = 20;
            this.CatalogDGV.Size = new System.Drawing.Size(515, 542);
            this.CatalogDGV.TabIndex = 0;
            this.CatalogDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CatalogDGV_CellClick);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplyButton.Location = new System.Drawing.Point(54, 225);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(150, 30);
            this.ApplyButton.TabIndex = 10;
            this.ApplyButton.Text = "Применить";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // MCPanel
            // 
            this.MCPanel.Controls.Add(this.CancelButton);
            this.MCPanel.Controls.Add(this.VolumeTB);
            this.MCPanel.Controls.Add(this.VolumeLabel);
            this.MCPanel.Controls.Add(this.ApplyButton);
            this.MCPanel.Controls.Add(this.PriceTB);
            this.MCPanel.Controls.Add(this.PriceLabel);
            this.MCPanel.Controls.Add(this.PalTypeTB);
            this.MCPanel.Controls.Add(this.PalTypeLabel);
            this.MCPanel.Controls.Add(this.PalCountTB);
            this.MCPanel.Controls.Add(this.PalCountLabel);
            this.MCPanel.Controls.Add(this.ArtNameTB);
            this.MCPanel.Controls.Add(this.ArtNameLabel);
            this.MCPanel.Controls.Add(this.ArtNoTB);
            this.MCPanel.Controls.Add(this.ArtNoLabel);
            this.MCPanel.Location = new System.Drawing.Point(533, 56);
            this.MCPanel.Name = "MCPanel";
            this.MCPanel.Size = new System.Drawing.Size(462, 274);
            this.MCPanel.TabIndex = 8;
            this.MCPanel.Visible = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelButton.Location = new System.Drawing.Point(258, 225);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(150, 30);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Отменить";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // VolumeTB
            // 
            this.VolumeTB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VolumeTB.Location = new System.Drawing.Point(153, 180);
            this.VolumeTB.Name = "VolumeTB";
            this.VolumeTB.Size = new System.Drawing.Size(300, 29);
            this.VolumeTB.TabIndex = 9;
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VolumeLabel.Location = new System.Drawing.Point(74, 183);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(73, 22);
            this.VolumeLabel.TabIndex = 10;
            this.VolumeLabel.Text = "Объем:";
            // 
            // PriceTB
            // 
            this.PriceTB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceTB.Location = new System.Drawing.Point(153, 145);
            this.PriceTB.Name = "PriceTB";
            this.PriceTB.Size = new System.Drawing.Size(300, 29);
            this.PriceTB.TabIndex = 8;
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceLabel.Location = new System.Drawing.Point(88, 148);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(59, 22);
            this.PriceLabel.TabIndex = 8;
            this.PriceLabel.Text = "Цена:";
            // 
            // PalTypeTB
            // 
            this.PalTypeTB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PalTypeTB.Location = new System.Drawing.Point(153, 110);
            this.PalTypeTB.Name = "PalTypeTB";
            this.PalTypeTB.Size = new System.Drawing.Size(300, 29);
            this.PalTypeTB.TabIndex = 7;
            // 
            // PalTypeLabel
            // 
            this.PalTypeLabel.AutoSize = true;
            this.PalTypeLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PalTypeLabel.Location = new System.Drawing.Point(97, 113);
            this.PalTypeLabel.Name = "PalTypeLabel";
            this.PalTypeLabel.Size = new System.Drawing.Size(50, 22);
            this.PalTypeLabel.TabIndex = 6;
            this.PalTypeLabel.Text = "Тип:";
            // 
            // PalCountTB
            // 
            this.PalCountTB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PalCountTB.Location = new System.Drawing.Point(153, 75);
            this.PalCountTB.Name = "PalCountTB";
            this.PalCountTB.Size = new System.Drawing.Size(300, 29);
            this.PalCountTB.TabIndex = 6;
            // 
            // PalCountLabel
            // 
            this.PalCountLabel.AutoSize = true;
            this.PalCountLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PalCountLabel.Location = new System.Drawing.Point(72, 78);
            this.PalCountLabel.Name = "PalCountLabel";
            this.PalCountLabel.Size = new System.Drawing.Size(75, 22);
            this.PalCountLabel.TabIndex = 4;
            this.PalCountLabel.Text = "Кол-во:";
            // 
            // ArtNameTB
            // 
            this.ArtNameTB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ArtNameTB.Location = new System.Drawing.Point(153, 40);
            this.ArtNameTB.Name = "ArtNameTB";
            this.ArtNameTB.Size = new System.Drawing.Size(300, 29);
            this.ArtNameTB.TabIndex = 5;
            // 
            // ArtNameLabel
            // 
            this.ArtNameLabel.AutoSize = true;
            this.ArtNameLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ArtNameLabel.Location = new System.Drawing.Point(3, 43);
            this.ArtNameLabel.Name = "ArtNameLabel";
            this.ArtNameLabel.Size = new System.Drawing.Size(144, 22);
            this.ArtNameLabel.TabIndex = 2;
            this.ArtNameLabel.Text = "Наименование:";
            // 
            // ArtNoTB
            // 
            this.ArtNoTB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ArtNoTB.Location = new System.Drawing.Point(153, 6);
            this.ArtNoTB.Name = "ArtNoTB";
            this.ArtNoTB.Size = new System.Drawing.Size(300, 29);
            this.ArtNoTB.TabIndex = 4;
            // 
            // ArtNoLabel
            // 
            this.ArtNoLabel.AutoSize = true;
            this.ArtNoLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ArtNoLabel.Location = new System.Drawing.Point(58, 9);
            this.ArtNoLabel.Name = "ArtNoLabel";
            this.ArtNoLabel.Size = new System.Drawing.Size(89, 22);
            this.ArtNoLabel.TabIndex = 0;
            this.ArtNoLabel.Text = "Артикул:";
            // 
            // MCButtonPanel
            // 
            this.MCButtonPanel.Controls.Add(this.EditMCButton);
            this.MCButtonPanel.Controls.Add(this.RemoveMCButton);
            this.MCButtonPanel.Controls.Add(this.AddMCButton);
            this.MCButtonPanel.Location = new System.Drawing.Point(534, 12);
            this.MCButtonPanel.Name = "MCButtonPanel";
            this.MCButtonPanel.Size = new System.Drawing.Size(461, 38);
            this.MCButtonPanel.TabIndex = 9;
            // 
            // EditMCButton
            // 
            this.EditMCButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditMCButton.Location = new System.Drawing.Point(155, 3);
            this.EditMCButton.Name = "EditMCButton";
            this.EditMCButton.Size = new System.Drawing.Size(150, 30);
            this.EditMCButton.TabIndex = 2;
            this.EditMCButton.Text = "Изменить МЦ";
            this.EditMCButton.UseVisualStyleBackColor = true;
            this.EditMCButton.Click += new System.EventHandler(this.EditMCButton_Click);
            // 
            // RemoveMCButton
            // 
            this.RemoveMCButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveMCButton.Location = new System.Drawing.Point(311, 3);
            this.RemoveMCButton.Name = "RemoveMCButton";
            this.RemoveMCButton.Size = new System.Drawing.Size(150, 30);
            this.RemoveMCButton.TabIndex = 3;
            this.RemoveMCButton.Text = "Удалить МЦ";
            this.RemoveMCButton.UseVisualStyleBackColor = true;
            this.RemoveMCButton.Click += new System.EventHandler(this.RemoveMCButton_Click);
            // 
            // AddMCButton
            // 
            this.AddMCButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddMCButton.Location = new System.Drawing.Point(-1, 3);
            this.AddMCButton.Name = "AddMCButton";
            this.AddMCButton.Size = new System.Drawing.Size(150, 30);
            this.AddMCButton.TabIndex = 1;
            this.AddMCButton.Text = "Добавить МЦ";
            this.AddMCButton.UseVisualStyleBackColor = true;
            this.AddMCButton.Click += new System.EventHandler(this.AddMCButton_Click);
            // 
            // StoreButtonPanel
            // 
            this.StoreButtonPanel.Controls.Add(this.RemoveStoreButton);
            this.StoreButtonPanel.Controls.Add(this.AddStoreButton);
            this.StoreButtonPanel.Location = new System.Drawing.Point(533, 336);
            this.StoreButtonPanel.Name = "StoreButtonPanel";
            this.StoreButtonPanel.Size = new System.Drawing.Size(461, 38);
            this.StoreButtonPanel.TabIndex = 11;
            // 
            // RemoveStoreButton
            // 
            this.RemoveStoreButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveStoreButton.Location = new System.Drawing.Point(261, 3);
            this.RemoveStoreButton.Name = "RemoveStoreButton";
            this.RemoveStoreButton.Size = new System.Drawing.Size(200, 30);
            this.RemoveStoreButton.TabIndex = 14;
            this.RemoveStoreButton.Text = "Удалить магазин";
            this.RemoveStoreButton.UseVisualStyleBackColor = true;
            this.RemoveStoreButton.Click += new System.EventHandler(this.RemoveStoreButton_Click);
            // 
            // AddStoreButton
            // 
            this.AddStoreButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddStoreButton.Location = new System.Drawing.Point(-1, 3);
            this.AddStoreButton.Name = "AddStoreButton";
            this.AddStoreButton.Size = new System.Drawing.Size(200, 30);
            this.AddStoreButton.TabIndex = 13;
            this.AddStoreButton.Text = "Добавить магазин";
            this.AddStoreButton.UseVisualStyleBackColor = true;
            this.AddStoreButton.Click += new System.EventHandler(this.AddStoreButton_Click);
            // 
            // StorePanel
            // 
            this.StorePanel.Controls.Add(this.CancelStoreButton);
            this.StorePanel.Controls.Add(this.ApplyStoreButton);
            this.StorePanel.Controls.Add(this.KodTB);
            this.StorePanel.Controls.Add(this.KodLabel);
            this.StorePanel.Location = new System.Drawing.Point(534, 380);
            this.StorePanel.Name = "StorePanel";
            this.StorePanel.Size = new System.Drawing.Size(462, 95);
            this.StorePanel.TabIndex = 13;
            this.StorePanel.Visible = false;
            // 
            // CancelStoreButton
            // 
            this.CancelStoreButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelStoreButton.Location = new System.Drawing.Point(258, 50);
            this.CancelStoreButton.Name = "CancelStoreButton";
            this.CancelStoreButton.Size = new System.Drawing.Size(150, 30);
            this.CancelStoreButton.TabIndex = 17;
            this.CancelStoreButton.Text = "Отменить";
            this.CancelStoreButton.UseVisualStyleBackColor = true;
            this.CancelStoreButton.Click += new System.EventHandler(this.CancelStoreButton_Click);
            // 
            // ApplyStoreButton
            // 
            this.ApplyStoreButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplyStoreButton.Location = new System.Drawing.Point(54, 50);
            this.ApplyStoreButton.Name = "ApplyStoreButton";
            this.ApplyStoreButton.Size = new System.Drawing.Size(150, 30);
            this.ApplyStoreButton.TabIndex = 16;
            this.ApplyStoreButton.Text = "Применить";
            this.ApplyStoreButton.UseVisualStyleBackColor = true;
            this.ApplyStoreButton.Click += new System.EventHandler(this.ApplyStoreButton_Click);
            // 
            // KodTB
            // 
            this.KodTB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KodTB.Location = new System.Drawing.Point(153, 6);
            this.KodTB.Name = "KodTB";
            this.KodTB.Size = new System.Drawing.Size(254, 29);
            this.KodTB.TabIndex = 15;
            // 
            // KodLabel
            // 
            this.KodLabel.AutoSize = true;
            this.KodLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KodLabel.Location = new System.Drawing.Point(102, 8);
            this.KodLabel.Name = "KodLabel";
            this.KodLabel.Size = new System.Drawing.Size(47, 22);
            this.KodLabel.TabIndex = 0;
            this.KodLabel.Text = "Код:";
            // 
            // FormMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 562);
            this.Controls.Add(this.StorePanel);
            this.Controls.Add(this.StoreButtonPanel);
            this.Controls.Add(this.MCButtonPanel);
            this.Controls.Add(this.MCPanel);
            this.Controls.Add(this.CatalogDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Каталог МЦ";
            this.Load += new System.EventHandler(this.FormMC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CatalogDGV)).EndInit();
            this.MCPanel.ResumeLayout(false);
            this.MCPanel.PerformLayout();
            this.MCButtonPanel.ResumeLayout(false);
            this.StoreButtonPanel.ResumeLayout(false);
            this.StorePanel.ResumeLayout(false);
            this.StorePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CatalogDGV;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Panel MCPanel;
        private System.Windows.Forms.TextBox ArtNoTB;
        private System.Windows.Forms.Label ArtNoLabel;
        private System.Windows.Forms.TextBox ArtNameTB;
        private System.Windows.Forms.Label ArtNameLabel;
        private System.Windows.Forms.TextBox PalCountTB;
        private System.Windows.Forms.Label PalCountLabel;
        private System.Windows.Forms.TextBox PalTypeTB;
        private System.Windows.Forms.Label PalTypeLabel;
        private System.Windows.Forms.TextBox VolumeTB;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.TextBox PriceTB;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Panel MCButtonPanel;
        private System.Windows.Forms.Button EditMCButton;
        private System.Windows.Forms.Button RemoveMCButton;
        private System.Windows.Forms.Button AddMCButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Panel StoreButtonPanel;
        private System.Windows.Forms.Button RemoveStoreButton;
        private System.Windows.Forms.Button AddStoreButton;
        private System.Windows.Forms.Panel StorePanel;
        private System.Windows.Forms.Button CancelStoreButton;
        private System.Windows.Forms.Button ApplyStoreButton;
        private System.Windows.Forms.TextBox KodTB;
        private System.Windows.Forms.Label KodLabel;
    }
}