using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
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
    public partial class InfoOfRepairsEditView : BaseView, IInfoOfRepairsEditView
    {
        InfoOfRepairs _infoOfRepairs;

        public InfoOfRepairsEditView(InfoOfRepairs infoOfRepairs)
        {
            InitializeComponent();
            clbInfoOfRepairs.ItemCheck += clbFlagsWithNoneAndNoData_ItemCheck;
            FillEnumValues<ReconstructionJobs, ReconstructionJobsStrings>(clbInfoOfRepairs, true);

            Entity = infoOfRepairs;
        }

        public InfoOfRepairs Entity
        {
            get
            {
                _infoOfRepairs.Date = GetDate(dtpDate);
                _infoOfRepairs.Jobs = GetSelected<ReconstructionJobs, ReconstructionJobsStrings>(clbInfoOfRepairs);
                return _infoOfRepairs;
            }
            set
            {
                _infoOfRepairs = value;
                if (_infoOfRepairs != null)
                {
                    SetDate(dtpDate, _infoOfRepairs.Date);
                    SelectEnumElement(_infoOfRepairs.JobsAsString, clbInfoOfRepairs);
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
