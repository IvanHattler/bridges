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
using Microsoft.Practices.Unity;
using static ITS.MapObjects.BridgesMapObject.Helpers.EditViewHelper;

namespace ITS.MapObjects.BridgesMapObject.Views
{
    public partial class SpanStructureEditView : BaseView, ISpanStructureEditView
    {
        SpanStructure _spanStructure;
        IMaterialManager _materialManager;
        SpanBeam _crossPile;
        SpanBeam _longitudinalPile;
        ITypicalProjectManager _typicalProjectManager;
        private List<TypicalProject> typicalProjects;
        private const string entityName = "Пролётные строения";

        public SpanStructureEditView(SpanStructure spanStructure, IMaterialManager materialManager,
            ITypicalProjectManager typicalProjectManager)
        {
            _materialManager = materialManager;
            _typicalProjectManager = typicalProjectManager;
            InitializeComponent();
            albCrossSchemePileDistances.ElementAdding +=
                obj => (float)nudAddDistance.Value;
            object copyHandler(object obj) => obj;
            albCrossSchemePileDistances.ElementCopying += copyHandler;
            albCrossSchemePileDistances.Text = " Расстояния между соседними балками, м ";
            Materials = materialManager.GetAll();
            FillEnumValues<SpanStructureSystem, SpanStructureSystemStrings>(cbSystem, true);
            FillEnumValues<SpanStructureType, SpanStructureTypeStrings>(flpSpanStructureType);
            FillEnumValues<ConstructionRoadway, ConstructionRoadwayStrings>(cbConstructionRoadway);
            FillEnumValues<JointType, JointTypeStrings>(flpJointType);
            FillEnumValues<BridgeMovablePartSupport, BridgeMovablePartSupportStrings>(cbSpanTypeMovable);
            FillEnumValues<BridgeMotionlessPartSupport, BridgeMotionlessPartSupportStrings>(cbSpanTypeMotionless);
            FillEnumValues<ExpansionJointType, ExpansionJointTypeStrings>(flpExpansionJointType, 
                (s,e)=> 
                {
                    pbExpansionJointType.Image = 
                        GetImageFromResourses<ExpansionJointType, ExpansionJointTypeStrings>(
                            (s as RadioButton).Text, "EJT_");
                }, toolTip1);
            FillEnumValues<CrossJoinMethod, CrossJoinMethodStrings>(cbCrossJoin);
            FillEnumValues<SpanBeamType, SpanBeamTypeStrings>(cbCrossPileType);
            FillEnumValues<SpanBeamType, SpanBeamTypeStrings>(cbLongitudinalPileType);
            FillEnumValues<SlopeProfile, SlopeProfileUserStrings>(cbSlopeLongitudinalProfile);
            typicalProjects = typicalProjectManager.GetAll().Where(tp => tp.Target == "Пролётные строения").ToList();
            cbTypicalProject.DataSource = typicalProjects;
            chbCrossPile.CheckedChanged += NullableClassCheckedChanged;
            chbLongitudinalPile.CheckedChanged += NullableClassCheckedChanged;
            tbMaterial.Text = spanStructure.Bridge.CoverTypeAsString;
            if (spanStructure.Bridge.LongitudeSchemeLm > 1e-5)
                tbLongitudeSchemeLm.Text = $"Lm={spanStructure.Bridge.LongitudeSchemeLm.ToString("F")}";
            else
                tbLongitudeSchemeLm.Text = "Lm не задан";
            tbWidthDimension.Text = spanStructure.Bridge.WidthDimensionAsString;
            Entity = spanStructure;
        }
        
        public SpanStructure Entity
        {
            get
            {
                _spanStructure.System = GetSelected<SpanStructureSystem, SpanStructureSystemStrings>(cbSystem);
                _spanStructure.SpanStructureType = GetSelected<SpanStructureType, SpanStructureTypeStrings>(flpSpanStructureType);
                _spanStructure.ConstructionRoadway = GetSelected<ConstructionRoadway, ConstructionRoadwayStrings>(cbConstructionRoadway);
                _spanStructure.Material = GetObject<Material>(cbMaterial);
                _spanStructure.JointType = GetSelected<JointType, JointTypeStrings>(flpJointType);
                _spanStructure.LongitudeScheme = tbLongitudeScheme.Text;
                _spanStructure.ConstructionDate = GetDate(dtpConstructionDate);
                _spanStructure.TypicalProject = GetObject<TypicalProject>(cbTypicalProject);
                _spanStructure.SpanTypeMovable = GetSelected<BridgeMovablePartSupport, BridgeMovablePartSupportStrings>(cbSpanTypeMovable);
                _spanStructure.SpanTypeMotionless = GetSelected<BridgeMotionlessPartSupport, BridgeMotionlessPartSupportStrings>(cbSpanTypeMotionless);
                _spanStructure.ExpansionJointType = GetSelected<ExpansionJointType, ExpansionJointTypeStrings>(flpExpansionJointType);
                _spanStructure.ExpansionJointAddInfo = tbExpansionJointAddInfo.Text;
                _spanStructure.CrossJoin = GetSelected<CrossJoinMethod, CrossJoinMethodStrings>(cbCrossJoin);
                _spanStructure.CrossSchemeKa = (float)nudCrossSchemeKa.Value;
                _spanStructure.CrossSchemeKb = (float)nudCrossSchemeKb.Value;
                var distances = GetObjects<float>(albCrossSchemePileDistances);
                if (distances != null && distances.Count > 0)
                {
                    _spanStructure.CrossSchemePileDistances = distances.ToArray();
                }
                _spanStructure.PlateMaterial = GetObject<Material>(cbPlateMaterial);
                _spanStructure.PlateThickness = (float)nudPlateThickness.Value;
                _spanStructure.RoadwayClothingThickness = (float)nudRoadwayClothingThickness.Value;
                _spanStructure.RoadwayClothingAddLayerThickness = GetNullable<float>(nudRoadwayClothingAddLayerThickness, chbRoadwayClothingAddLayerThickness);
                _spanStructure.RoadwayClothingAddLayerWeight = GetNullable<float>(nudRoadwayClothingAddLayerWeight, chbRoadwayClothingAddLayerWeight);
                _spanStructure.MainPileCount = (int)nudMainPileCount.Value;
                _spanStructure.MainPileHeightSpan = (float)nudMainPileHeightSpan.Value;
                _spanStructure.MainPileHeightSupport = (float)nudMainPileHeightSupport.Value;
                _spanStructure.MainPileThicknessEdge = (float)nudMainPileThicknessEdge.Value;
                _spanStructure.CrossPile = CrossPile;
                _spanStructure.LongitudinalPile = LongitudinalPile;
                _spanStructure.AdditionalLinearLoad = (float)nudAdditionalLinearLoad.Value;
                _spanStructure.Notes = tbNotes.Text;
                _spanStructure.UnderbridgeClearance = (float)nudUnderbridgeClearance.Value;
                _spanStructure.SlopeLongitudinal = (float)nudSlopeLongitudinalProfile.Value;
                _spanStructure.SlopeLongitudinalProfile = GetSelected<SlopeProfile, SlopeProfileUserStrings>(cbSlopeLongitudinalProfile);
                return _spanStructure;
            }
            set
            {
                _spanStructure = value;
                if (_spanStructure != null)
                {
                    SelectEnumElement(_spanStructure.SystemAsString, cbSystem);
                    SelectEnumElement(_spanStructure.SpanStructureTypeAsString, flpSpanStructureType);
                    SelectEnumElement(_spanStructure.ConstructionRoadwayAsString, cbConstructionRoadway);
                    SetObject(cbMaterial, _spanStructure.Material);
                    SelectEnumElement(_spanStructure.JointTypeAsString, flpJointType);
                    tbLongitudeScheme.Text = _spanStructure.LongitudeScheme;
                    SetDate(dtpConstructionDate, _spanStructure.ConstructionDate);
                    SetObject(cbTypicalProject, _spanStructure.TypicalProject);
                    SelectEnumElement(_spanStructure.SpanTypeMovableAsString, cbSpanTypeMovable);
                    SelectEnumElement(_spanStructure.SpanTypeMotionlessAsString, cbSpanTypeMotionless);
                    SelectEnumElement(_spanStructure.ExpansionJointTypeAsString, flpExpansionJointType);
                    tbExpansionJointAddInfo.Text = _spanStructure.ExpansionJointAddInfo;
                    SelectEnumElement(_spanStructure.CrossJoinAsString, cbCrossJoin);
                    nudCrossSchemeKa.Value = (decimal)_spanStructure.CrossSchemeKa;
                    nudCrossSchemeKb.Value = (decimal)_spanStructure.CrossSchemeKb;
                    SetObjects(_spanStructure.CrossSchemePileDistances, albCrossSchemePileDistances);
                    SetObject(cbPlateMaterial, _spanStructure.PlateMaterial);
                    nudPlateThickness.Value = (decimal)_spanStructure.PlateThickness;
                    nudRoadwayClothingThickness.Value = (decimal)_spanStructure.RoadwayClothingThickness;
                    SetNullable(_spanStructure.RoadwayClothingAddLayerThickness, nudRoadwayClothingAddLayerThickness, chbRoadwayClothingAddLayerThickness);
                    SetNullable(_spanStructure.RoadwayClothingAddLayerWeight, nudRoadwayClothingAddLayerWeight, chbRoadwayClothingAddLayerWeight);
                    nudMainPileCount.Value = _spanStructure.MainPileCount;
                    nudMainPileHeightSpan.Value = (decimal)_spanStructure.MainPileHeightSpan;
                    nudMainPileHeightSupport.Value = (decimal)_spanStructure.MainPileHeightSupport;
                    nudMainPileThicknessEdge.Value = (decimal)_spanStructure.MainPileThicknessEdge;
                    CrossPile = _spanStructure.CrossPile;
                    LongitudinalPile = _spanStructure.LongitudinalPile;
                    nudAdditionalLinearLoad.Value = (decimal)_spanStructure.AdditionalLinearLoad;
                    tbNotes.Text = _spanStructure.Notes;
                    nudUnderbridgeClearance.Value = (decimal)_spanStructure.UnderbridgeClearance;
                    nudSlopeLongitudinalProfile.Value = (decimal)_spanStructure.SlopeLongitudinal;
                    SelectEnumElement(_spanStructure.SlopeLongitudinalProfileAsString, cbSlopeLongitudinalProfile);
                }
            }
        }
        public SpanBeam CrossPile
        {
            get
            {
                if (chbCrossPile.Checked)
                {
                    if (_crossPile == null)
                    {
                        _crossPile = new SpanBeam();
                    }
                    _crossPile.Type = GetSelected<SpanBeamType, SpanBeamTypeStrings>(cbCrossPileType);
                    _crossPile.CountInSpan = (int)nudCrossPileCountInSpan.Value;
                    _crossPile.Height = (float)nudCrossPileHeight.Value;
                    _crossPile.Material = GetObject<Material>(cbCrossPileMaterial);
                }
                else
                    _crossPile = null;
                return _crossPile;
            }
            set
            {
                _crossPile = value;
                if (_crossPile != null)
                {
                    chbCrossPile.Checked = true;
                    SelectEnumElement(_crossPile.TypeAsString, cbCrossPileType);
                    nudCrossPileCountInSpan.Value = _crossPile.CountInSpan;
                    nudCrossPileHeight.Value = (decimal)_crossPile.Height;
                    SetObject(cbCrossPileMaterial, _crossPile.Material);
                }
                else
                {
                    chbCrossPile.Checked = false;
                }
            }
        }
        public SpanBeam LongitudinalPile
        {
            get
            {
                if (chbLongitudinalPile.Checked)
                {
                    if (_longitudinalPile == null)
                    {
                        _longitudinalPile = new SpanBeam();
                    }
                    _longitudinalPile.Type = GetSelected<SpanBeamType, SpanBeamTypeStrings>(cbLongitudinalPileType);
                    _longitudinalPile.CountInSpan = (int)nudLongitudinalPileCountInSpan.Value;
                    _longitudinalPile.Height = (float)nudLongitudinalPileHeight.Value;
                    _longitudinalPile.Material = GetObject<Material>(cbLongitudinalPileMaterial);
                }
                else
                    _longitudinalPile = null;
                return _longitudinalPile;
            }
            set
            {
                _longitudinalPile = value;
                if (_longitudinalPile != null)
                {
                    chbLongitudinalPile.Checked = true;
                    SelectEnumElement(_longitudinalPile.TypeAsString, cbLongitudinalPileType);
                    nudLongitudinalPileCountInSpan.Value = _longitudinalPile.CountInSpan;
                    nudLongitudinalPileHeight.Value = (decimal)_longitudinalPile.Height;
                    SetObject(cbLongitudinalPileMaterial, _longitudinalPile.Material);
                }
                else
                {
                    chbLongitudinalPile.Checked = false;
                }
            }
        }
        private IList<Material> Materials
        {
            set
            {
                cbMaterial.DataSource = value;
                cbPlateMaterial.DataSource = value.ToList();
                cbCrossPileMaterial.DataSource = value.ToList();
                cbLongitudinalPileMaterial.DataSource = value.ToList();
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

        private void cbSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbSystem.Image =
                GetImageFromResourses<SpanStructureSystem, SpanStructureSystemStrings>(
                    cbSystem.SelectedItem.ToString());
        }

        private void chbRoadwayClothingAddLayerThickness_CheckedChanged(object sender, EventArgs e)
        {
            nudRoadwayClothingAddLayerThickness.Enabled = (sender as CheckBox).Checked;
        }

        private void chbRoadwayClothingAddLayerWeight_CheckedChanged(object sender, EventArgs e)
        {
            nudRoadwayClothingAddLayerWeight.Enabled = (sender as CheckBox).Checked;
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
                    SetObject(cbTypicalProject, _spanStructure.TypicalProject);
                }
            }
        }

        private void cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            var cb = sender as ComboBox;
            string text = cb.GetItemText(cb.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, br, e.Bounds);
            }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                toolTip1.Show(text, cb, e.Bounds.Right, e.Bounds.Bottom);
            }
            else
            {
                toolTip1.Hide(cb);
            }
            e.DrawFocusRectangle();
        }

        private void cb_DropDownClosed(object sender, EventArgs e)
        {
            toolTip1.Hide(sender as ComboBox);
        }
    }
}
