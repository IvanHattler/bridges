namespace ITS.MapObjects.BridgesMapObject.Views
{
    partial class DocumentationInfoEditView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentationInfoEditView));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbNameAndDate = new System.Windows.Forms.TextBox();
            this.lb_NearestVillage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCreator = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStorage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(427, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 95;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(349, 105);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 96;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbNameAndDate
            // 
            this.tbNameAndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNameAndDate.Location = new System.Drawing.Point(165, 15);
            this.tbNameAndDate.MaxLength = 255;
            this.tbNameAndDate.Name = "tbNameAndDate";
            this.tbNameAndDate.Size = new System.Drawing.Size(337, 20);
            this.tbNameAndDate.TabIndex = 97;
            // 
            // lb_NearestVillage
            // 
            this.lb_NearestVillage.AutoSize = true;
            this.lb_NearestVillage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_NearestVillage.Location = new System.Drawing.Point(5, 18);
            this.lb_NearestVillage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_NearestVillage.Name = "lb_NearestVillage";
            this.lb_NearestVillage.Size = new System.Drawing.Size(153, 13);
            this.lb_NearestVillage.TabIndex = 98;
            this.lb_NearestVillage.Text = "Название, год изготовления";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Изготовитель";
            // 
            // tbCreator
            // 
            this.tbCreator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCreator.Location = new System.Drawing.Point(165, 41);
            this.tbCreator.MaxLength = 255;
            this.tbCreator.Name = "tbCreator";
            this.tbCreator.Size = new System.Drawing.Size(337, 20);
            this.tbCreator.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Место хранения";
            // 
            // tbStorage
            // 
            this.tbStorage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStorage.Location = new System.Drawing.Point(165, 67);
            this.tbStorage.MaxLength = 255;
            this.tbStorage.Name = "tbStorage";
            this.tbStorage.Size = new System.Drawing.Size(337, 20);
            this.tbStorage.TabIndex = 101;
            // 
            // DocumentationInfoEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 130);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStorage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCreator);
            this.Controls.Add(this.lb_NearestVillage);
            this.Controls.Add(this.tbNameAndDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocumentationInfoEditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Техническая документация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbNameAndDate;
        private System.Windows.Forms.Label lb_NearestVillage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCreator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStorage;
    }
}