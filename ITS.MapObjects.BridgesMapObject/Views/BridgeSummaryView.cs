using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ITS.Client.Core.ViewInterfaces;
using ITS.Core.Bridges.Domain;
using ITS.MapObjects.BaseMapObject.FilterControls;
using ITS.MapObjects.BridgesMapObject.EventArgses;
using ITS.MapObjects.BridgesMapObject.IPresenters;
using ITS.MapObjects.BridgesMapObject.IViews;
using ITS.MapObjects.BridgesMapObject.Presenters;
using ITS.MapObjects.BridgesMapObject.Reports;
using Microsoft.Practices.Unity;

namespace ITS.MapObjects.BridgesMapObject.Views
{
    public partial class BridgeSummaryView : Form, IBridgeSummaryView
    {
        #region Private Fields and Consts
        private const string IDColumn = nameof(Bridge.ID);
        private const string ConstructionNameColumn = nameof(Bridge.ConstructionName);
        private const string ConstructionTypeColumn = nameof(Bridge.ConstructionType);
        private const string ObstaclesColumn = nameof(Bridge.Obstacles);
        private const string RoadNameColumn = nameof(Bridge.RoadName);
        private const string SubjectCodeColumn = nameof(Bridge.SubjectCode);
        private const string TerritorialRoadControlCodeColumn = nameof(Bridge.TerritorialRoadControlCode);
        private const string RoadCodeColumn = nameof(Bridge.RoadCode);
        private const string ExpandedRoadCodeColumn = nameof(Bridge.ExpandedRoadCode);
        private const string KilometerColumn = nameof(Bridge.Kilometer);
        private const string RoadCategoryColumn = nameof(Bridge.RoadCategory);
        private const string QuantityLineBridgeColumn = nameof(Bridge.QuantityLineBridge);
        private const string QuantityLineApproachColumn = nameof(Bridge.QuantityLineApproach);
        private const string MarkupColumn = nameof(Bridge.Markup);
        private const string NearestVillageColumn = nameof(Bridge.NearestVillage);
        private const string DistanceToVillageColumn = nameof(Bridge.DistanceToVillage);
        private const string CharactObstacleBColumn = nameof(Bridge.CharactObstacleB);
        private const string CharactObstacleHColumn = nameof(Bridge.CharactObstacleH);
        private const string CharactObstacleVColumn = nameof(Bridge.CharactObstacleV);
        private const string CharactObstacleDirectionOfFlowColumn = nameof(Bridge.CharactObstacleDirectionOfFlow);
        private const string UnderbridgeClearanceColumn = nameof(Bridge.UnderbridgeClearance);
        private const string LengthColumn = nameof(Bridge.Length);
        private const string HoleColumn = nameof(Bridge.Hole);
        private const string HeightDimensionColumn = nameof(Bridge.HeightDimension);
        private const string WidthDimensionBColumn = nameof(Bridge.WidthDimensionB);
        private const string WidthDimensionT1Column = nameof(Bridge.WidthDimensionT1);
        private const string WidthDimensionT2Column = nameof(Bridge.WidthDimensionT2);
        private const string WidthDimensionCColumn = nameof(Bridge.WidthDimensionC);
        private const string WidthDimensionC1Column = nameof(Bridge.WidthDimensionC1);
        private const string WidthDimensionC2Column = nameof(Bridge.WidthDimensionC2);
        private const string WidthDimensionВrivewayCountColumn = nameof(Bridge.WidthDimensionBrivewayCount);
        private const string WidthDimensionGColumn = nameof(Bridge.WidthDimensionG);
        private const string ConstructionDateColumn = nameof(Bridge.ConstructionDate);
        private const string ReconstructionDateColumn = nameof(Bridge.ReconstructionDate);
        private const string RepairsDateColumn = nameof(Bridge.RepairsDate);
        private const string DesignBurdenColumn = nameof(Bridge.DesignBurden);
        private const string LongitudeSchemeColumn = nameof(Bridge.LongitudeScheme);
        private const string ObliqueAngleColumn = nameof(Bridge.ObliqueAngle);
        private const string LocationInPlanColumn = nameof(Bridge.LocationInPlan);
        private const string SlopeLateralColumn = nameof(Bridge.SlopeLateral);
        private const string SlopeLateralProfileColumn = nameof(Bridge.SlopeLateralProfile);
        private const string CoverTypeColumn = nameof(Bridge.CoverType);
        private const string DrainageTypeColumn = nameof(Bridge.DrainageType);
        private const string ExpansionJointsTypesColumn = nameof(Bridge.ExpansionJointsTypes);
        private const string ProtectionOnBridgeColumn = nameof(Bridge.ProtectionOnBridge);
        private const string ProtectionOnApproachColumn = nameof(Bridge.ProtectionOnApproach);
        private const string SidewalksColumn = nameof(Bridge.Sidewalks);
        private const string RailingsTypeColumn = nameof(Bridge.RailingsType);
        private const string RailingsHeightColumn = nameof(Bridge.RailingsHeight);
        private const string CarriagewayWidthBeforeColumn = nameof(Bridge.CarriagewayWidthBefore);
        private const string SlopeLongitudinalBeforeColumn = nameof(Bridge.SlopeLongitudinalBefore);
        private const string SlopeLongitudinalProfileBeforeColumn = nameof(Bridge.SlopeLongitudinalProfileBefore);
        private const string EmbankmentHeightBeforeColumn = nameof(Bridge.EmbankmentHeightBefore);
        private const string CarriagewayWidthAfterColumn = nameof(Bridge.CarriagewayWidthAfter);
        private const string SlopeLongitudinalAfterColumn = nameof(Bridge.SlopeLongitudinalAfter);
        private const string SlopeLongitudinalProfileAfterColumn = nameof(Bridge.SlopeLongitudinalProfileAfter);
        private const string EmbankmentHeightAfterColumn = nameof(Bridge.EmbankmentHeightAfter);
        private const string RegulatoryStructuresColumn = nameof(Bridge.RegulatoryStructures);
        private const string ConesStrengtheningColumn = nameof(Bridge.ConesStrengthening);
        private const string AdapterPlatesAvailabilityColumn = nameof(Bridge.AdapterPlatesAvailability);
        private const string AdapterPlatesLengthColumn = nameof(Bridge.AdapterPlatesLength);
        private const string ProjectOrganizationColumn = nameof(Bridge.ProjectOrganization);
        private const string BuildingOrganizationColumn = nameof(Bridge.BuildingOrganization);
        private const string ExploitOrganizationColumn = nameof(Bridge.ExploitOrganization);
        //private const string RoadSignsBeforeColumn = nameof(Bridge.RoadSignsBefore);
        //private const string RoadSignsAfterColumn = nameof(Bridge.RoadSignsAfter);
        private const string InfoOfRepairsColumn = nameof(Bridge.InfoOfRepairs);
        private const string CommunicationsColumn = nameof(Bridge.Communications);
        private const string ArrangementsColumn = nameof(Bridge.Arrangements);
        private const string DateViewColumn = nameof(Bridge.DateView);
        private const string NotesColumn = nameof(Bridge.Notes);
        private const string SupportsColumn = nameof(Bridge.Supports);
        private const string SpanStructuresColumn = nameof(Bridge.SpanStructures);
        private const string StatusColumn = nameof(Bridge.Status);
        private const string QualityBridgeTypeColumn = nameof(Bridge.QualityBridgeType);
        private const string MoveTypeColumn = nameof(Bridge.MoveType);
        private const string HeightLevelNumberColumn = nameof(Bridge.HeightLevelNumber);
        private const string PhotosColumn = nameof(Bridge.Photos);
        private const string FeatureObjectColumn = nameof(Bridge.FeatureObject);
        private const string ConstructionAsStringColumn = nameof(Bridge.ConstructionAsString);
        private const string ObstaclesAsStringColumn = nameof(Bridge.ObstaclesAsString);
        private const string KilometerAsStringColumn = nameof(Bridge.KilometerAsString);
        private const string QuantityLineAsStringColumn = nameof(Bridge.QuantityLineAsString);
        private const string MarkupAsStringColumn = nameof(Bridge.MarkupAsString);
        private const string CharactObstacleDirectionFlowAsStringColumn = nameof(Bridge.CharactObstacleDirectionFlowAsString);
        private const string CharactObstacleAsStringColumn = nameof(Bridge.CharactObstacleAsString);
        private const string HeightDimensionAsStringColumn = nameof(Bridge.HeightDimensionAsString);
        private const string WidthDimensionAsStringColumn = nameof(Bridge.WidthDimensionAsString);
        private const string SlopeLongitudinalBeforeAsStringColumn = nameof(Bridge.SlopeLongitudinalBeforeAsString);
        private const string SlopeLongitudinalAfterAsStringColumn = nameof(Bridge.SlopeLongitudinalAfterAsString);
        private const string AdapterPlatesAvailabilityAsStringColumn = nameof(Bridge.AdapterPlatesAvailabilityAsString);
        private const string AdapterPlatesAsStringColumn = nameof(Bridge.AdapterPlatesAsString);
        private const string DefectsColumn = nameof(Bridge.Defects);

        private const string MoveTypeAsStringColumn = nameof(Bridge.MoveTypeAsString);
        private const string CommunicationsAsStringColumn = nameof(Bridge.CommunicationsAsString);
        private const string ArrangementsAsStringColumn = nameof(Bridge.ArrangementsAsString);
        private const string InfoOfRepairsForReportColumn = nameof(Bridge.InfoOfRepairsForReport);
        private const string RoadCategoryAsStringColumn = nameof(Bridge.RoadCategoryAsString);
        private const string LocationInPlanAsStringColumn = nameof(Bridge.LocationInPlanAsString);
        private const string SidewalksAsStringColumn = nameof(Bridge.SidewalksAsString);
        private const string RailingsUserAsStringColumn = nameof(Bridge.RailingsUserAsString);
        private const string RegulatoryStructuresAsStringColumn = nameof(Bridge.RegulatoryStructuresAsString);
        private const string ConesStrengtheningAsStringColumn = nameof(Bridge.ConesStrengtheningAsString);
        private const string CoverTypeAsStringColumn = nameof(Bridge.CoverTypeAsString);
        private const string SlopeLongitudinalProfileAfterAsStringColumn = nameof(Bridge.SlopeLongitudinalProfileAfterAsString);
        private const string SlopeLongitudinalProfileBeforeAsStringColumn = nameof(Bridge.SlopeLongitudinalProfileBeforeAsString);
        private const string ConstructionTypeAsStringColumn = nameof(Bridge.ConstructionTypeAsString);
        private const string SlopeLateralProfileAsStringColumn = nameof(Bridge.SlopeLateralProfileAsString);
        private const string QualityBridgeTypeAsStringColumn = nameof(Bridge.QualityBridgeTypeAsString);
        private const string DrainageTypeAsStringColumn = nameof(Bridge.DrainageTypeAsString);
        private const string RailingsTypeAsStringColumn = nameof(Bridge.RailingsTypeAsString);
        private const string StatusAsStringColumn = nameof(Bridge.StatusAsString);
        private const string PhotoableTypeColumn = nameof(Bridge.PhotoableType);

        private const string InfoOfRepairsForReportTypeColumn = nameof(Bridge.InfoOfRepairsForReport);
        private const string SlopeLateralForReportColumn = nameof(Bridge.SlopeLateralForReport);
        private const string SlopeLongitudinalForReportColumn = nameof(Bridge.SlopeLongitudinalForReport);
        private const string TerritoryColumn = nameof(Bridge.Territory);
        private const string IsLeftColumn = nameof(Bridge.IsLeft);
        private const string IsOverTheRoadColumn = nameof(Bridge.IsOverTheRoad);
        private const string BridgeCodeColumn = nameof(Bridge.BridgeCode);
        private const string DocumentationsColumn = nameof(Bridge.Documentations);
        private const string InversedStartOfBridgeColumn = nameof(Bridge.InversedStartOfBridge);
        private const string LongitudeSchemeLmColumn = nameof(Bridge.LongitudeSchemeLm);
        private const string RoadSignsBeforeColumn = nameof(Bridge.RoadSignsBefore);
        private const string RoadSignsAfterColumn = nameof(Bridge.RoadSignsAfter);
        private const string CharactObstacleAddInfoColumn = nameof(Bridge.CharactObstacleAddInfo);

        private static readonly Dictionary<string, string> BridgeColumnHeaders;
        private static readonly Dictionary<string, int> BridgeColumnWidths;
        private IEnumerable<Bridge> _model;

        #endregion

        #region Win32API

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("USER32.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern IntPtr SetFocus(IntPtr hwnd);

        #endregion

        static BridgeSummaryView()
        {
            BridgeColumnHeaders = new Dictionary<string, string>();
            BridgeColumnWidths = new Dictionary<string, int>();
            
            BridgeColumnHeaders[RoadNameColumn] = "Название дороги";
            BridgeColumnHeaders[ExpandedRoadCodeColumn] = "Расширенный код дороги";
            BridgeColumnHeaders[MarkupAsStringColumn] = "Наличие разметки";
            BridgeColumnHeaders[NearestVillageColumn] = "Ближайший населенный пункт";
            BridgeColumnHeaders[DistanceToVillageColumn] = "Расстояние до ближайшего населенного пункта";
            BridgeColumnHeaders[UnderbridgeClearanceColumn] = "Подмостовой габарит";
            BridgeColumnHeaders[LengthColumn] = "Длина мостового сооружения";
            BridgeColumnHeaders[HoleColumn] = "Отверстие";
            BridgeColumnHeaders[ConstructionDateColumn] = "Дата постройки";
            BridgeColumnHeaders[ReconstructionDateColumn] = "Дата реконструкции";
            BridgeColumnHeaders[RepairsDateColumn] = "Дата ремонта";
            BridgeColumnHeaders[DesignBurdenColumn] = "Проектные нагрузки";
            BridgeColumnHeaders[LongitudeSchemeColumn] = "Продольная схема";
            BridgeColumnHeaders[ObliqueAngleColumn] = "Угол косины, в градусах";
            BridgeColumnHeaders[SlopeLateralForReportColumn] = "Уклон поперечный, %";
            BridgeColumnHeaders[ProtectionOnBridgeColumn] = "Ограждения безопасности на мостовом сооружении";
            BridgeColumnHeaders[ProtectionOnApproachColumn] = "Ограждения безопасности на подходах";
            BridgeColumnHeaders[CarriagewayWidthBeforeColumn] = "Ширина проезжей части перед мостовым сооружением";
            BridgeColumnHeaders[EmbankmentHeightBeforeColumn] = "Высота насыпи перед мостовым сооружением";
            BridgeColumnHeaders[CarriagewayWidthAfterColumn] = "Ширина проезжей части за мостовым сооружением";
            BridgeColumnHeaders[EmbankmentHeightAfterColumn] = "Высота насыпи за мостовым сооружением";
            BridgeColumnHeaders[ProjectOrganizationColumn] = "Проектная организация";
            BridgeColumnHeaders[BuildingOrganizationColumn] = "Строительная организация";
            BridgeColumnHeaders[ExploitOrganizationColumn] = "Эксплуатирующая организация";
            BridgeColumnHeaders[RoadSignsBeforeColumn] = "Дорожные знаки перед мостовым сооружением";
            BridgeColumnHeaders[RoadSignsAfterColumn] = "Дорожные знаки за мостовым сооружением";
            BridgeColumnHeaders[DateViewColumn] = "Дата обследования";
            BridgeColumnHeaders[SupportsColumn] = "Опоры";
            BridgeColumnHeaders[SpanStructuresColumn] = "Пролётные строения";
            BridgeColumnHeaders[HeightLevelNumberColumn] = "Номер уровня высоты";
            BridgeColumnHeaders[DefectsColumn] = "Дефекты";
            
            BridgeColumnHeaders[MoveTypeAsStringColumn] = "Тип по движению";
            BridgeColumnHeaders[CommunicationsAsStringColumn] = "Коммуникации";
            BridgeColumnHeaders[ArrangementsAsStringColumn] = "Обустройства";
            BridgeColumnHeaders[InfoOfRepairsForReportColumn] = "Реконструкции, ремонты";
            BridgeColumnHeaders[RoadCategoryAsStringColumn] = "Категория дороги";
            BridgeColumnHeaders[LocationInPlanAsStringColumn] = "Направление в плане";
            BridgeColumnHeaders[ExpansionJointsTypesColumn] = "Деформационные швы";
            BridgeColumnHeaders[SidewalksAsStringColumn] = "Тротуары";
            BridgeColumnHeaders[RailingsUserAsStringColumn] = "Перила";
            BridgeColumnHeaders[RegulatoryStructuresAsStringColumn] = "Регуляционные сооружения";
            BridgeColumnHeaders[ConesStrengtheningAsStringColumn] = "Укрепление конусов";
            BridgeColumnHeaders[CoverTypeAsStringColumn] = "Дорожное покрытие";
            BridgeColumnHeaders[QualityBridgeTypeAsStringColumn] = "Качество";
            BridgeColumnHeaders[ConstructionAsStringColumn] = "Сооружение";
            BridgeColumnHeaders[ObstaclesAsStringColumn] = "Препятствия";
            BridgeColumnHeaders[KilometerAsStringColumn] = "Километр";
            BridgeColumnHeaders[QuantityLineAsStringColumn] = "Количество полос";
            BridgeColumnHeaders[CharactObstacleDirectionFlowAsStringColumn] = "Направление течения";
            BridgeColumnHeaders[CharactObstacleAsStringColumn] = "Характеристики пересекаемого препятствия";
            BridgeColumnHeaders[HeightDimensionAsStringColumn] = "Габарит по высоте";
            BridgeColumnHeaders[WidthDimensionAsStringColumn] = "Габарит по ширине";
            BridgeColumnHeaders[SlopeLongitudinalForReportColumn] = "Продольный уклон";
            BridgeColumnHeaders[SlopeLateralProfileAsStringColumn] = "Поперечный уклон";
            BridgeColumnHeaders[SlopeLongitudinalBeforeAsStringColumn] = "Продольный уклон на подходе перед сооружением";
            BridgeColumnHeaders[SlopeLongitudinalAfterAsStringColumn] = "Поперечный уклон на подходе за сооружением";
            BridgeColumnHeaders[AdapterPlatesAsStringColumn] = "Переходные плиты";
            BridgeColumnHeaders[DrainageTypeAsStringColumn] = "Тип водоотвода";

            BridgeColumnHeaders[ConstructionAsStringColumn] = "Тип конструкции";
            BridgeColumnHeaders[QualityBridgeTypeAsStringColumn] = "Качество";
            BridgeColumnHeaders[StatusAsStringColumn] = "Статус";

            BridgeColumnHeaders[IDColumn] = "Идентификатор";
            BridgeColumnHeaders[TerritoryColumn] = "Код территории";
            BridgeColumnHeaders[BridgeCodeColumn] = "Код сооружения";
            BridgeColumnHeaders[DocumentationsColumn] = "Документация";
        }

        public BridgeSummaryView()
            : this(new BridgeSummaryPresenter())
        {

        }

        public BridgeSummaryView(IBridgeSummaryPresenter presenter)
        {
            InitializeComponent();
            InitBridgeListView();
            presenter.Init(this);
        }

        #region Implementation of IBridgeFindView

        public IEnumerable<Bridge> Model
        {
            get { return _model; }
            set
            {
                _model = value ?? new List<Bridge>();
                AddItemsToBridgeList(_model);
                //CalculateResults(_model);
                lbCount.Text = $"Количество: {_model.Count()}";
            }
        }

        //private void CalculateResults(IEnumerable<Bridge> model)
        //{
        //    var br = new BridgeResults()
        //    {

        //    };
        //    var res = new List<BridgeResults>() { br };
        //    dgvResults.DataSource = res;
        //}

        public ICollection<ITS.Core.Domain.Filters.Filter> BridgeFilters
        {
            get { return flowPanelAddedBridgeFilters.Controls.OfType<FilterContainer>().Select(fc => fc.GetFilter()).ToList(); }
        }

        public void FillBridgeFilters(IDictionary<ITS.Core.Domain.Filters.Filter, object> filterDictionary)
        {
            filterValueControlBridge.FillFilters(filterDictionary);
        }

        public event EventHandler<EventArgs> LoadBridge;

        public event EventHandler<BridgeEventArgs> ShowOnMap;

        public event EventHandler<BridgeEventArgs> EditBridge;

        public event EventHandler<EventArgs> ExportToWord;

        public event EventHandler<EventArgs> SavePassports;

        public void View()
        {
            var parent = BridgeConstants.Container.Resolve<IMainView>();
            Owner = (Form)parent;
            StartPosition = FormStartPosition.CenterScreen;
            Show();
        }

        public void ActivateView()
        {
            //берем дескриптор окна.
            IntPtr handle = FindWindow(null, Text);

            //если дескриптор пуст ничего не делаем.
            if (handle == IntPtr.Zero)
            {
                return;
            }

            //выводим окно на передний план.
            SetForegroundWindow(handle);

            //устанавливаем фокус на окне.
            SetFocus(handle);
        }
        #endregion

        #region Private methods

        private void InitBridgeListView()
        {
            dgvBridges.DataSource = new BindingList<Bridge>();
            
            HideColumn(ConstructionNameColumn);
            HideColumn(ConstructionTypeColumn);
            HideColumn(ObstaclesColumn);
            HideColumn(KilometerColumn);
            HideColumn(RoadCategoryColumn);
            HideColumn(QuantityLineBridgeColumn);
            HideColumn(QuantityLineApproachColumn);
            HideColumn(MarkupColumn);
            HideColumn(CharactObstacleBColumn);
            HideColumn(CharactObstacleHColumn);
            HideColumn(CharactObstacleVColumn);
            HideColumn(CharactObstacleDirectionOfFlowColumn);
            HideColumn(HeightDimensionColumn);
            HideColumn(WidthDimensionBColumn);
            HideColumn(WidthDimensionT1Column);
            HideColumn(WidthDimensionT2Column);
            HideColumn(WidthDimensionCColumn);
            HideColumn(WidthDimensionC1Column);
            HideColumn(WidthDimensionC2Column);
            HideColumn(WidthDimensionВrivewayCountColumn);
            HideColumn(WidthDimensionGColumn);
            HideColumn(LocationInPlanColumn);
            HideColumn(SlopeLateralColumn);
            HideColumn(CoverTypeColumn);
            HideColumn(DrainageTypeColumn);
            HideColumn(SidewalksColumn);
            HideColumn(RailingsTypeColumn);
            HideColumn(SlopeLongitudinalBeforeColumn);
            HideColumn(SlopeLongitudinalProfileBeforeColumn);
            HideColumn(SlopeLongitudinalAfterColumn);
            HideColumn(SlopeLongitudinalProfileAfterColumn);
            HideColumn(RegulatoryStructuresColumn);
            HideColumn(ConesStrengtheningColumn);
            HideColumn(AdapterPlatesAvailabilityColumn);
            HideColumn(AdapterPlatesLengthColumn);
            HideColumn(InfoOfRepairsColumn);
            HideColumn(CommunicationsColumn);
            HideColumn(ArrangementsColumn);
            HideColumn(SlopeLateralProfileColumn);
            HideColumn(StatusColumn);
            HideColumn(FeatureObjectColumn);
            HideColumn(QualityBridgeTypeColumn);
            HideColumn(MoveTypeColumn);
            HideColumn(PhotosColumn);
            HideColumn(PhotoableTypeColumn);
            HideColumn(SubjectCodeColumn);
            HideColumn(TerritorialRoadControlCodeColumn);
            HideColumn(RoadCodeColumn);
            HideColumn(RailingsHeightColumn);
            HideColumn(AdapterPlatesAvailabilityAsStringColumn);
            HideColumn(NotesColumn);
            HideColumn(RailingsTypeAsStringColumn);
            HideColumn(SlopeLongitudinalProfileAfterAsStringColumn);
            HideColumn(SlopeLongitudinalProfileBeforeAsStringColumn);
            HideColumn(ConstructionTypeAsStringColumn);
            HideColumn(InfoOfRepairsForReportColumn);
            HideColumn(SlopeLongitudinalForReportColumn);
            HideColumn(SlopeLateralForReportColumn);
            HideColumn(IsLeftColumn);
            HideColumn(IsOverTheRoadColumn);
            HideColumn(InversedStartOfBridgeColumn);
            HideColumn(LongitudeSchemeLmColumn);
            HideColumn(CharactObstacleAddInfoColumn);

            SetHeader(RoadNameColumn);
            SetHeader(ExpandedRoadCodeColumn);
            SetHeader(MarkupAsStringColumn);
            SetHeader(NearestVillageColumn);
            SetHeader(DistanceToVillageColumn);
            SetHeader(UnderbridgeClearanceColumn);
            SetHeader(LengthColumn);
            SetHeader(HoleColumn);
            SetHeader(ConstructionDateColumn);
            SetHeader(ReconstructionDateColumn);
            SetHeader(RepairsDateColumn);
            SetHeader(DesignBurdenColumn);
            SetHeader(LongitudeSchemeColumn);
            SetHeader(ObliqueAngleColumn);
            SetHeader(SlopeLateralForReportColumn);
            SetHeader(ProtectionOnBridgeColumn);
            SetHeader(ProtectionOnApproachColumn);
            SetHeader(CarriagewayWidthBeforeColumn);
            SetHeader(EmbankmentHeightBeforeColumn);
            SetHeader(CarriagewayWidthAfterColumn);
            SetHeader(EmbankmentHeightAfterColumn);
            SetHeader(ProjectOrganizationColumn);
            SetHeader(BuildingOrganizationColumn);
            SetHeader(ExploitOrganizationColumn);
            SetHeader(RoadSignsBeforeColumn);
            SetHeader(RoadSignsAfterColumn);
            SetHeader(DateViewColumn);
            SetHeader(SupportsColumn);
            SetHeader(SpanStructuresColumn);
            SetHeader(HeightLevelNumberColumn);
            SetHeader(DefectsColumn);

            SetHeader(MoveTypeAsStringColumn);
            SetHeader(CommunicationsAsStringColumn);
            SetHeader(ArrangementsAsStringColumn);
            SetHeader(InfoOfRepairsForReportColumn);
            SetHeader(RoadCategoryAsStringColumn);
            SetHeader(LocationInPlanAsStringColumn);
            SetHeader(ExpansionJointsTypesColumn);
            SetHeader(SidewalksAsStringColumn);
            SetHeader(RailingsUserAsStringColumn);
            SetHeader(RegulatoryStructuresAsStringColumn);
            SetHeader(ConesStrengtheningAsStringColumn);
            SetHeader(CoverTypeAsStringColumn);
            SetHeader(QualityBridgeTypeAsStringColumn);
            SetHeader(ConstructionAsStringColumn);
            SetHeader(ObstaclesAsStringColumn);
            SetHeader(KilometerAsStringColumn);
            SetHeader(QuantityLineAsStringColumn);
            SetHeader(CharactObstacleDirectionFlowAsStringColumn);
            SetHeader(CharactObstacleAsStringColumn);
            SetHeader(HeightDimensionAsStringColumn);
            SetHeader(WidthDimensionAsStringColumn);
            SetHeader(SlopeLongitudinalForReportColumn);
            SetHeader(SlopeLateralProfileAsStringColumn);
            SetHeader(SlopeLongitudinalBeforeAsStringColumn);
            SetHeader(SlopeLongitudinalAfterAsStringColumn);
            SetHeader(AdapterPlatesAsStringColumn);
            SetHeader(DrainageTypeAsStringColumn);

            SetHeader(ConstructionAsStringColumn);
            SetHeader(QualityBridgeTypeAsStringColumn);
            SetHeader(StatusAsStringColumn);
            SetHeader(IDColumn);
            SetHeader(TerritoryColumn);
            SetHeader(BridgeCodeColumn);
            SetHeader(DocumentationsColumn);
        }
        private void AddItemsToBridgeList(IEnumerable<Bridge> bridges)
        {
            dgvBridges.DataSource = bridges;
            if (bridges.Count() == 0)
            {
                MessageBox.Show("Данные по критериям поиска не найдены!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HideColumn(string columnName)
        {
            dgvBridges.Columns[columnName].Visible = false;
        }

        private void SetHeader(string columnName)
        {
            dgvBridges.Columns[columnName].HeaderText = BridgeColumnHeaders[columnName];
        }

        private void AddColumn(string columnName)
        {
            dgvBridges.Columns.Add(columnName, BridgeColumnHeaders[columnName]);
        }
        /// <summary>
        /// Обработка отображения данных в таблице
        /// </summary>
        private void BridgeGridCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //switch (dgBridges.Columns[e.ColumnIndex].Name)
            //{
            //    //todo: Вызывается очень много раз, медленно
            //    case SpanStructuresColumn:
            //        {
            //            var obj = ((Bridge)dgBridges.Rows[e.RowIndex].DataBoundItem).SpanStructures;
            //            e.Value = GetStringFromList(obj);
            //            e.FormattingApplied = true;
            //            break;
            //        }
            //    case SupportsColumn:
            //        {
            //            var obj = ((Bridge)dgBridges.Rows[e.RowIndex].DataBoundItem).Supports;
            //            e.Value = GetStringFromList(obj);
            //            e.FormattingApplied = true;
            //            break;
            //        }
            //    case DefectsColumn:
            //        {
            //            var obj = ((Bridge)dgBridges.Rows[e.RowIndex].DataBoundItem).Defects;
            //            e.Value = GetStringFromList(obj);
            //            e.FormattingApplied = true;
            //            break;
            //        }
            //}
        }

        //private static string GetStringFromList<T>(IList<T> obj)
        //{
        //    var res = "";
        //    if (obj.Count > 0)
        //    {
        //        res = obj[0].ToString();
        //    }
        //    for (int i = 1; i < obj.Count; i++)
        //    {
        //        res += "; " + obj[i].ToString();
        //    }
        //    return res;
        //}

        private void DropFilterProperties()
        {
            filterValueControlBridge.AddFilterControls(flowPanelAddedBridgeFilters.Controls.OfType<FilterContainer>().Select(fc => fc.FilterControl));
            flowPanelAddedBridgeFilters.Controls.Clear();
        }
        #endregion

        #region EventHandlers

        private void ApplyFilter_ClickHandler(object sender, EventArgs e)
        {
            LoadBridge?.Invoke(this, EventArgs.Empty);
        }

        private void DropFilter_ClickHandler(object sender, EventArgs e)
        {
            DropFilterProperties();
        }

        private void ExportWord_ClickHandler(object sender, EventArgs e)
        {
            ExportToWord?.Invoke(this, EventArgs.Empty);
        }

        private void BridgesGrid_CellContentClickHandler(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBridges.Columns[e.ColumnIndex].Name == EditBridgeColumn.Name)
            {
                EditBridge?.Invoke(this, new BridgeEventArgs((Bridge)dgvBridges.Rows[e.RowIndex].DataBoundItem));
            }
            if (dgvBridges.Columns[e.ColumnIndex].Name == ShowOnMapColumn.Name)
            {
                ShowOnMap?.Invoke(this, new BridgeEventArgs((Bridge)dgvBridges.Rows[e.RowIndex].DataBoundItem));
            }
        }

        private void btnAddBridgeFilter_Click(object sender, EventArgs e)
        {
            var f = filterValueControlBridge.GetFilterControl();
            if (f != null)
            {
                var fc = new FilterContainer(f);
                flowPanelAddedBridgeFilters.Controls.Add(fc);
                fc.Delete += FcOnBridgeFilterDelete;
            }
        }

        private void FcOnBridgeFilterDelete(FilterContainer fc)
        {
            flowPanelAddedBridgeFilters.Controls.Remove(fc);
            filterValueControlBridge.AddFilterControl(fc.FilterControl);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            SavePassports?.Invoke(this, EventArgs.Empty);
        }
    }
}