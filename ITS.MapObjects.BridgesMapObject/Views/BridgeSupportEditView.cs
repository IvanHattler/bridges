using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Bridges.ManagerInterfaces;
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
using Microsoft.Practices.Unity;

namespace ITS.MapObjects.BridgesMapObject.Views
{
    public partial class BridgeSupportEditView : BaseView, IBridgeSupportEditView
    {
        BridgeSupport _bridgeSupport;
        IMaterialManager _materialManager;
        ITypicalProjectManager _typicalProjectManager;
        private List<TypicalProject> typicalProjects;
        private const string entityName = "Опоры";

        public BridgeSupportEditView(BridgeSupport bridgeSupport, IMaterialManager materialManager,
            ITypicalProjectManager typicalProjectManager)
        {
            _materialManager = materialManager;
            _typicalProjectManager = typicalProjectManager;
            InitializeComponent();
            albHeights.ElementAdding += obj =>
            {
                return (float)nudAddHeight.Value;
            };
            albSchemePileDistances.ElementAdding += obj =>
            {
                return (float)nudAddSchemePileDistances.Value;
            };
            object copyHandler(object obj) => obj;
            albHeights.ElementCopying += copyHandler;
            albSchemePileDistances.ElementCopying += copyHandler;
            chbIsShore.Checked = bridgeSupport.IsShore;
            FillSupportType(bridgeSupport.IsShore);
            FillEnumValues<FoundationType, FoundationTypeStrings>(flpFoundationType);
            cbMaterial.DataSource = materialManager.GetAll();
            typicalProjects = typicalProjectManager.GetAll().Where(tp => tp.Target == "Опоры").ToList();
            cbTypicalProject.DataSource = typicalProjects;
            chbCircleCrossSection.Checked = bridgeSupport.PileCrossSectionHeight == null;
            Entity = bridgeSupport;
        }
        public BridgeSupport Entity
        {
            get
            {
                _bridgeSupport.IsShore = chbIsShore.Checked;
                if (_bridgeSupport.IsShore)
                    _bridgeSupport.ShoreType = GetSelected<ShoreSupportType, ShoreSupportTypeStrings>(flpSupportType);
                else
                    _bridgeSupport.IntermediateType = GetSelected<IntermediateSupportType, IntermediateSupportTypeStrings>(flpSupportType);
                _bridgeSupport.SupportTypeAdditionalInfo = tbSupportTypeAdditionalInfo.Text;
                _bridgeSupport.FoundationType = GetSelected<FoundationType, FoundationTypeStrings>(flpFoundationType);
                _bridgeSupport.Material = GetObject<Material>(cbMaterial);
                var heights = GetObjects<float>(albHeights);
                if (heights != null && heights.Count > 0)
                {
                    _bridgeSupport.Heights = heights.ToArray();
                }
                _bridgeSupport.LayingDepth = (float)nudLayingDepth.Value;
                _bridgeSupport.TypicalProject = GetObject<TypicalProject>(cbTypicalProject);
                _bridgeSupport.MassivePartSizeAlong = GetNullable<float>(nudMassivePartSizeAlong, chbMassivePartSizeAlong);
                _bridgeSupport.MassivePartSizeAcross = GetNullable<float>(nudMassivePartSizeAcross, chbMassivePartSizeAcross);
                _bridgeSupport.PileCount = (int)nudPileCount.Value;
                _bridgeSupport.SchemeKLeft = (float)nudSchemeKLeft.Value;
                _bridgeSupport.SchemeKRight = (float)nudSchemeKRight.Value;
                var distances = GetObjects<float>(albSchemePileDistances);
                if (distances != null && distances.Count > 0)
                {
                    _bridgeSupport.SchemePileDistances = distances.ToArray();
                }
                _bridgeSupport.SchemePileRowDistance1 = GetNullable<float>(nudSchemePileRowDistance1, chbSchemePileRowDistance1);
                _bridgeSupport.SchemePileRowDistance2 = GetNullable<float>(nudSchemePileRowDistance2, chbSchemePileRowDistance2);
                _bridgeSupport.CrossbarWidth = (float)nudCrossbarWidth.Value;
                _bridgeSupport.CrossbarHeight = (float)nudCrossbarHeight.Value;
                _bridgeSupport.CrossbarLength = (float)nudCrossbarLength.Value;
                _bridgeSupport.PileCrossSectionWidth = (float)nudPileCrossSectionWidth.Value;
                if (!chbCircleCrossSection.Checked)
                {
                    _bridgeSupport.PileCrossSectionHeight = (float?)nudPileCrossSectionHeight.Value;
                }
                else
                {
                    _bridgeSupport.PileCrossSectionHeight = null;
                }
                _bridgeSupport.Notes = tbNotes.Text;
                return _bridgeSupport;
            }
            set
            {
                _bridgeSupport = value;
                if (_bridgeSupport != null)
                {
                    chbIsShore.Checked = _bridgeSupport.IsShore;
                    if (_bridgeSupport.IsShore)
                        SelectEnumElement(_bridgeSupport.ShoreSupportTypeAsString, flpSupportType);
                    else
                        SelectEnumElement(_bridgeSupport.IntermediateSupportTypeAsString, flpSupportType);
                    tbSupportTypeAdditionalInfo.Text = _bridgeSupport.SupportTypeAdditionalInfo;
                    SelectEnumElement(_bridgeSupport.FoundationTypeAsString, flpFoundationType);
                    SetObject(cbMaterial, _bridgeSupport.Material);
                    SetObjects(_bridgeSupport.Heights, albHeights);
                    nudLayingDepth.Value = (decimal)_bridgeSupport.LayingDepth;
                    SetObject(cbTypicalProject, _bridgeSupport.TypicalProject);
                    SetNullable(_bridgeSupport.MassivePartSizeAlong, nudMassivePartSizeAlong, chbMassivePartSizeAlong);
                    SetNullable(_bridgeSupport.MassivePartSizeAcross, nudMassivePartSizeAcross, chbMassivePartSizeAcross);
                    nudPileCount.Value = _bridgeSupport.PileCount;
                    nudSchemeKLeft.Value = (decimal)_bridgeSupport.SchemeKLeft;
                    nudSchemeKRight.Value = (decimal)_bridgeSupport.SchemeKRight;
                    SetObjects(_bridgeSupport.SchemePileDistances, albSchemePileDistances);
                    SetNullable(_bridgeSupport.SchemePileRowDistance1, nudSchemePileRowDistance1, chbSchemePileRowDistance1);
                    SetNullable(_bridgeSupport.SchemePileRowDistance2, nudSchemePileRowDistance2, chbSchemePileRowDistance2);
                    nudCrossbarWidth.Value = (decimal)_bridgeSupport.CrossbarWidth;
                    nudCrossbarHeight.Value = (decimal)_bridgeSupport.CrossbarHeight;
                    nudCrossbarLength.Value = (decimal)_bridgeSupport.CrossbarLength;
                    nudPileCrossSectionWidth.Value = (decimal)_bridgeSupport.PileCrossSectionWidth;
                    if (_bridgeSupport.PileCrossSectionHeight != null)
                    {
                        chbCircleCrossSection.Checked = false;
                        nudPileCrossSectionHeight.Value = (decimal)_bridgeSupport.PileCrossSectionHeight;
                    }
                    else
                    {
                        chbCircleCrossSection.Checked = true;
                    }
                    tbNotes.Text = _bridgeSupport.Notes;
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

        private void chbIsShore_CheckedChanged(object sender, EventArgs e)
        {
            FillSupportType((sender as CheckBox).Checked);
        }

        private void FillSupportType(bool isShore)
        {
            flpSupportType.Controls.Clear();
            if (isShore)
            {
                FillEnumValues<ShoreSupportType, ShoreSupportTypeStrings>
                    (flpSupportType, chbSupportType_CheckedChanged, toolTip1);
                gbSupportType.Text = " Тип береговой опоры ";
            }
            else
            {
                FillEnumValues<IntermediateSupportType, IntermediateSupportTypeStrings>
                    (flpSupportType, chbSupportType_CheckedChanged, toolTip1);
                gbSupportType.Text = " Тип промежуточной опоры ";
            }
        }

        private void chbMassivePartSizeAlong_CheckedChanged(object sender, EventArgs e)
        {
            nudMassivePartSizeAlong.Enabled = (sender as CheckBox).Checked;
        }

        private void chbMassivePartSizeAcross_CheckedChanged(object sender, EventArgs e)
        {
            nudMassivePartSizeAcross.Enabled = (sender as CheckBox).Checked;
        }

        private void cbSchemePileRowDistance1_CheckedChanged(object sender, EventArgs e)
        {
            nudSchemePileRowDistance1.Enabled = (sender as CheckBox).Checked;
        }

        private void cbSchemePileRowDistance2_CheckedChanged(object sender, EventArgs e)
        {
            nudSchemePileRowDistance2.Enabled = (sender as CheckBox).Checked;
        }

        private void chbCircleCrossSection_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                lbPileCrossSectionWidth.Text = "Диаметр";
                nudPileCrossSectionHeight.Visible =
                lbPileCrossSectionHeight.Visible = false;
            }
            else
            {
                lbPileCrossSectionWidth.Text = "Ширина";
                nudPileCrossSectionHeight.Visible =
                lbPileCrossSectionHeight.Visible = true;
            }
        }

        private void chbSupportType_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb.Checked)
            {
                if (chbIsShore.Checked)
                {
                    pbSupportType.Image =
                        GetImageFromResourses<ShoreSupportType, ShoreSupportTypeStrings>(
                            rb.Text, "ST_");
                }
                else
                {
                    pbSupportType.Image =
                        GetImageFromResourses<IntermediateSupportType, IntermediateSupportTypeStrings>(
                             rb.Text, "ST_");
                }
            }
        }

        private void btnAddTypicalProject_Click(object sender, EventArgs e)
        {
            var view = BridgeConstants.Container.Resolve<ITypicalProjectAddView>(
                new ParameterOverride("typicalProject", 
                    new TypicalProject() { Target = entityName }));
            var res = view.ShowViewDialog();
            if (res == DialogResult.OK)
            {
                var proj = _typicalProjectManager.AddNew(view.Entity);
                if (proj.Target == entityName)
                {
                    var tmp = new List<TypicalProject>(typicalProjects)
                    {
                        proj
                    };
                    cbTypicalProject.DataSource = typicalProjects = tmp;
                    SetObject(cbTypicalProject, _bridgeSupport.TypicalProject);
                }
            }
        }
    }
}
