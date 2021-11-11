using ITS.Client.Core.ViewInterfaces;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Bridges.Helpers;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.Core.Domain;
using ITS.Core.Domain.Organizations;
using ITS.Core.Domain.Photos;
using ITS.Core.ManagerInterfaces.Organizations;
using ITS.MapObjects.BridgesMapObject.Controls;
using ITS.MapObjects.BridgesMapObject.Helpers;
using ITS.MapObjects.BridgesMapObject.IViews;
using ITS.MapObjects.EditBaseDictionariesPlugin;
using ITS.MapObjects.EditBaseDictionariesPlugin.ViewInterfaces.Organizations;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static ITS.MapObjects.BridgesMapObject.Helpers.EditViewHelper;

namespace ITS.MapObjects.BridgesMapObject.Views
{
    public partial class BridgeEditView : BaseView, IBridgeEditView
    {
        #region Fields
        private Bridge _bridge;
        private Protection _protectionOnBridge;
        private Protection _protectionOnApproach;

        private readonly IBridgeManager _bridgeManager;
        private bool _isEdit;
        private IEditPhotoControl _photoControl;
        private readonly IOrganizationManager _organizationManager;
        private readonly IBridgeObstacleManager _bridgeObstacleManager;
        private readonly IBridgeSupportManager _bridgeSupportManager;
        private readonly ISpanStructureManager _spanStructureManager;
        private readonly IMaterialManager _materialManager;
        private readonly IDefectManager _defectManager;
        private readonly IDefectTypeManager _defectTypeManager;
        private readonly IDefectScrollSectionManager _defectScrollSectionManager;
        private readonly ITypicalProjectManager _typicalProjectManager;
        private readonly IInfoOfRepairsManager _infoOfRepairsManager;
        private readonly ITerritoryManager _territoryManager;
        private readonly IDocumentationInfoManager _documentationInfoManager;
        private IList<Organization> _organizations;
        private bool constructed = false;

        private List<DomainObject<long>> DeletedObjects { get; set; } = new List<DomainObject<long>>();
        #endregion

        public BridgeEditView(Bridge bridge, IBridgeManager bridgeManager, IOrganizationManager organizationManager,
            IBridgeObstacleManager bridgeObstacleManager, IBridgeSupportManager bridgeSupportManager, ISpanStructureManager spanStructureManager,
            IMaterialManager materialManager, IDefectManager defectManager, IDefectTypeManager defectTypeManager, IDefectScrollSectionManager defectScrollSectionManager,
            ITypicalProjectManager typicalProjectManager, IInfoOfRepairsManager infoOfRepairsManager,
            ITerritoryManager territoryManager, IDocumentationInfoManager documentationInfoManager, IEditPhotoControl photoControl)
        {
            _bridgeManager = bridgeManager;
            _organizationManager = organizationManager;
            _bridgeObstacleManager = bridgeObstacleManager;
            _bridgeSupportManager = bridgeSupportManager;
            _spanStructureManager = spanStructureManager;
            _materialManager = materialManager;
            _defectManager = defectManager;
            _defectTypeManager = defectTypeManager;
            _defectScrollSectionManager = defectScrollSectionManager;
            _typicalProjectManager = typicalProjectManager;
            _infoOfRepairsManager = infoOfRepairsManager;
            _territoryManager = territoryManager;
            _documentationInfoManager = documentationInfoManager;
            InitializeComponent();
            clbArrangements.ItemCheck += clbFlagsWithNoneAndNoData_ItemCheck;
            clbCommunications.ItemCheck += clbFlagsWithNoneAndNoData_ItemCheck;
            clbRegulatoryStructures.ItemCheck += clbFlagsWithNoneAndNoData_ItemCheck;
            clbMoveType.ItemCheck += clbFlagsWithNoData_ItemCheck;
            tvConstructionType.ExpandAll();
            void Remove(object obj) => DeletedObjects.Add(obj as DomainObject<long>);
            albBridgeObstacles.ElementRemoving += Remove;
            atvSpanStructures.ElementRemoving += Remove;
            atvSupports.ElementRemoving += Remove;
            albDefects.ElementRemoving += Remove;
            atvDocumentations.ElementRemoving += Remove;
            albInfoOfRepairs.ElementRemoving += Remove;
            atvSpanStructures.ItemsChanged += () =>
            {
                _bridge.SpanStructures = GetObjects<SpanStructure>(atvSpanStructures);
                SetFieldsDependsOnSpanStructures(_bridge);
            };
            albBridgeObstacles.ItemsChanged += () =>
            {
                _bridge.Obstacles = GetObjects<BridgeObstacle>(albBridgeObstacles);
                SetBridgeFullName(_bridge);
            };
            atvSupports.ConvertingToTreeNode += obj => BridgeSupportTreeCreator.GetTreeNode(obj as BridgeSupport);
            atvSpanStructures.ConvertingToTreeNode += obj => SpanStructureTreeCreator.GetTreeNode(obj as SpanStructure);
            atvDocumentations.ConvertingToTreeNode += obj => DocumentationInfoTreeCreator.GetTreeNode(obj as DocumentationInfo);
            atvSupports.ElementCopying += ElementCopying<BridgeSupport>;
            albBridgeObstacles.ElementCopying += ElementCopying<BridgeObstacle>;
            atvSpanStructures.ElementCopying += ElementCopying<SpanStructure>;
            albDefects.ElementCopying += ElementCopying<Defect>;
            atvDocumentations.ElementCopying += ElementCopying<DocumentationInfo>;
            albInfoOfRepairs.ElementCopying += ElementCopying<InfoOfRepairs>;
            albBridgeObstacles.Text = " Пересекаемые препятствия ";
            atvSupports.Text = " Опоры ";
            atvSpanStructures.Text = " Пролётные строения ";
            albDefects.Text = " Дефекты ";
            albInfoOfRepairs.Text = " Сведения о реконструкциях, ремонтах ";
            atvDocumentations.Text = " Имеющаяся техническая документация ";
            cbProtectionOnBridge.CheckedChanged += NullableClassCheckedChanged;
            cbProtectionOnApproach.CheckedChanged += NullableClassCheckedChanged;
            FillEnumValues<Quality, QualityStrings>(cbQualityBridge);
            //Тип движения зависит от типа моста, поэтому заполнение идёт в обработчике выбора типа
            //FillEnumValues<MoveType, MoveTypeStrings>(clbMoveType, true);
            FillEnumValues<CoverType, CoverTypeStrings>(cbCoverType);
            FillEnumValues<DrainageType, DrainageTypeStrings>(cbDrainageType);
            FillEnumValues<SlopeProfile, SlopeProfileUserStrings>(cbSlopeLongitudinalProfileBefore);
            FillEnumValues<SlopeProfile, SlopeProfileUserStrings>(cbSlopeLongitudinalProfileAfter);
            FillEnumValues<SlopeProfile, SlopeProfileUserStrings>(cbSlopeLateralProfile);
            FillEnumValues<Arrangements, ArrangementsStrings>(clbArrangements, true);
            FillEnumValues<Communications, CommunicationsStrings>(clbCommunications, true);
            FillEnumValues<ProtectionType, ProtectionTypeStrings>(flpProtectionTypeOnBridge);
            FillEnumValues<ProtectionType, ProtectionTypeStrings>(flpProtectionTypeOnApproach);
            FillEnumValues<SidewalkType, SidewalkTypeStrings>(flpSidewalks, toolTip1);
            FillEnumValues<RailingsType, RailingsTypeStrings>(flpRailings);
            FillEnumValues<RegulatoryStructures, RegulatoryStructuresStrings>(clbRegulatoryStructures, true);
            FillEnumValues<Strenghtening, StrenghteningStrings>(flpConesStrengthening, toolTip1);
            FillEnumValues<AdapterPlatesAvailability, AdapterPlatesAvailabilityStrings>(flpAdapterPlatesAvailability,
                checkedChangedHandler: (s, e) =>
                {
                    var rb = s as RadioButton;
                    if (rb.Checked)
                    {
                        switch (rb.Text)
                        {
                            case "Есть":
                                chbAdapterPlatesLength.Checked = true;
                                break;
                            case "Нет":
                            case "Нет данных":
                                chbAdapterPlatesLength.Checked = false;
                                break;
                        }
                    }
                });
            FillEnumValues<LocationInPlan, LocationInPlanStrings>(flpLocationInPlan);
            cbDesignBurden.DataSource = DesignBurdensInfo.DesignBurdens;
            cbTerritory.DataSource = _territoryManager.GetAll();

            _photoControl = photoControl;
            var control = (Control)_photoControl;
            control.Dock = DockStyle.Fill;
            tpPhotos.Controls.Add(control);
            SetFieldsDependsOnSpanStructures(bridge);

            Entity = bridge;
            GetPhoto += () => StartLoadPhotos(_bridge);
            _isEdit = !bridge.IsTransient();
            constructed = true;
        }

        private void SetFieldsDependsOnSpanStructures(Bridge bridge)
        {
            tbExpansionJointTypes.Text = bridge.ExpansionJointsTypes;
            tbLongitudeScheme.Text = bridge.LongitudeScheme;
            var undClr = bridge.UnderbridgeClearance;
            lbUnderbridgeClearance.Text = undClr;
            toolTip1.SetToolTip(lbUnderbridgeClearance, undClr);
            var slopeLong = bridge.SlopeLongitudinalForReport;
            lbSlopeLongitudinalForReport.Text = slopeLong;
            toolTip1.SetToolTip(lbSlopeLongitudinalForReport, slopeLong);
        }

        private void SetBridgeFullName(Bridge bridge)
        {
            var bridgeFullName = bridge.ConstructionAsString;
            if (bridge.Obstacles.Count > 1)
            {
                bridgeFullName += $" через препятствия: {bridge.ObstaclesAsString}";
            }
            else if (bridge.Obstacles != null && bridge.Obstacles.Count > 0)
            {
                bridgeFullName += $" через препятствие: {bridge.ObstaclesAsString}";
            }
            tbBridgeFullName.Text = bridgeFullName;
        }

        #region Properties
        public Bridge Entity
        {
            get
            {
                if (rbOne.Checked)
                {
                    _bridge.IsLeft = null;
                }
                else if (rbLeft.Checked)
                {
                    _bridge.IsLeft = true;
                }
                else if (rbRight.Checked)
                {
                    _bridge.IsLeft = false;
                }
                _bridge.IsOverTheRoad = chbIsOverTheRoad.Checked;
                _bridge.ConstructionType = GetSelected<BridgeType, BridgeTypeStrings>(tvConstructionType);
                _bridge.ConstructionName = tbConstructionName.Text;
                _bridge.Obstacles = GetObjects<BridgeObstacle>(albBridgeObstacles);
                _bridge.RoadName = tbRoadName.Text;
                _bridge.SubjectCode = (short)nudSubjectCode.Value;
                _bridge.TerritorialRoadControlCode = (int)nudRoadControlCode.Value;
                _bridge.RoadCode = (int)nudRoadCode.Value;
                _bridge.Kilometer = ((int)nudKilometrКМ.Value * 1000) + (int)nudKilometrМ.Value;
                _bridge.Territory = GetObject<Territory>(cbTerritory);
                _bridge.RoadCategory = GetSelected<RoadCategory, RoadCategoryStrings>(gbRoadCategory);
                _bridge.QuantityLineBridge = (int)nudQuantityLineBridge.Value;
                _bridge.QuantityLineApproach = (int)nudQuantityLineApproach.Value;
                _bridge.Markup = cbMarkup.Checked;
                _bridge.NearestVillage = tbNearestVillage.Text;
                _bridge.DistanceToVillage = (float)nudDistanceToVillageKM.Value;
                _bridge.CharactObstacleB = (float)nudCharactObstacleB.Value;
                _bridge.CharactObstacleH = (float)nudCharactObstacleH.Value;
                _bridge.CharactObstacleV = (float)nudCharactObstacleV.Value;
                _bridge.CharactObstacleDirectionOfFlow = chbCharactObstacleDirectionOfFlow.Checked;
                _bridge.Length = (float)nudLength.Value;
                _bridge.Hole = (float)nudHole.Value;
                _bridge.HeightDimension = GetNullable<float>(nudHeightDimension, chbHeightDimension);
                _bridge.WidthDimensionB = (float)nudWidthDimensionB.Value;
                _bridge.WidthDimensionT1 = (float)nudWidthDimensionT1.Value;
                _bridge.WidthDimensionT2 = (float)nudWidthDimensionT2.Value;
                _bridge.WidthDimensionC = (float)nudWidthDimensionC.Value;
                _bridge.WidthDimensionC1 = (float)nudWidthDimensionC1.Value;
                _bridge.WidthDimensionC2 = (float)nudWidthDimensionC2.Value;
                _bridge.WidthDimensionG = (float)nudWidthDimensionG.Value;
                _bridge.WidthDimensionBrivewayCount = (int)nudWidthDimensionBrivewayCount.Value;
                _bridge.ConstructionDate = GetDate(dtpConstructionDate);
                _bridge.RepairsDate = GetDate(dtpRepairsDate);
                _bridge.DesignBurden = tbDesignBurden.Text;
                _bridge.LongitudeSchemeLm = (float)nudLongitudeSchemeLm.Value;
                _bridge.ObliqueAngle = (float)nudObliqueAngle.Value;
                _bridge.LocationInPlan = GetSelected<LocationInPlan, LocationInPlanStrings>(flpLocationInPlan);
                _bridge.SlopeLateral = (float)nudSlopeLateralProfile.Value;
                _bridge.SlopeLateralProfile = GetSelected<SlopeProfile, SlopeProfileUserStrings>(cbSlopeLateralProfile);
                _bridge.CoverType = GetSelected<CoverType, CoverTypeStrings>(cbCoverType);
                _bridge.ProtectionOnBridge = ProtectionOnBridge;
                _bridge.ProtectionOnApproach = ProtectionOnApproach;
                _bridge.Sidewalks = GetSelected<SidewalkType, SidewalkTypeStrings>(flpSidewalks);
                _bridge.RailingsType = GetSelected<RailingsType, RailingsTypeStrings>(flpRailings);
                _bridge.RailingsHeight = (float)nudRailingsHeight.Value;
                _bridge.CarriagewayWidthBefore = (float)nudCarriagewayWidthBefore.Value;
                _bridge.SlopeLongitudinalBefore = (float)nudSlopeLongitudinalBefore.Value;
                _bridge.SlopeLongitudinalProfileBefore = GetSelected<SlopeProfile, SlopeProfileUserStrings>(cbSlopeLongitudinalProfileBefore);
                _bridge.EmbankmentHeightBefore = (float)nudEmbankmentHeightBefore.Value;
                _bridge.CarriagewayWidthAfter = (float)nudCarriagewayWidthAfter.Value;
                _bridge.SlopeLongitudinalAfter = (float)nudSlopeLongitudinalAfter.Value;
                _bridge.SlopeLongitudinalProfileAfter = GetSelected<SlopeProfile, SlopeProfileUserStrings>(cbSlopeLongitudinalProfileAfter);
                _bridge.EmbankmentHeightAfter = (float)nudEmbankmentHeightAfter.Value;
                _bridge.RegulatoryStructures = GetSelected<RegulatoryStructures, RegulatoryStructuresStrings>(clbRegulatoryStructures);
                _bridge.ConesStrengthening = GetSelected<Strenghtening, StrenghteningStrings>(flpConesStrengthening);
                _bridge.AdapterPlatesAvailability = GetSelected<AdapterPlatesAvailability, AdapterPlatesAvailabilityStrings>(flpAdapterPlatesAvailability);
                _bridge.AdapterPlatesLength = GetNullable<float>(nudAdapterPlatesLength, chbAdapterPlatesLength);
                _bridge.RoadSignsBefore = tbRoadSignsBefore.Text;
                _bridge.RoadSignsAfter = tbRoadSignsAfter.Text;
                _bridge.InfoOfRepairs = GetObjects<InfoOfRepairs>(albInfoOfRepairs);
                _bridge.Communications = GetSelected<Communications, CommunicationsStrings>(clbCommunications);
                _bridge.Arrangements = GetSelected<Arrangements, ArrangementsStrings>(clbArrangements);
                _bridge.DateView = GetDate(dtpDateView);
                _bridge.Notes = tbNotes.Text;
                _bridge.Supports = GetObjects<BridgeSupport>(atvSupports);
                _bridge.SpanStructures = GetObjects<SpanStructure>(atvSpanStructures);
                _bridge.Status = GetSelected<BridgeStatus, BridgeStatusStrings>(gbStatus);
                _bridge.QualityBridgeType = GetSelected<Quality, QualityStrings>(cbQualityBridge);
                _bridge.MoveType = GetSelected<MoveType, MoveTypeStrings>(clbMoveType);
                _bridge.HeightLevelNumber = (int)nudHeightLevelNumber.Value;
                _bridge.Defects = GetObjects<Defect>(albDefects);
                _bridge.Documentations = GetObjects<DocumentationInfo>(atvDocumentations);
                _bridge.InversedStartOfBridge = chbInversedStartOfBridge.Checked;
                _bridge.CharactObstacleAddInfo = tbCharactObstacleAddInfo.Text;
                _bridge.Photos = _photoControl.PhotoList;
                return _bridge;
            }
            set
            {
                _bridge = value;
                if (_bridge != null)
                {
                    if (_bridge.IsLeft == null)
                    {
                        rbOne.Checked = true;
                    }
                    else if (_bridge.IsLeft.Value)
                    {
                        rbLeft.Checked = true;
                    }
                    else
                    {
                        rbRight.Checked = true;
                    }
                    chbIsOverTheRoad.Checked = _bridge.IsOverTheRoad;
                    SelectEnumElement(_bridge.ConstructionTypeAsString.ToUpper(), tvConstructionType);
                    tbConstructionName.Text = _bridge.ConstructionName;
                    SetObjects(_bridge.Obstacles, albBridgeObstacles);
                    tbRoadName.Text = _bridge.RoadName;
                    nudSubjectCode.Value = _bridge.SubjectCode;
                    nudRoadControlCode.Value = _bridge.TerritorialRoadControlCode;
                    nudRoadCode.Value = _bridge.RoadCode;
                    nudKilometrКМ.Value = _bridge.Kilometer / 1000;
                    nudKilometrМ.Value = _bridge.Kilometer % 1000;
                    SetObject(cbTerritory, _bridge.Territory);
                    SelectEnumElement(_bridge.RoadCategoryAsString, gbRoadCategory);
                    nudQuantityLineBridge.Value = _bridge.QuantityLineBridge;
                    nudQuantityLineApproach.Value = _bridge.QuantityLineApproach;
                    cbMarkup.Checked = _bridge.Markup;
                    tbNearestVillage.Text = _bridge.NearestVillage;
                    nudDistanceToVillageKM.Value = (decimal)_bridge.DistanceToVillage;
                    nudCharactObstacleB.Value = (decimal)_bridge.CharactObstacleB;
                    nudCharactObstacleH.Value = (decimal)_bridge.CharactObstacleH;
                    nudCharactObstacleV.Value = (decimal)_bridge.CharactObstacleV;
                    chbCharactObstacleDirectionOfFlow.Checked = _bridge.CharactObstacleDirectionOfFlow;
                    nudLength.Value = (decimal)_bridge.Length;
                    nudHole.Value = (decimal)_bridge.Hole;
                    SetNullable(_bridge.HeightDimension, nudHeightDimension, chbHeightDimension);
                    nudWidthDimensionB.Value = (decimal)_bridge.WidthDimensionB;
                    nudWidthDimensionT1.Value = (decimal)_bridge.WidthDimensionT1;
                    nudWidthDimensionT2.Value = (decimal)_bridge.WidthDimensionT2;
                    nudWidthDimensionC.Value = (decimal)_bridge.WidthDimensionC;
                    nudWidthDimensionC1.Value = (decimal)_bridge.WidthDimensionC1;
                    nudWidthDimensionC2.Value = (decimal)_bridge.WidthDimensionC2;
                    nudWidthDimensionG.Value = (decimal)_bridge.WidthDimensionG;
                    nudWidthDimensionBrivewayCount.Value = _bridge.WidthDimensionBrivewayCount;
                    SetDate(dtpConstructionDate, _bridge.ConstructionDate);
                    SetDate(dtpRepairsDate, _bridge.RepairsDate);
                    tbDesignBurden.Text = _bridge.DesignBurden;
                    nudLongitudeSchemeLm.Value = (decimal)_bridge.LongitudeSchemeLm;
                    nudObliqueAngle.Value = (decimal)_bridge.ObliqueAngle;
                    SelectEnumElement(_bridge.LocationInPlanAsString, flpLocationInPlan);
                    nudSlopeLateralProfile.Value = (decimal)_bridge.SlopeLateral;
                    SelectEnumElement(_bridge.SlopeLateralProfileAsString, cbSlopeLateralProfile);
                    SelectEnumElement(_bridge.CoverTypeAsString, cbCoverType);
                    ProtectionOnBridge = _bridge.ProtectionOnBridge;
                    ProtectionOnApproach = _bridge.ProtectionOnApproach;
                    SelectEnumElement(_bridge.SidewalksAsString, flpSidewalks);
                    SelectEnumElement(_bridge.RailingsTypeAsString, flpRailings);
                    nudRailingsHeight.Value = (decimal)_bridge.RailingsHeight;
                    nudCarriagewayWidthBefore.Value = (decimal)_bridge.CarriagewayWidthBefore;
                    nudSlopeLongitudinalBefore.Value = (decimal)_bridge.SlopeLongitudinalBefore;
                    SelectEnumElement(_bridge.SlopeLongitudinalProfileBeforeAsString, cbSlopeLongitudinalProfileBefore);
                    nudEmbankmentHeightBefore.Value = (decimal)_bridge.EmbankmentHeightBefore;
                    nudCarriagewayWidthAfter.Value = (decimal)_bridge.CarriagewayWidthAfter;
                    nudSlopeLongitudinalAfter.Value = (decimal)_bridge.SlopeLongitudinalAfter;
                    SelectEnumElement(_bridge.SlopeLongitudinalProfileAfterAsString, cbSlopeLongitudinalProfileAfter);
                    nudEmbankmentHeightAfter.Value = (decimal)_bridge.EmbankmentHeightAfter;
                    SelectEnumElement(_bridge.RegulatoryStructuresAsString, clbRegulatoryStructures);
                    SelectEnumElement(_bridge.ConesStrengtheningAsString, flpConesStrengthening);
                    SelectEnumElement(_bridge.AdapterPlatesAvailabilityAsString, flpAdapterPlatesAvailability);
                    SetNullable(_bridge.AdapterPlatesLength, nudAdapterPlatesLength, chbAdapterPlatesLength);
                    if (_bridge.ProjectOrganization != null)
                    {
                        tbProjectOrganization.Text = _bridge.ProjectOrganization.ToString();
                    }
                    if (_bridge.BuildingOrganization != null)
                    {
                        tbBuildingOrganization.Text = _bridge.BuildingOrganization.ToString();
                    }
                    if (_bridge.ExploitOrganization != null)
                    {
                        tbExploitOrganization.Text = _bridge.ExploitOrganization.ToString();
                    }
                    tbRoadSignsBefore.Text = _bridge.RoadSignsBefore;
                    tbRoadSignsAfter.Text = _bridge.RoadSignsAfter;
                    SetObjects(_bridge.InfoOfRepairs, albInfoOfRepairs);
                    SelectEnumElement(_bridge.CommunicationsAsString, clbCommunications);
                    SelectEnumElement(_bridge.ArrangementsAsString, clbArrangements);
                    SetDate(dtpDateView, _bridge.DateView);
                    tbNotes.Text = _bridge.Notes;
                    SetObjects(_bridge.Supports, atvSupports);
                    SetObjects(_bridge.SpanStructures, atvSpanStructures);
                    SelectEnumElement(_bridge.StatusAsString, gbStatus);
                    SelectEnumElement(_bridge.MoveTypeAsString, clbMoveType);
                    SelectEnumElement(_bridge.QualityBridgeTypeAsString, cbQualityBridge);
                    nudHeightLevelNumber.Value = _bridge.HeightLevelNumber;
                    SetObjects(_bridge.Defects, albDefects);
                    SetObjects(_bridge.Documentations, atvDocumentations);
                    chbInversedStartOfBridge.Checked = _bridge.InversedStartOfBridge;
                    tbCharactObstacleAddInfo.Text = _bridge.CharactObstacleAddInfo;
                }
            }
        }
        public Protection ProtectionOnBridge
        {
            get
            {
                if (cbProtectionOnBridge.Checked)
                {
                    if (_protectionOnBridge == null)
                    {
                        _protectionOnBridge = new Protection();
                    }
                    _protectionOnBridge.Height = (float)nudProtectionHeightOnBridge.Value;
                    _protectionOnBridge.Type = GetSelected<ProtectionType, ProtectionTypeStrings>(flpProtectionTypeOnBridge);
                }
                else
                    _protectionOnBridge = null;
                return _protectionOnBridge;
            }
            set
            {
                _protectionOnBridge = value;
                if (_protectionOnBridge != null)
                {
                    cbProtectionOnBridge.Checked = true;
                    nudProtectionHeightOnBridge.Value = (decimal)_protectionOnBridge.Height;
                    SelectEnumElement(_protectionOnBridge.TypeAsString, flpProtectionTypeOnBridge);
                }
                else
                {
                    cbProtectionOnBridge.Checked = false;
                }
            }
        }
        public Protection ProtectionOnApproach
        {
            get
            {
                if (cbProtectionOnApproach.Checked)
                {
                    if (_protectionOnApproach == null)
                    {
                        _protectionOnApproach = new Protection();
                    }
                    _protectionOnApproach.Height = (float)nudProtectionHeightOnApproach.Value;
                    _protectionOnApproach.Type = GetSelected<ProtectionType, ProtectionTypeStrings>(flpProtectionTypeOnApproach);
                }
                else
                    _protectionOnApproach = null;
                return _protectionOnApproach;
            }
            set
            {
                _protectionOnApproach = value;
                if (_protectionOnApproach != null)
                {
                    cbProtectionOnApproach.Checked = true;
                    nudProtectionHeightOnApproach.Value = (decimal)_protectionOnApproach.Height;
                    SelectEnumElement(_protectionOnApproach.TypeAsString, flpProtectionTypeOnApproach);
                }
                else
                {
                    cbProtectionOnApproach.Checked = false;
                }
            }
        }
        #endregion

        public IList<Organization> GetOrganizations(string city)
        {
            return _organizations ?? (_organizations = _organizationManager.GetOrganizationByFilter(null, city));
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_bridgeManager != null)
            {
                if (!_isEdit)
                {
                    _bridgeManager.AddNew(Entity);
                }
                else
                {
                    _bridgeManager.Edit(Entity);
                }
            }
            RemoveFromDatabaseDeletedObjects();
            DialogResult = DialogResult.OK;
            CloseView();
        }

        private void RemoveFromDatabaseDeletedObjects()
        {
            foreach (var item in DeletedObjects)
            {
                if (!item.IsTransient())
                {
                    switch (item)
                    {
                        case BridgeObstacle bridgeObstacle:
                            _bridgeObstacleManager.Delete(bridgeObstacle);
                            break;
                        case BridgeSupport bridgeSupport:
                            _bridgeSupportManager.Delete(bridgeSupport);
                            break;
                        case SpanStructure spanStructure:
                            _spanStructureManager.Delete(spanStructure);
                            break;
                        case Defect defect:
                            _defectManager.Delete(defect);
                            break;
                        case InfoOfRepairs infoOfRepairs:
                            _infoOfRepairsManager.Delete(infoOfRepairs);
                            break;
                        case DocumentationInfo documentationInfo:
                            _documentationInfoManager.Delete(documentationInfo);
                            break;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            CloseView();
        }

        #region TreeView
        private void FillMoveTypes(BridgeType type, CheckedListBox checkedListBox)
        {
            IEnumerable<string> items = null;
            switch (type)
            {
                case BridgeType.CattleDrive:
                    items = items = Enum.GetValues(typeof(MoveType)).Cast<MoveType>()
                        .Where(mt => mt != MoveType.ForWaterSupply)
                        .Select(t => MoveTypeStrings.Instance.GetName(t));
                    break;
                case BridgeType.Aqueduct:
                    items = items = Enum.GetValues(typeof(MoveType)).Cast<MoveType>()
                        .Where(mt => mt != MoveType.ForAnimals)
                        .Select(t => MoveTypeStrings.Instance.GetName(t));
                    break;
                default:
                    items = Enum.GetValues(typeof(MoveType)).Cast<MoveType>()
                        .Where(mt => mt != MoveType.ForAnimals && mt != MoveType.ForWaterSupply)
                        .Select(t => MoveTypeStrings.Instance.GetName(t));
                    break;
            }
            checkedListBox.Items.Clear();
            checkedListBox.Items.AddRange(items.ToArray());
            //Нет данных - в конец списка
            checkedListBox.Items.Add(checkedListBox.Items[0]);
            checkedListBox.Items.RemoveAt(0);
        }
        private void tvConstructionType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tv = sender as TreeView;
            var text = tv.SelectedNode.Text;
            if (text == "МОСТОВЫЕ СООРУЖЕНИЯ")
            {
                FillColorAllNodes(tv.Nodes[0], Color.White, Color.Black);
                return;
            }
            if (text == "МОСТ" ||
                text == "РАЗВОДНОЙ МОСТ")
            {
                lbHole.Visible = nudHole.Visible = true;
                chbIsOverTheRoad.Visible = false;
            }
            else if (text == "ПУТЕПРОВОД")
            {
                lbHole.Visible = nudHole.Visible = false;
                chbIsOverTheRoad.Visible = true;
            }
            else
            {
                lbHole.Visible = nudHole.Visible = false;
                chbIsOverTheRoad.Visible = false;
            }
            //todo: GetSelected вызывается ещё раз в BridgeCodeChanged, это не рационально
            var type = GetSelected<BridgeType, BridgeTypeStrings>(tvConstructionType);
            pbBridgeType.Image = GetImageFromResourses<BridgeType, BridgeTypeStrings>(
                tvConstructionType.SelectedNode.Text);
            FillMoveTypes(type, clbMoveType);
            FillColorAllNodes(tv.Nodes[0], Color.White, Color.Black);
            FillColorNode(tv.SelectedNode, Color.Red, Color.White);
            BridgeCodeChanged(null, EventArgs.Empty);
            _bridge.ConstructionType = type;
            SetBridgeFullName(_bridge);
        }

        public void FillColorAllNodes(TreeNode treeNode, Color backColor, Color foreColor)
        {
            FillColorNode(treeNode, backColor, foreColor);
            if (treeNode.Nodes.Count != 0)
            {
                foreach (TreeNode node in treeNode.Nodes)
                {
                    FillColorAllNodes(node, backColor, foreColor);
                }
            }
        }

        public void FillColorNode(TreeNode treeNode, Color backColor, Color foreColor)
        {
            treeNode.BackColor = backColor;
            treeNode.ForeColor = foreColor;
        }
        #endregion

        #region Photos
        public event Action GetPhoto;
        public void StartLoadPhotos(Bridge bridge)
        {
            new Thread(() =>
            {
                IEnumerable<Photo> list;
                if (bridge.IsTransient())
                {
                    list = new List<Photo>();
                }
                else
                {
                    list = bridge.Photos ?? _bridgeManager.GetPhotosByBridge(bridge);
                }
                SetPhotoList(list);
            }).Start();
        }
        public void SetPhotoList(IEnumerable<Photo> list)
        {
            _photoControl.SetPhotoList(list);
        }
        #endregion

        private void BridgeEditView_Load(object sender, EventArgs e)
        {
            GetPhoto?.Invoke();
        }
        private void llEditExploitOrganization_Click(object sender, EventArgs e)
        {
            var toolName = EditBaseDictionariesPanelConfigResolver.ResourceManager.GetObject("ToolName");
            if (toolName == null) return;
            var organizationEditModel = ITS.ProjectBase.Utils.Container.Container.PluginContainer(toolName.ToString()).Resolve<ISelectOrganizationView>(
                new ParameterOverrides { { "organization", _bridge.ExploitOrganization ?? new Organization() } });
            if (organizationEditModel.ShowForm() == DialogResult.OK)
            {
                _bridge.ExploitOrganization = organizationEditModel.SelectedOrganization;

                tbExploitOrganization.Text = organizationEditModel.SelectedOrganization.ToString();
            }
        }
        private void llEditBuildingCompany_Click(object sender, EventArgs e)
        {
            var toolName = EditBaseDictionariesPanelConfigResolver.ResourceManager.GetObject("ToolName");
            if (toolName == null) return;
            var organizationEditModel = ITS.ProjectBase.Utils.Container.Container.PluginContainer(toolName.ToString()).Resolve<ISelectOrganizationView>(
                new ParameterOverrides { { "organization", _bridge.BuildingOrganization ?? new Organization() } });
            if (organizationEditModel.ShowForm() == DialogResult.OK)
            {
                _bridge.BuildingOrganization = organizationEditModel.SelectedOrganization;
                tbBuildingOrganization.Text = organizationEditModel.SelectedOrganization.ToString();
            }
        }
        private void llEditProjectOrganization_Click(object sender, EventArgs e)
        {
            var toolName = EditBaseDictionariesPanelConfigResolver.ResourceManager.GetObject("ToolName");
            if (toolName == null) return;
            var organizationEditModel = ITS.ProjectBase.Utils.Container.Container.PluginContainer(toolName.ToString()).Resolve<ISelectOrganizationView>(
                new ParameterOverrides { { "organization", _bridge.ProjectOrganization ?? new Organization() } });
            if (organizationEditModel.ShowForm() == DialogResult.OK)
            {
                _bridge.ProjectOrganization = organizationEditModel.SelectedOrganization;
                tbProjectOrganization.Text = organizationEditModel.SelectedOrganization.ToString();
            }
        }

        private void llClearExploitOrganization_Click(object sender, EventArgs e)
        {
            _bridge.ExploitOrganization = null;
            tbExploitOrganization.Text = "<Нет данных>";
        }
        private void llClearBuildingCompany_Click(object sender, EventArgs e)
        {
            _bridge.BuildingOrganization = null;
            tbBuildingOrganization.Text = "<Нет данных>";
        }
        private void llClearProjectOrganization_Click(object sender, EventArgs e)
        {
            _bridge.ProjectOrganization = null;
            tbProjectOrganization.Text = "<Нет данных>";
        }

        private void cbHeightDimension_CheckedChanged(object sender, EventArgs e)
        {
            nudHeightDimension.Enabled = (sender as CheckBox).Checked;
        }

        private void chbAdapterPlatesLength_CheckedChanged(object sender, EventArgs e)
        {
            nudAdapterPlatesLength.Enabled = (sender as CheckBox).Checked;
        }

        private object albBridgeObstacles_ElementAdding(object obj)
        {
            var obst = obj as BridgeObstacle ?? null;
            var currentType = GetSelected<BridgeType, BridgeTypeStrings>(tvConstructionType);
            var obstView = BridgeConstants.Container.Resolve<IBridgeObstacleEditView>(
                new ParameterOverride("bridgeObstacles", new List<BridgeObstacle>() { obst }),
                new ParameterOverride("bridge", _bridge),
                new ParameterOverride("obstacleTypes", BridgeTypeDependencies.GetAllowedObstacleTypes(currentType)),
                new ParameterOverride("formHeader", $"Препятствия сооружения {BridgeTypeStrings.Instance.GetName(currentType)}"));
            var res = obstView.ShowViewDialog();
            if (res == DialogResult.OK)
            {
                return obstView.Entity;
            }
            else
            {
                return null;
            }
        }
        private object albDefects_ElementAdding(object obj)
        {
            var obst = obj ?? (new Defect() { Bridge = _bridge });
            var obstView = BridgeConstants.Container.Resolve<IDefectEditView>(
                new ParameterOverride("defect", obst),
                new ParameterOverride("defectTypeManager", _defectTypeManager),
                new ParameterOverride("defectScrollSectionManager", _defectScrollSectionManager));
            var res = obstView.ShowViewDialog();
            if (res == DialogResult.OK)
            {
                return obstView.Entity;
            }
            else
            {
                return null;
            }
        }

        private INumberable atvSpanStructures_ElementAdding(INumberable obj)
        {
            var span = obj ?? (new SpanStructure() { Bridge = _bridge });
            var spanView = BridgeConstants.Container.Resolve<ISpanStructureEditView>(
                new ParameterOverride("spanStructure", span),
                new ParameterOverride("materialManager", _materialManager),
                new ParameterOverride("typicalProjectManager", _typicalProjectManager));
            var res = spanView.ShowViewDialog();
            if (res == DialogResult.OK)
            {
                return spanView.Entity;
            }
            else
            {
                return null;
            }
        }

        private INumberable atvSupports_ElementAdding(INumberable obj)
        {
            var sup = obj ?? (new BridgeSupport() { Bridge = _bridge });
            var supView = BridgeConstants.Container.Resolve<IBridgeSupportEditView>(
                new ParameterOverride("bridgeSupport", sup),
                new ParameterOverride("materialManager", _materialManager),
                new ParameterOverride("typicalProjectManager", _typicalProjectManager));
            var res = supView.ShowViewDialog();
            if (res == DialogResult.OK)
            {
                return supView.Entity;
            }
            else
            {
                return null;
            }
        }

        private object albInfoOfRepairs_ElementAdding(object obj)
        {
            var sup = obj ?? (new InfoOfRepairs() { Bridge = _bridge });
            var supView = BridgeConstants.Container.Resolve<IInfoOfRepairsEditView>(
                new ParameterOverride("infoOfRepairs", sup));
            var res = supView.ShowViewDialog();
            if (res == DialogResult.OK)
            {
                return supView.Entity;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Вызывается при изменении любых параметров, влияющих на код сооружения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BridgeCodeChanged(object sender, EventArgs e)
        {
            if (constructed)
            {
                bool? isLeft = null;
                if (rbLeft.Checked)
                {
                    isLeft = true;
                }
                else if (rbRight.Checked)
                {
                    isLeft = false;
                }
                string bridgeCode = Bridge.GetCode((int)nudRoadCode.Value,
                    chbIsOverTheRoad.Checked,
                    GetSelected<BridgeType, BridgeTypeStrings>(tvConstructionType),
                    ((int)nudKilometrКМ.Value * 1000) + (int)nudKilometrМ.Value,
                    isLeft);
                Text = "Мостовое сооружение: " + bridgeCode;
            }
        }

        private void cbDesignBurden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbDesignBurden.Text))
            {
                tbDesignBurden.Text += " ";
            }
            tbDesignBurden.Text += $"{cbDesignBurden.SelectedItem};";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbDesignBurden.Text = string.Empty;
        }

        private INumberable atvDocumentations_ElementAdding(INumberable obj)
        {
            var doc = obj ?? (new DocumentationInfo() { Bridge = _bridge });
            var docView = BridgeConstants.Container.Resolve<IDocumentationInfoEditView>(
                new ParameterOverride("documentationInfo", doc));
            var res = docView.ShowViewDialog();
            if (res == DialogResult.OK)
            {
                return docView.Entity;
            }
            else
            {
                return null;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                chbInversedStartOfBridge.Visible = !chbInversedStartOfBridge.Visible;
            }
        }

        private void cbDrainageType_DrawItem(object sender, DrawItemEventArgs e)
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

        private void cbDrainageType_DropDownClosed(object sender, EventArgs e)
        {
            toolTip1.Hide(sender as ComboBox);
        }

        private void rbIsLeftButtons_CheckedChanged(object sender, EventArgs e)
        {
            BridgeCodeChanged(null, EventArgs.Empty);
        }

        private void cbCoverType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_bridge != null)
            {
                _bridge.CoverType = GetSelected<CoverType, CoverTypeStrings>(cbCoverType);
            }
        }

        private void nudLongitudeSchemeLm_ValueChanged(object sender, EventArgs e)
        {
            if (_bridge != null)
            {
                _bridge.LongitudeSchemeLm = (float)nudLongitudeSchemeLm.Value;
                tbLongitudeScheme.Text = _bridge.LongitudeScheme;
            }
        }

        private void nudWidthDimensionB_ValueChanged(object sender, EventArgs e)
        {
            _bridge.WidthDimensionB = (float)(sender as NumericUpDown).Value;
        }

        private void nudWidthDimensionC_ValueChanged(object sender, EventArgs e)
        {
            _bridge.WidthDimensionC = (float)(sender as NumericUpDown).Value;
        }

        private void nudWidthDimensionG_ValueChanged(object sender, EventArgs e)
        {
            _bridge.WidthDimensionG = (float)(sender as NumericUpDown).Value;
        }

        private void nudWidthDimensionT1_ValueChanged(object sender, EventArgs e)
        {
            _bridge.WidthDimensionT1 = (float)(sender as NumericUpDown).Value;
        }

        private void nudWidthDimensionT2_ValueChanged(object sender, EventArgs e)
        {
            _bridge.WidthDimensionT2 = (float)(sender as NumericUpDown).Value;
        }

        private void nudWidthDimensionC1_ValueChanged(object sender, EventArgs e)
        {
            _bridge.WidthDimensionC1 = (float)(sender as NumericUpDown).Value;
        }

        private void nudWidthDimensionC2_ValueChanged(object sender, EventArgs e)
        {
            _bridge.WidthDimensionC2 = (float)(sender as NumericUpDown).Value;
        }

        private void nudWidthDimensionBrivewayCount_ValueChanged(object sender, EventArgs e)
        {
            _bridge.WidthDimensionBrivewayCount = (int)(sender as NumericUpDown).Value;
        }

        private void tbConstructionName_Leave(object sender, EventArgs e)
        {
            if (_bridge != null)
            {
                _bridge.ConstructionName = (sender as TextBox).Text;
                SetBridgeFullName(_bridge);
            }
        }

        //private void chbInversedStartOfBridge_CheckedChanged(object sender, EventArgs e)
        //{
        //    //todo: Реализовать инвертирование
        //    //направление течения
        //    chbCharactObstacleDirectionOfFlow.Checked = !chbCharactObstacleDirectionOfFlow.Checked;
        //    //пролёты
        //    atvSpanStructures.Items.Reverse();
        //    for (int i = 0; i < atvSpanStructures.Items.Count; i++)
        //    {
        //        atvSpanStructures.Items[i].Number = atvSpanStructures.Items.Count - i;
        //    }
        //    //опоры
        //    atvSupports.Items.Reverse();
        //    for (int i = 0; i < atvSupports.Items.Count; i++)
        //    {
        //        atvSupports.Items[i].Number = atvSupports.Items.Count - i;
        //    }
        //    //todo: Продольная схема не инвертируется полностью, так как в пролётах записана строкой

        //    SwapNumbers(nudWidthDimensionC1, nudWidthDimensionC2);
        //    SwapNumbers(nudWidthDimensionT1, nudWidthDimensionT2);
        //}
    }
}