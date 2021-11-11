using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ITS.MapObjects.BridgesMapObject.IViews;

namespace ITS.MapObjects.BridgesMapObject.Views
{
   public class BaseView : Form, IBaseView
    {
        #region Implementation of IView

        public DialogResult ShowViewDialog()
        {
            if (ViewShowing != null) ViewShowing();
            IsViewVisible = true;
            return ShowDialog();
        }

        public void ShowView()
        {
            if (ViewShowing != null) ViewShowing();
            IsViewVisible = true;
            Show();
        }

        public void CloseView()
        {
            IsViewVisible = false;
            if (ViewClosing != null) ViewClosing();
            Close();
        }

        public event Action ViewShowing;
        public event Action ViewClosing;

        public bool IsViewVisible { get; private set; }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseView
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseView";
            this.Load += new System.EventHandler(this.BaseView_Load);
            this.ResumeLayout(false);

        }

        private void BaseView_Load(object sender, EventArgs e)
        {

        }
    }
}
