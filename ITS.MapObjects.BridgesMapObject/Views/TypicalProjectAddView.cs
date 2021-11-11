using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.Managers.BridgesManagers.Managers;
using ITS.MapObjects.BridgesMapObject.Controls;
using ITS.MapObjects.BridgesMapObject.IViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ITS.MapObjects.BridgesMapObject.Helpers.EditViewHelper;

namespace ITS.MapObjects.BridgesMapObject.Views
{
    public partial class TypicalProjectAddView : BaseView, ITypicalProjectAddView
    {
        TypicalProject _typicalProject;

        public TypicalProjectAddView(TypicalProject typicalProject)
        {
            InitializeComponent();
            
            Entity = typicalProject;
        }

        public TypicalProject Entity
        {
            get
            {
                _typicalProject.Target = cbTarget.SelectedItem as string;
                _typicalProject.Name = tbName.Text;
                return _typicalProject;
            }
            set
            {
                _typicalProject = value;
                if (_typicalProject != null)
                {
                    cbTarget.SelectedItem = _typicalProject.Target;
                    tbName.Text = _typicalProject.Name;
                }
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            CloseView();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            CloseView();
        }
    }
}
