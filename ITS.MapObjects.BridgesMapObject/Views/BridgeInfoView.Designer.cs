namespace ITS.MapObjects.BridgesMapObject.Views
{
    partial class BridgeInfoView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BridgeInfoView));
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.clmnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpMainInfo = new System.Windows.Forms.TabPage();
            this.tpDefects = new System.Windows.Forms.TabPage();
            this.dgvDefects = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpOthers = new System.Windows.Forms.TabPage();
            this.dgvOthers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpDocumentations = new System.Windows.Forms.TabPage();
            this.dgvDocumentations = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tpPhotos = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpMainInfo.SuspendLayout();
            this.tpDefects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefects)).BeginInit();
            this.tpOthers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOthers)).BeginInit();
            this.tpDocumentations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentations)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeColumns = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnNumber,
            this.clmnParameter,
            this.clmnValue});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(3, 3);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.Size = new System.Drawing.Size(720, 450);
            this.dgvMain.TabIndex = 0;
            // 
            // clmnNumber
            // 
            this.clmnNumber.FillWeight = 10F;
            this.clmnNumber.HeaderText = "№ п/п";
            this.clmnNumber.Name = "clmnNumber";
            this.clmnNumber.ReadOnly = true;
            this.clmnNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnParameter
            // 
            this.clmnParameter.HeaderText = "Параметр";
            this.clmnParameter.Name = "clmnParameter";
            this.clmnParameter.ReadOnly = true;
            this.clmnParameter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnValue
            // 
            this.clmnValue.HeaderText = "Значение";
            this.clmnValue.Name = "clmnValue";
            this.clmnValue.ReadOnly = true;
            this.clmnValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpMainInfo);
            this.tcMain.Controls.Add(this.tpDefects);
            this.tcMain.Controls.Add(this.tpOthers);
            this.tcMain.Controls.Add(this.tpDocumentations);
            this.tcMain.Controls.Add(this.tpPhotos);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(734, 482);
            this.tcMain.TabIndex = 1;
            // 
            // tpMainInfo
            // 
            this.tpMainInfo.Controls.Add(this.dgvMain);
            this.tpMainInfo.Location = new System.Drawing.Point(4, 22);
            this.tpMainInfo.Name = "tpMainInfo";
            this.tpMainInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpMainInfo.Size = new System.Drawing.Size(726, 456);
            this.tpMainInfo.TabIndex = 0;
            this.tpMainInfo.Text = "Общие сведения";
            this.tpMainInfo.UseVisualStyleBackColor = true;
            // 
            // tpDefects
            // 
            this.tpDefects.Controls.Add(this.dgvDefects);
            this.tpDefects.Location = new System.Drawing.Point(4, 22);
            this.tpDefects.Name = "tpDefects";
            this.tpDefects.Size = new System.Drawing.Size(726, 456);
            this.tpDefects.TabIndex = 1;
            this.tpDefects.Text = "Дефекты";
            this.tpDefects.UseVisualStyleBackColor = true;
            // 
            // dgvDefects
            // 
            this.dgvDefects.AllowUserToAddRows = false;
            this.dgvDefects.AllowUserToDeleteRows = false;
            this.dgvDefects.AllowUserToResizeColumns = false;
            this.dgvDefects.AllowUserToResizeRows = false;
            this.dgvDefects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDefects.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDefects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvDefects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefects.Location = new System.Drawing.Point(0, 0);
            this.dgvDefects.Name = "dgvDefects";
            this.dgvDefects.RowHeadersVisible = false;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDefects.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDefects.Size = new System.Drawing.Size(726, 456);
            this.dgvDefects.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 25F;
            this.dataGridViewTextBoxColumn1.HeaderText = "№ п/п";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Положение дефекта: № пролетов (опор), элемент, № элемента, локализация, материал";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Тип и описание дефекта";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Параметры и их значения";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 50F;
            this.Column2.HeaderText = "Категория по ВСН 4-81";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Примечания";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpOthers
            // 
            this.tpOthers.Controls.Add(this.dgvOthers);
            this.tpOthers.Location = new System.Drawing.Point(4, 22);
            this.tpOthers.Name = "tpOthers";
            this.tpOthers.Size = new System.Drawing.Size(726, 456);
            this.tpOthers.TabIndex = 2;
            this.tpOthers.Text = "Прочее";
            this.tpOthers.UseVisualStyleBackColor = true;
            // 
            // dgvOthers
            // 
            this.dgvOthers.AllowUserToAddRows = false;
            this.dgvOthers.AllowUserToDeleteRows = false;
            this.dgvOthers.AllowUserToResizeColumns = false;
            this.dgvOthers.AllowUserToResizeRows = false;
            this.dgvOthers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOthers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvOthers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOthers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOthers.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOthers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOthers.Location = new System.Drawing.Point(0, 0);
            this.dgvOthers.Name = "dgvOthers";
            this.dgvOthers.RowHeadersVisible = false;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOthers.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOthers.Size = new System.Drawing.Size(726, 456);
            this.dgvOthers.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 10F;
            this.dataGridViewTextBoxColumn4.HeaderText = "№ п/п";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Параметр";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Значение";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpDocumentations
            // 
            this.tpDocumentations.Controls.Add(this.dgvDocumentations);
            this.tpDocumentations.Location = new System.Drawing.Point(4, 22);
            this.tpDocumentations.Name = "tpDocumentations";
            this.tpDocumentations.Size = new System.Drawing.Size(726, 456);
            this.tpDocumentations.TabIndex = 3;
            this.tpDocumentations.Text = "Список имеющейся технической документации";
            this.tpDocumentations.UseVisualStyleBackColor = true;
            // 
            // dgvDocumentations
            // 
            this.dgvDocumentations.AllowUserToAddRows = false;
            this.dgvDocumentations.AllowUserToDeleteRows = false;
            this.dgvDocumentations.AllowUserToResizeColumns = false;
            this.dgvDocumentations.AllowUserToResizeRows = false;
            this.dgvDocumentations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocumentations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDocumentations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Column4});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocumentations.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDocumentations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentations.Location = new System.Drawing.Point(0, 0);
            this.dgvDocumentations.Name = "dgvDocumentations";
            this.dgvDocumentations.RowHeadersVisible = false;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocumentations.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDocumentations.Size = new System.Drawing.Size(726, 456);
            this.dgvDocumentations.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.FillWeight = 80F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Номер документа";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Название, год изготовления";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Изготовитель";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Место хранения";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(660, 485);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 23);
            this.btnOK.TabIndex = 45;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.AutoSize = true;
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Location = new System.Drawing.Point(586, 485);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(70, 23);
            this.btnExport.TabIndex = 46;
            this.btnExport.Text = "Сохранить";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tpPhotos
            // 
            this.tpPhotos.Location = new System.Drawing.Point(4, 22);
            this.tpPhotos.Name = "tpPhotos";
            this.tpPhotos.Size = new System.Drawing.Size(726, 456);
            this.tpPhotos.TabIndex = 4;
            this.tpPhotos.Text = "Фото";
            this.tpPhotos.UseVisualStyleBackColor = true;
            // 
            // BridgeInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BridgeInfoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о мостовом сооружении";
            this.Load += new System.EventHandler(this.BridgeInfoView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpMainInfo.ResumeLayout(false);
            this.tpDefects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefects)).EndInit();
            this.tpOthers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOthers)).EndInit();
            this.tpDocumentations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpMainInfo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage tpDefects;
        private System.Windows.Forms.DataGridView dgvDefects;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabPage tpOthers;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TabPage tpDocumentations;
        private System.Windows.Forms.DataGridView dgvOthers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridView dgvDocumentations;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TabPage tpPhotos;
    }
}