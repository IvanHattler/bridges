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
    public partial class DocumentationInfoEditView : BaseView, IDocumentationInfoEditView
    {
        DocumentationInfo _documentationInfo;

        public DocumentationInfoEditView(DocumentationInfo documentationInfo)
        {
            InitializeComponent();

            Entity = documentationInfo;
        }

        public DocumentationInfo Entity
        {
            get
            {
                _documentationInfo.NameAndDate = tbNameAndDate.Text;
                _documentationInfo.Creator = tbCreator.Text;
                _documentationInfo.Storage = tbStorage.Text;
                return _documentationInfo;
            }
            set
            {
                _documentationInfo = value;
                if (_documentationInfo != null)
                {
                    tbNameAndDate.Text = _documentationInfo.NameAndDate;
                    tbCreator.Text = _documentationInfo.Creator;
                    tbStorage.Text = _documentationInfo.Storage;
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
