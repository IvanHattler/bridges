namespace ITS.MapObjects.BridgesMapObject.Views
{
    partial class BridgeSummaryView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BridgeSummaryView));
            this.dgvBridges = new System.Windows.Forms.DataGridView();
            this.ShowOnMapColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditBridgeColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControlFilter = new System.Windows.Forms.TabControl();
            this.tabPageBridge = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBoxBridgeFilter = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.filterValueControlBridge = new ITS.MapObjects.BaseMapObject.FilterControls.FilterValueControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnAddBridgeFilter = new System.Windows.Forms.Button();
            this.flowPanelAddedBridgeFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBridges)).BeginInit();
            this.tabControlFilter.SuspendLayout();
            this.tabPageBridge.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBoxBridgeFilter.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBridges
            // 
            this.dgvBridges.AllowUserToAddRows = false;
            this.dgvBridges.AllowUserToDeleteRows = false;
            this.dgvBridges.AllowUserToOrderColumns = true;
            this.dgvBridges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBridges.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBridges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShowOnMapColumn,
            this.EditBridgeColumn});
            this.dgvBridges.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvBridges.Location = new System.Drawing.Point(0, 0);
            this.dgvBridges.Name = "dgvBridges";
            this.dgvBridges.ReadOnly = true;
            this.dgvBridges.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBridges.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBridges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBridges.Size = new System.Drawing.Size(651, 538);
            this.dgvBridges.TabIndex = 10;
            this.dgvBridges.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BridgesGrid_CellContentClickHandler);
            this.dgvBridges.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.BridgeGridCellFormatting);
            // 
            // ShowOnMapColumn
            // 
            this.ShowOnMapColumn.FillWeight = 1F;
            this.ShowOnMapColumn.HeaderText = "";
            this.ShowOnMapColumn.Image = ((System.Drawing.Image)(resources.GetObject("ShowOnMapColumn.Image")));
            this.ShowOnMapColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ShowOnMapColumn.MinimumWidth = 20;
            this.ShowOnMapColumn.Name = "ShowOnMapColumn";
            this.ShowOnMapColumn.ReadOnly = true;
            this.ShowOnMapColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ShowOnMapColumn.ToolTipText = "Показать объект на карте";
            this.ShowOnMapColumn.Width = 20;
            // 
            // EditBridgeColumn
            // 
            this.EditBridgeColumn.FillWeight = 1F;
            this.EditBridgeColumn.HeaderText = "";
            this.EditBridgeColumn.Image = ((System.Drawing.Image)(resources.GetObject("EditBridgeColumn.Image")));
            this.EditBridgeColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EditBridgeColumn.MinimumWidth = 20;
            this.EditBridgeColumn.Name = "EditBridgeColumn";
            this.EditBridgeColumn.ReadOnly = true;
            this.EditBridgeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EditBridgeColumn.ToolTipText = "Редактировать группировки";
            this.EditBridgeColumn.Width = 20;
            // 
            // tabControlFilter
            // 
            this.tabControlFilter.Controls.Add(this.tabPageBridge);
            this.tabControlFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControlFilter.Location = new System.Drawing.Point(651, 0);
            this.tabControlFilter.Name = "tabControlFilter";
            this.tabControlFilter.SelectedIndex = 0;
            this.tabControlFilter.Size = new System.Drawing.Size(282, 558);
            this.tabControlFilter.TabIndex = 9;
            // 
            // tabPageBridge
            // 
            this.tabPageBridge.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBridge.Controls.Add(this.panel2);
            this.tabPageBridge.Controls.Add(this.panel3);
            this.tabPageBridge.Location = new System.Drawing.Point(4, 22);
            this.tabPageBridge.Name = "tabPageBridge";
            this.tabPageBridge.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBridge.Size = new System.Drawing.Size(274, 532);
            this.tabPageBridge.TabIndex = 0;
            this.tabPageBridge.Text = "Ваш объект";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnApplyFilter);
            this.panel2.Controls.Add(this.btnClearFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 490);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 39);
            this.panel2.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(3, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "СП";
            this.toolTip1.SetToolTip(this.button1, "Сохранить паспорта загруженных мостовых сооружений");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Location = new System.Drawing.Point(196, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 23);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Сохранить";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.ExportWord_ClickHandler);
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApplyFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApplyFilter.Location = new System.Drawing.Point(48, 8);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(69, 23);
            this.btnApplyFilter.TabIndex = 9;
            this.btnApplyFilter.Text = "Загрузить";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.ApplyFilter_ClickHandler);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearFilter.Location = new System.Drawing.Point(122, 8);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(69, 23);
            this.btnClearFilter.TabIndex = 8;
            this.btnClearFilter.Text = "Сбросить";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.DropFilter_ClickHandler);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.groupBoxBridgeFilter);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 485);
            this.panel3.TabIndex = 1;
            // 
            // groupBoxBridgeFilter
            // 
            this.groupBoxBridgeFilter.AutoSize = true;
            this.groupBoxBridgeFilter.Controls.Add(this.flowLayoutPanel2);
            this.groupBoxBridgeFilter.Location = new System.Drawing.Point(3, 0);
            this.groupBoxBridgeFilter.Name = "groupBoxBridgeFilter";
            this.groupBoxBridgeFilter.Size = new System.Drawing.Size(261, 106);
            this.groupBoxBridgeFilter.TabIndex = 5;
            this.groupBoxBridgeFilter.TabStop = false;
            this.groupBoxBridgeFilter.Text = "Параметры фильтра";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.filterValueControlBridge);
            this.flowLayoutPanel2.Controls.Add(this.panel6);
            this.flowLayoutPanel2.Controls.Add(this.flowPanelAddedBridgeFilters);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(255, 87);
            this.flowLayoutPanel2.TabIndex = 156;
            // 
            // filterValueControlBridge
            // 
            this.filterValueControlBridge.AutoSize = true;
            this.filterValueControlBridge.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterValueControlBridge.Location = new System.Drawing.Point(3, 3);
            this.filterValueControlBridge.MinimumSize = new System.Drawing.Size(247, 44);
            this.filterValueControlBridge.Name = "filterValueControlBridge";
            this.filterValueControlBridge.Size = new System.Drawing.Size(247, 44);
            this.filterValueControlBridge.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnAddBridgeFilter);
            this.panel6.Location = new System.Drawing.Point(3, 53);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(164, 31);
            this.panel6.TabIndex = 152;
            // 
            // btnAddBridgeFilter
            // 
            this.btnAddBridgeFilter.Location = new System.Drawing.Point(3, 3);
            this.btnAddBridgeFilter.Name = "btnAddBridgeFilter";
            this.btnAddBridgeFilter.Size = new System.Drawing.Size(75, 23);
            this.btnAddBridgeFilter.TabIndex = 150;
            this.btnAddBridgeFilter.Text = "Добавить";
            this.btnAddBridgeFilter.UseVisualStyleBackColor = true;
            this.btnAddBridgeFilter.Click += new System.EventHandler(this.btnAddBridgeFilter_Click);
            // 
            // flowPanelAddedBridgeFilters
            // 
            this.flowPanelAddedBridgeFilters.AutoSize = true;
            this.flowPanelAddedBridgeFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelAddedBridgeFilters.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelAddedBridgeFilters.Location = new System.Drawing.Point(0, 87);
            this.flowPanelAddedBridgeFilters.Margin = new System.Windows.Forms.Padding(0);
            this.flowPanelAddedBridgeFilters.Name = "flowPanelAddedBridgeFilters";
            this.flowPanelAddedBridgeFilters.Size = new System.Drawing.Size(253, 0);
            this.flowPanelAddedBridgeFilters.TabIndex = 154;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(5, 541);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(72, 13);
            this.lbCount.TabIndex = 11;
            this.lbCount.Text = "Количество: ";
            // 
            // BridgeSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 558);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.dgvBridges);
            this.Controls.Add(this.tabControlFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BridgeSummaryView";
            this.Text = "Сводная ведомость";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBridges)).EndInit();
            this.tabControlFilter.ResumeLayout(false);
            this.tabPageBridge.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBoxBridgeFilter.ResumeLayout(false);
            this.groupBoxBridgeFilter.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBridges;
        private System.Windows.Forms.DataGridViewImageColumn ShowOnMapColumn;
        private System.Windows.Forms.DataGridViewImageColumn EditBridgeColumn;
        private System.Windows.Forms.TabControl tabControlFilter;
        private System.Windows.Forms.TabPage tabPageBridge;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBoxBridgeFilter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private BaseMapObject.FilterControls.FilterValueControl filterValueControlBridge;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnAddBridgeFilter;
        private System.Windows.Forms.FlowLayoutPanel flowPanelAddedBridgeFilters;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbCount;
    }
}