namespace ITS.MapObjects.BridgesMapObject.Controls
{
    partial class AddableTreeView
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExpandAll = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mainGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Controls.Add(this.button1);
            this.mainGroupBox.Controls.Add(this.btnExpandAll);
            this.mainGroupBox.Controls.Add(this.btnDown);
            this.mainGroupBox.Controls.Add(this.btnUp);
            this.mainGroupBox.Controls.Add(this.tvMain);
            this.mainGroupBox.Controls.Add(this.btnEdit);
            this.mainGroupBox.Controls.Add(this.btnCopy);
            this.mainGroupBox.Controls.Add(this.btnAdd);
            this.mainGroupBox.Controls.Add(this.btnRemove);
            this.mainGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGroupBox.Location = new System.Drawing.Point(0, 0);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Size = new System.Drawing.Size(258, 173);
            this.mainGroupBox.TabIndex = 104;
            this.mainGroupBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(4, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 25);
            this.button1.TabIndex = 109;
            this.button1.Text = "С";
            this.toolTip1.SetToolTip(this.button1, "Свернуть все элементы");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExpandAll.Location = new System.Drawing.Point(32, 146);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(27, 25);
            this.btnExpandAll.TabIndex = 108;
            this.btnExpandAll.Text = "Р";
            this.toolTip1.SetToolTip(this.btnExpandAll, "Развернуть все элементы");
            this.btnExpandAll.UseVisualStyleBackColor = true;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Image = global::ITS.MapObjects.BridgesMapObject.Properties.Resources.ATVDown;
            this.btnDown.Location = new System.Drawing.Point(228, 146);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(27, 25);
            this.btnDown.TabIndex = 107;
            this.toolTip1.SetToolTip(this.btnDown, "Переместить элемент вниз");
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Image = global::ITS.MapObjects.BridgesMapObject.Properties.Resources.ATVUp;
            this.btnUp.Location = new System.Drawing.Point(200, 146);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(27, 25);
            this.btnUp.TabIndex = 106;
            this.toolTip1.SetToolTip(this.btnUp, "Переместить элемент вверх");
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // tvMain
            // 
            this.tvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvMain.Location = new System.Drawing.Point(3, 16);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(252, 128);
            this.tvMain.TabIndex = 105;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = global::ITS.MapObjects.BridgesMapObject.Properties.Resources.ATVEdit;
            this.btnEdit.Location = new System.Drawing.Point(116, 146);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(27, 25);
            this.btnEdit.TabIndex = 104;
            this.toolTip1.SetToolTip(this.btnEdit, "Редактировать элемент");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Image = global::ITS.MapObjects.BridgesMapObject.Properties.Resources.ATVCopy;
            this.btnCopy.Location = new System.Drawing.Point(144, 146);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(27, 25);
            this.btnCopy.TabIndex = 103;
            this.toolTip1.SetToolTip(this.btnCopy, "Копировать элемент");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::ITS.MapObjects.BridgesMapObject.Properties.Resources.ATVAdd;
            this.btnAdd.Location = new System.Drawing.Point(88, 146);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(27, 25);
            this.btnAdd.TabIndex = 101;
            this.toolTip1.SetToolTip(this.btnAdd, "Добавить элемент");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Image = global::ITS.MapObjects.BridgesMapObject.Properties.Resources.ATVDelete;
            this.btnRemove.Location = new System.Drawing.Point(172, 146);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(27, 25);
            this.btnRemove.TabIndex = 102;
            this.btnRemove.Text = "-";
            this.toolTip1.SetToolTip(this.btnRemove, "Удалить элемент");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // AddableTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainGroupBox);
            this.Name = "AddableTreeView";
            this.Size = new System.Drawing.Size(258, 173);
            this.mainGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnExpandAll;
        private System.Windows.Forms.Button button1;
    }
}
