using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using GeoAPI.Geometries;
using ITS.Client.Interface.StateMachine;
using ITS.Client.Interface.StateMachine.Selected;
using ITS.Client.Interface.StateMachine.Selected.Interfaces;
using ITS.Core.Domain.FeatureObjects;
using ITS.Core.Domain.Geometries;
using ITS.Core.ManagerInterfaces.Features;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.GIS.CoreToGeoTranslators;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Renderer;
using ITS.GIS.MapEntities.Styles;
using ITS.GIS.UIControls.Tools;
using ITS.MapObjects.BaseMapObject.Misc;
using ITS.MapObjects.BaseMapObject.Misc.PluginAttributes;
using ITS.Core.ManagerInterfaces.UndoRedo;
using ITS.Core.Bridges.Domain.Enums;
using ITS.MapObjects.EditGeometryPlugin.Tools;
using ITS.MapObjects.BridgesMapObject.Properties;
using ITS.ProjectBase.Utils.AsyncWorking;
using ITS.ProjectBase.Utils.EventBroker.EventBrokerExtension;
using Microsoft.Practices.Unity;
using NetTopologySuite.Geometries;
using ITS.MapObjects.EditGeometryPlugin.EventArgsPlugin;
using ITS.MapObjects.EditGeometryPlugin.Tools.SelectTools;
using ITS.GIS.MapEntities.Attributes;
using ITS.MapObjects.BridgesMapObject.Helpers;
using ITS.MapObjects.BridgesMapObject.IViews;
using ITS.MapObjects.EditGeometryPlugin.Forms;
using NetTopologySuite.Operation.Buffer;
using ITS.MapObjects.EditGeometryPlugin.Tools.SplitTools;
using ITS.MapObjects.BridgesMapObject.EventArgses;
using ITS.Core;
using ITS.Core.Security;
using System.Threading;
using ITS.Core.Domain.Photos;

namespace ITS.MapObjects.BridgesMapObject
{
    /// <summary>
    /// Панель плагина.
    /// </summary>
    public class BridgePanel : IMapObjectManager
    {
        #region Private fields
        private Bridge _currentBridge;
        private Bridge _oldBridge = null;
        private Bridge _newBridge = new Bridge();
        private LayerObject _bridgeLayer;
        private IGeometry _geometry;
        private bool _flag;
        private IStateMachine _stateMachine;
        private IMap _map;
        private ILayerManager _layerManager;
        private IUndoRedoManager _undoRedoManager;
        private IToolManager _toolManager;
        private IBridgeManager _bridgeManager;
        private IBridgeObstacleManager _bridgeObstacleManager;
        private IBridgeSupportManager _bridgeSupportManager;
        private ISpanStructureManager _spanStructureManager;
        private IMaterialManager _materialManager;
        private IDefectManager _defectManager;
        private IDefectTypeManager _defectTypeManager;
        private IDefectScrollSectionManager _defectScrollSectionManager;
        private ITypicalProjectManager _typicalProjectManager;
        private IInfoOfRepairsManager _infoOfRepairsManager;
        private ITerritoryManager _territoryManager;
        private IDocumentationInfoManager _documentationInfoManager;
        private readonly List<ISelectedFeature> _selectedBridgeFeatures = new List<ISelectedFeature>();
        private InfoOfFeature _saveFeature;
        private List<InfoOfFeature> _saveFeatures = new List<InfoOfFeature>();
        /// <summary>
        /// Признак редактирования фич.
        /// </summary>
        private bool _isEdit;
        private InfoOfFeature _beginEdit;
        /// <summary>
        /// Список геометрий фич до их редактирования.
        /// </summary>
        private Dictionary<InfoOfFeature, IGeometry> _oldGeometries = new Dictionary<InfoOfFeature, IGeometry>();
        private BridgeCreator bridgeCreator;
        private bool firstInteraction = true;
        #endregion

        #region Constructor

        /// <summary>
        /// Создает панель плагина.
        /// </summary>
        public BridgePanel(IMapManager mapManager)
        {
            MapManager = mapManager ??
                throw new ArgumentNullException(nameof(mapManager));
            bridgeCreator = new BridgeCreator(MaterialManager, TerritoryManager, Map.Alias);
            Subscrubies();
        }

        private void Subscrubies()
        {
            UndoRedoManager.CanBackEvent += SubscribeToBack;
            UndoRedoManager.CanForwardEvent += SubscribeToForward;
            BridgeEndEdit += OnGeometriesChanged;
            BridgeDeleted += BridgePanel_BridgeDeleted;
        }

        #endregion

        private IMapManager MapManager { get; }

        #region Lazy Properties

        /// <summary>
        /// Менеджер инструментов.
        /// </summary>
        private IToolManager ToolManager
        {
            get { return _toolManager ?? (_toolManager = BridgeConstants.Container.Resolve<IToolManager>()); }
        }


        /// <summary>
        /// Машина состояний.
        /// </summary>
        private IStateMachine StateMachine
        {
            get { return _stateMachine ?? (_stateMachine = BridgeConstants.Container.Resolve<IStateMachine>()); }
        }

        private IUndoRedoManager UndoRedoManager
        {
            get { return _undoRedoManager ?? (_undoRedoManager = BridgeConstants.Container.Resolve<IUndoRedoManager>()); }
        }

        /// <summary>
        /// Карта.
        /// </summary>
        private IMap Map
        {
            get { return _map ?? (_map = BridgeConstants.Container.Resolve<IMap>()); }
        }

        /// <summary>
        /// Менеджер слоёв.
        /// </summary>
        private ILayerManager LayerManager
        {
            get { return _layerManager ?? (_layerManager = BridgeConstants.Container.Resolve<ILayerManager>()); }
        }


        private IBridgeManager BridgeManager
        {
            get
            {
                return _bridgeManager ??
                       (_bridgeManager = BridgeConstants.Container.Resolve<IBridgeManager>());
            }
        }

        private IBridgeSupportManager BridgeSupportManager
        {
            get
            {
                return _bridgeSupportManager ??
                       (_bridgeSupportManager = BridgeConstants.Container.Resolve<IBridgeSupportManager>());
            }
        }

        private ISpanStructureManager SpanStructureManager
        {
            get
            {
                return _spanStructureManager ??
                       (_spanStructureManager = BridgeConstants.Container.Resolve<ISpanStructureManager>());
            }
        }

        private IBridgeObstacleManager BridgeObstacleManager
        {
            get
            {
                return _bridgeObstacleManager ??
                       (_bridgeObstacleManager = BridgeConstants.Container.Resolve<IBridgeObstacleManager>());
            }
        }

        private IMaterialManager MaterialManager
        {
            get
            {
                return _materialManager ??
                       (_materialManager = BridgeConstants.Container.Resolve<IMaterialManager>());
            }
        }

        private IDefectManager DefectManager
        {
            get
            {
                return _defectManager ??
                       (_defectManager = BridgeConstants.Container.Resolve<IDefectManager>());
            }
        }

        private IDefectTypeManager DefectTypeManager
        {
            get
            {
                return _defectTypeManager ??
                       (_defectTypeManager = BridgeConstants.Container.Resolve<IDefectTypeManager>());
            }
        }

        private IDefectScrollSectionManager DefectScrollSectionManager
        {
            get
            {
                return _defectScrollSectionManager ??
                       (_defectScrollSectionManager = BridgeConstants.Container.Resolve<IDefectScrollSectionManager>());
            }
        }

        private ITypicalProjectManager TypicalProjectManager
        {
            get
            {
                return _typicalProjectManager ??
                       (_typicalProjectManager = BridgeConstants.Container.Resolve<ITypicalProjectManager>());
            }
        }

        private IInfoOfRepairsManager InfoOfRepairsManager
        {
            get
            {
                return _infoOfRepairsManager ??
                       (_infoOfRepairsManager = BridgeConstants.Container.Resolve<IInfoOfRepairsManager>());
            }
        }

        private ITerritoryManager TerritoryManager
        {
            get
            {
                return _territoryManager ??
                       (_territoryManager = BridgeConstants.Container.Resolve<ITerritoryManager>());
            }
        }


        private IDocumentationInfoManager DocumentationInfoManager
        {
            get
            {
                return _documentationInfoManager ??
                       (_documentationInfoManager = BridgeConstants.Container.Resolve<IDocumentationInfoManager>());
            }
        }

        private IVectorLayer BridgeLayerOnMap
        {
            get { return Map.Layers.FirstOrDefault(l => l.Alias == Resources.BridgeLayerAlias) as IVectorLayer; }
        }

        private LayerObject BridgeLayer
        {
            get
            {
                return _bridgeLayer ?? (_bridgeLayer = LayerManager.GetByAlias(Map.Alias, Resources.BridgeLayerAlias));
            }
        }

        #endregion

        #region IMapObjectManager Members

        public string ToolName
        {
            get { return BridgeConstants.ToolName; }
        }

        public string ToolVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(2); }
        }

        #endregion

        #region Create Tool Methods

        private SelectTool CreateSelectTool()
        {
            return BridgeConstants.Container.Resolve<SelectTool>();
        }

        private EditGeometryTool CreateEditGeometryTool()
        {
            return BridgeConstants.Container.Resolve<EditGeometryTool>();
        }

        private PointTool CreatePointTool()
        {
            return BridgeConstants.Container.Resolve<PointTool>();
        }

        private LineTool CreateLineTool()
        {
            return BridgeConstants.Container.Resolve<LineTool>();
        }

        private PolygonTool CreatePolygonTool()
        {
            return BridgeConstants.Container.Resolve<PolygonTool>();
        }

        private RotateTool CreateRotateTool()
        {
            return BridgeConstants.Container.Resolve<RotateTool>();
        }

        #endregion

        #region Bridges Panel Buttons
        #region Вкладка Мосты
        #region Выбрать

        /// <summary>
        /// Обрабатывает нажатие кнопки "Выбрать геометрию".
        /// </summary>
        [Functional("SelectBridge", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("ITS.Bridge.EndEdit", "ITS.Bridge.BeginEdit")]
        [ChangeCheckedOn("SelectBridge", "ChangeMapTool")]
        [ToolAction("SelectBridge", "MapClick")]
        public void SelectBridgeMapClick(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer())
                return;
            Map.ClearTempLayer();

            if (!(e is MapClickEventArgs args)) return;
            SelectedFeature(args.ClickCoordinate);
        }

        [ToolAction("SelectBridge", "MapRightClick")]
        public void SelectBridgeMapRightClick(object sender, EventArgs e)
        {
            DeselectAll();
            Map.BeginRedraw();
        }
        /// <summary>
        /// Обрабатывает событие выбора геометрии.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [SubscribesTo("ITS.Client.MapInterfaceController.FeatureSelected")]
        public void OnFeatureSelected(object sender, EventArgs e)
        {
            if (_selectedBridgeFeatures != null)
            {
                foreach (var feat in _selectedBridgeFeatures)
                {
                    if (feat.Feature.Attributes.Exists(a => a.AttrType.Name == "Selected"))
                    {
                        BridgePanelHelper.SetSelected(feat.Feature, false);
                    }
                }
                _selectedBridgeFeatures.Clear();
            }

            if (StateMachine.SelectedFeatures.Count == 1)
            {
                var selected = StateMachine.SelectedFeatures.FirstOrDefault();
                if (selected.Feature.Attributes.Exists(x => x.AttrType.Name == "Bridge"))
                {
                    _selectedBridgeFeatures.Add(selected);
                    BridgePanelHelper.SetSelected(selected.Feature, true);
                    HasSelectedBridge?.Invoke(sender, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Обрабатывает событие прекращения выбора геометрии.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [SubscribesTo("ITS.Client.MapInterfaceController.FeatureNone")]
        public void OnFeatureNone(object sender, EventArgs e)
        {
            if (_selectedBridgeFeatures != null)
            {
                foreach (var feat in _selectedBridgeFeatures)
                {
                    if (feat.Feature.Attributes.Exists(a => a.AttrType.Name == "Selected"))
                    {
                        BridgePanelHelper.SetSelected(feat.Feature, false);
                    }
                }
                _selectedBridgeFeatures.Clear();
            }
            HasNoSelectedBridge?.Invoke(sender, EventArgs.Empty);
        }

        #endregion

        #region Добавить мост

        [Functional("AddBridge", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("ITS.Bridge.EndEdit", "ITS.Bridge.BeginEdit")]
        [ChangeCheckedOn("AddBridge", "ChangeMapTool")]
        [ToolAction("AddBridge", "ItemClick")]
        public void AddBridge_ItemClick(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            Map.ClearTempLayer();
            DeselectAll();
            Map.BeginRedraw();
            var tool = CreateLineTool();
            tool.LineCreated += LineTool_OnLineCreated;
            ToolManager.TurnOn(tool);
        }
        private void LineTool_OnLineCreated(IFeature feature)
        {
            if (ToolManager.CurrentTool is LineTool tool)
            {
                ToolManager.TurnOff();
                CreateNewBridge(feature);
                ToolManager.TurnOn(tool);
                //BridgeAdded?.Invoke(this, new BridgeEventArgs(br));
            }
        }
        [ToolAction("AddBridge", "ClickOnOtherTool")]
        public void AddBridge_ClickOnOtherTool(object sender, EventArgs e)
        {
            if (ToolManager.CurrentTool is LineTool tool)
            {
                tool.FinishedOrCancel();
                ToolManager.TurnOff();
                tool.LineCreated -= LineTool_OnLineCreated;
            }
        }
        #endregion

        #region Редактировать мост

        [Functional("EditBridge", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("ITS.Bridge.EndEdit", "ITS.Bridge.BeginEdit")]
        [ChangeCheckedOn("EditBridge", "ChangeMapTool")]
        [ToolAction("EditBridge", "MapClick")]
        public void MapClickBridgeEdit(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            Map.ClearTempLayer();
            if (!(e is MapClickEventArgs args)) return;
            var info = GetFeatureByClickCoordinate(args.ClickCoordinate);
            if (info != null)
            {
                var br = EditBridge(info);
                BridgeEndEdit?.Invoke(this, new BridgeEventArgs(br));
            }
        }

        #endregion

        #region Копировать мост

        [ToolAction("CopyPasteBridge", "ItemClick")]
        public void CopyPasteItemChange(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            Map.ClearTempLayer();
            _oldBridge = _currentBridge;
            if (!(_oldBridge is null))
            {
                _newBridge.CopyFrom(_oldBridge);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки "Копирование опоры".
        /// </summary>
        [Functional("CopyPasteBridge", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeCheckedOn("CopyPasteBridge", "ChangeMapTool")]
        //[ChangeEnableOn("", "ITS.Client.MapInterfaceController.FeatureNone")]
        [ToolAction("CopyPasteBridge", "MapClick")]
        public void OnCopyPasteBridge(object sender, EventArgs e)
        {
            if (!(e is MapClickEventArgs args)) return;

            SelectedFeature(args.ClickCoordinate);
            _oldBridge = _currentBridge;
            if (!(_oldBridge is null))
            {
                _newBridge.CopyFrom(_oldBridge);
            }
        }

        [ToolAction("CopyPasteBridge", "MapRightClick")]
        public void MapRightClickCopyPastBridge(object sender, EventArgs e)
        {
            if (!(e is MapClickEventArgs clickArgs)) return;

            if (!(_oldBridge is null))
            {
                var dx = clickArgs.ClickCoordinate.X - _oldBridge.FeatureObject.Geometry.Coordinate.X;
                var dy = clickArgs.ClickCoordinate.Y - _oldBridge.FeatureObject.Geometry.Coordinate.Y;

                var lo = LayerManager.GetByAlias(Map.Alias, BridgeConstants.BridgeLayerAlias);

                var coords = _oldBridge.FeatureObject.Geometry.Coordinates;

                var newCoords = new Coordinate[coords.Length];

                for (var i = 0; i < coords.Length; i++)
                {
                    newCoords[i] = new Coordinate(coords[i].X + dx, coords[i].Y + dy);
                }
                //Feature feature = GetPolygonFeature(newCoords,
                //    _oldBridge.FeatureObject.Style.GetStyle());
                var feature = new Feature(new LineString(newCoords),
                    BridgeConstants.defaultBridgeStyle);
                _newBridge.FeatureObject = feature.GetFeatureObject();

                lo.AddFeature(_newBridge.FeatureObject);

                BridgeManager.AddNew(_newBridge);

                //DeselectAll();

                //Map.BeginRedraw();
            }
        }

        //private static Feature GetPolygonFeature(Coordinate[] newCoords, IStyle style)
        //{
        //    var g = new Polygon(new LinearRing(newCoords));
        //    Feature feature = null;

        //    if (style != null)
        //    {
        //        feature = new Feature(g, style);
        //    }
        //    else
        //    {
        //        feature = new Feature(g, BridgeConstants.defaultBridgeStyle);
        //    }
        //    return feature;
        //}

        #endregion

        #region Удалить мост

        [Functional("DeleteBridge", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("ITS.Bridge.EndEdit", "ITS.Bridge.BeginEdit")]
        [ChangeCheckedOn("DeleteBridge", "ChangeMapTool")]
        [ToolAction("DeleteBridge", "MapClick")]
        public void MapClickDeleteBridge(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;

            if (!(e is MapClickEventArgs args)) return;

            var info = GetFeatureByClickCoordinate(args.ClickCoordinate);

            if (info != null)
            {
                DeleteBridge(info);
            }
        }

        private void DeleteBridge(InfoOfFeature args)
        {
            if (MessageBox.Show("Удалить выбранный объект?", "Подтвердите удаление", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var bridge = BridgeManager.GetByFeature(args.FeatureId);
                    if (bridge == null) return;
                    BridgeDeleted?.Invoke(this, new BridgeEventArgs(bridge));
                    BridgeManager.Delete(bridge);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        string.Format("Ошибка удаления {0}{1}", Environment.NewLine, ex.Message),
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
        #endregion

        #region Вкладка Работа с геометрией
        #region Переместить мост
        [Functional("MoveBridge", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeCheckedOn("MoveBridge", "ChangeMapTool")]
        [ChangeEnableOn("ITS.Bridge.EndEdit", "ITS.Bridge.BeginEdit")]
        //[ChangeEnableOn("", "ITS.Client.MapInterfaceController.FeatureNone")]
        [ToolAction("MoveBridge", "MapDown")]
        public void MoveBridgeMapDown(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            //todo: перемещение моста
            EditGeometryBridgeMapDown(sender, e);
        }

        #endregion

        #region Поворот моста

        [Functional("RotateBridge", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeCheckedOn("RotateBridge", "ChangeMapTool")]
        [ChangeEnableOn("ITS.Bridge.EndEdit", "ITS.Bridge.BeginEdit")]
        //[ChangeEnableOn("ITS.MapObjects.EditGeometryPlugin.Tools.FeatureCanRotate", "ITS.MapObjects.EditGeometryPlugin.Tools.FeatureNotCanRotate")]
        //[ChangeEnableOn("", "ITS.Client.MapInterfaceController.FeatureNone")]
        [ToolAction("RotateBridge", "MapDown")]
        public void RotateBridgeMapDown(object sender, EventArgs e)
        {

            if (!CreateBridgeLayer()) return;

            EditGeometryBridgeMapDown(sender, e);
            ToolManager.TurnOn(CreateRotateTool());
            //if (!_isEdit && _currentBridge != null && _saveFeature != null)
            //{
            //    var c = _currentBridge.FeatureObject.Geometry.Coordinates;
            //    var center = _currentBridge.FeatureObject.Geometry.Centroid;
            //    var newC = RotateTransform(c, 90, new Coordinate(center.X, center.Y));
            //    //установить новые координаты
            //    var lo = LayerManager.GetByAlias(Map.Alias, BridgeConstants.BridgeLayerAlias);
            //    var a = GetPolygonFeature(newC).GetFeatureObject();
            //    //lo.DeleteFeature(_currentBridge.FeatureObject);
            //    _currentBridge.FeatureObject = a;

            //    //lo.AddFeature(a);

            //    //BridgeManager.AddNew(_newBridge);

            //    BridgeManager.Edit(_currentBridge);
            //    DeselectAll();
            //    Map.BeginRedraw();
            //}
        }
        [ToolAction("RotateBridge", "ClickOnOtherTool")]
        public void RotateBridgeClickOther(object sender, EventArgs e)
        {
            ToolManager.TurnOff();
        }
        ///// <summary>
        ///// Поворачивает точки относительно центральной точки на заданный угол.
        ///// </summary>
        ///// <param name="points">Точки, которые надо повернуть.</param>
        ///// <param name="angle">Угол поворота.</param>
        ///// <param name="center">Центр поворота.</param>
        ///// <returns>Повернутые точки.</returns>
        //public static Coordinate[] RotateTransform(IEnumerable<Coordinate> points, double angle, Coordinate center)
        //{
        //    return (from point in points
        //            let x = (point.X - center.X) * Math.Cos(angle) - (point.Y - center.Y) * Math.Sin(angle) + center.X
        //            let y = (point.X - center.X) * Math.Sin(angle) + (point.Y - center.Y) * Math.Cos(angle) + center.Y
        //            select new Coordinate(x, y)).ToArray();
        //}
        #endregion

        #region Редактор геометрии
        [Functional("EditGeometryBridge", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeCheckedOn("EditGeometryBridge", "ChangeMapTool")]
        [ToolAction("EditGeometryBridge", "MapDown")]
        public void EditGeometryBridgeMapDown(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            Map.ClearTempLayer();
            if (!(e is MapClickEventArgs args))
                return;

            if (!_flag)
            {
                StateMachine.SelectNone();

                #region через нажатие на карту
                InfoOfFeature info = GetFeatureByClickCoordinate(args.ClickCoordinate);

                try
                {
                    if (info != null)
                        AsyncLoaderForm.ShowMarquee(
                            (s, ee) =>
                            {
                                _currentBridge = BridgeManager.GetByFeature(info.FeatureId);
                            },
                            "Загрузка для редактирования");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        string.Format("Ошибка редактирования {0}{1}", Environment.NewLine, ex.Message),
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
                //#region через выделенный мост
                //var info = new InfoOfFeature(_currentBridge.FeatureObject.ID,
                //    _currentBridge.FeatureObject.GetFeature(), BridgeConstants.BridgeLayerAlias);
                //#endregion
                if (info != null)
                {
                    if (info.Feature.Geometry is ILineString)
                    {
                        _geometry = (IGeometry)info.Feature.Geometry.Clone();

                        BeginEdit?.Invoke(this, EventArgs.Empty);
                        var infoFeature = Map.AddToTempLayer(info.Feature);

                        StateMachine.SelectFeature(infoFeature, false);
                        BridgePanelHelper.SetSelected(infoFeature.Feature, false);

                        var tool = CreateEditGeometryTool();
                        ToolManager.TurnOn(tool);

                        Map.BeginRedraw();

                        tool.MapClick += SelectedFeatureForEditLineString;
                    }
                    //if (info.Feature.Geometry is IPolygon)
                    //{
                    //    _geometry = (IGeometry)info.Feature.Geometry.Clone();

                    //    BeginEdit?.Invoke(this, EventArgs.Empty);
                    //    var infoFeature = Map.AddToTempLayer(info.Feature);
                    //    StateMachine.SelectFeature(infoFeature, false);
                    //    //RendererSettings.NonDrawingFeatures.Add(info.FeatureId);

                    //    var tool = CreateEditGeometryTool();
                    //    ToolManager.TurnOn(tool);

                    //    _flag = true;
                    //}
                }
            }
        }
        /// <summary>
        /// Редактирование линейной фичи, возможен переход на точечную фичу.
        /// </summary>
        /// <param name="coord">Координаты фичи.</param>
        private void SelectedFeatureForEditLineString(Coordinate coord)
        {
            GetSelectedBridge(coord, out InfoOfFeature inf);

            if (inf != null)
            {
                _beginEdit = inf;
                SelectedFeature(_beginEdit.Feature.Geometry.Coordinate);
                _beginEdit = null;

                BeginEdit?.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Сгруппировать геообъекты
        [Functional("GroupBridges", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("ITS.Bridge.BeginEdit", "ITS.Bridge.EndEdit")]
        [ChangeEnableOn("", "ITS.Client.MapInterfaceController.FeatureNone")]
        [ChangeCheckedOn("GroupBridges", "ChangeMapTool")]
        [ToolAction("GroupBridges", "MapDown")]
        public void GroupBridges_MapDown(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            Map.ClearTempLayer();
            //todo:  реализовать
        }
        #endregion

        #region Отменить группировку
        [Functional("CancelGroupingBridges", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("ITS.Bridge.BeginEdit", "ITS.Bridge.EndEdit")]
        [ChangeEnableOn("", "ITS.Client.MapInterfaceController.FeatureNone")]
        [ChangeCheckedOn("CancelGroupingBridges", "ChangeMapTool")]
        [ToolAction("CancelGroupingBridges", "MapDown")]
        public void CancelGroupingBridges(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            Map.ClearTempLayer();
            //todo:  реализовать
        }
        #endregion

        #region Разделить геометрию
        [Functional("SplitGeometryBridges", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        //[ChangeEnableOn("ITS.Bridge.BeginEdit", "ITS.Bridge.EndEdit")]
        //[ChangeEnableOn("", "ITS.Client.MapInterfaceController.FeatureNone")]
        [ChangeCheckedOn("SplitGeometryBridges", "ChangeMapTool")]
        [ToolAction("SplitGeometryBridges", "ItemChange")]
        [ChangeEnableOn("ITS.MapObjects.EditGeometryPlugin.Tools.PolygonCanSplit",
            "ITS.MapObjects.EditGeometryPlugin.Tools.PolygonNotCanSplit")]
        public void SplitGeometryBridgesItemChange(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            Map.ClearTempLayer();
            //todo:  реализовать
            //var tool = BridgeConstants.Container.Resolve<SplitPolygonTool>();
            //ToolManager.TurnOn(tool);
        }
        //[ToolAction("SplitGeometryBridges", "ClickOnOtherTool")]
        //public void SplitGeometryBridgesClickOnOtherTool(object sender, EventArgs e)
        //{
        //    ToolManager.TurnOff();
        //}
        #endregion
        #endregion

        #region Вкладка Инструменты
        #region Привязать мост к ближайшему населённому пункту
        [Functional("BindBridgeToVillage", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("ITS.Bridge.EndEdit", "ITS.Bridge.BeginEdit")]
        [ChangeCheckedOn("BindBridgeToVillage", "ChangeMapTool")]
        [ToolAction("BindBridgeToVillage", "MapDown")]
        public void BindBridgeToVillage(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            //todo:  реализовать
        }
        #endregion

        #region Справочник
        [Functional("DirectoryBridges", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("ITS.Bridge.EndEdit", "ITS.Bridge.BeginEdit")]
        //[ChangeEnableOn("", "ITS.Client.MapInterfaceController.FeatureNone")]
        [ChangeCheckedOn("DirectoryBridges", "ChangeMapTool")]
        [ToolAction("DirectoryBridges", "ItemChange")]
        public void DirectoryBridgesItemChange(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            //todo:  реализовать
        }
        #endregion
        #endregion

        #region Вкладка Ведомости

        #region Информация
        [Functional("BridgeInfo", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("ITS.Bridge.EndEdit", "ITS.Bridge.BeginEdit")]
        [ChangeCheckedOn("BridgeInfo", "ChangeMapTool")]
        [ToolAction("BridgeInfo", "MapClick")]
        public void MapClickBridgeInfo(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            if (!(e is MapClickEventArgs args))
                return;
            var info = GetFeatureByClickCoordinate(args.ClickCoordinate);

            if (info != null)
            {
                ShowBridgeInfo(info);
            }
        }

        #endregion

        #region Сводная ведомость

        [Functional("BridgeSummary", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("ITS.Bridge.EndEdit", "ITS.Bridge.BeginEdit")]
        [ChangeCheckedOn("BridgeSummary", "ChangeMapTool")]
        [ToolAction("BridgeSummary", "ItemClick")]
        public void BridgeSummary_ItemClick(object sender, EventArgs e)
        {
            if (!CreateBridgeLayer()) return;
            var view = BridgeConstants.Container.Resolve<IBridgeSummaryView>();
            if (!Application.OpenForms.Cast<Form>().OfType<IBridgeSummaryView>().Any())
            {
                view.View();
            }
            else
            {
                view.ActivateView();
            }
        }

        #endregion

        #endregion

        #region Вкладка Функционал изменений
        #region UndoRedo Buttons

        [Functional("BackBridges", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("BackEnable", "BackNonEnable")]
        [ChangeEnableOn("", "ITS.MapObjects.EditGeometryPlugin.TaskClear")]
        [ToolAction("BackBridges", "ItemClick")]
        public void BackBridges_ItemClick(object sender, EventArgs e)
        {
            //todo: реализовать
            //UndoRedoManager.Back();
        }

        [Functional("ForwardBridges", FunctionalType.Tool, typeof(BridgePanelResourceHelper))]
        [ChangeEnableOn("ForwardEnable", "ForwardNonEnable")]
        [ChangeEnableOn("", "ITS.MapObjects.EditGeometryPlugin.TaskClear")]
        [ToolAction("ForwardBridges", "ItemClick")]
        public void ForwardBridges_ItemClick(object sender, EventArgs e)
        {
            //todo: реализовать
            //UndoRedoManager.Forward();
        }

        #endregion

        #region UndoRedo Methods

        private void SubscribeToBack(object sender, EventArgs args)
        {
            if (((BoolEventArgs)args).Flag)
            {
                BackEnable?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                BackNonEnable?.Invoke(this, EventArgs.Empty);
            }
        }

        private void SubscribeToForward(object sender, EventArgs args)
        {
            if (((BoolEventArgs)args).Flag)
            {
                ForwardEnable?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                ForwardNonEnable?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region UndoRedo Events

        [Publishes("BackEnable")]
        public event EventHandler<EventArgs> BackEnable;

        [Publishes("BackNonEnable")]
        public event EventHandler<EventArgs> BackNonEnable;

        [Publishes("ForwardEnable")]
        public event EventHandler<EventArgs> ForwardEnable;

        [Publishes("ForwardNonEnable")]
        public event EventHandler<EventArgs> ForwardNonEnable;

        #endregion

        #region Кнопка "Применить"

        [Functional("AcceptBridges", FunctionalType.Tool, typeof(BridgePanelResourceHelper), true)]
        [ChangeEnableOn("", "ITS.Client.MapInterfaceController.FeatureNone")]
        [ChangeEnableOn("ITS.Bridge.BeginEdit", "ITS.Bridge.EndEdit")]
        [ToolAction("AcceptBridges", "ItemClick")]
        public void AcceptBridges_ItemClick(object sender, EventArgs e)
        {
            try
            {
                if (StateMachine.SelectedFeatures.Count > 0)
                {
                    var selectedFeature = StateMachine.SelectedFeatures.First();
                    Map.RemoveFromTempLayer(selectedFeature.Feature);

                    if (_currentBridge != null &&
                        BridgeLayerOnMap.Features.ContainsKey(_currentBridge.FeatureObject.ID))
                    {
                        RendererSettings.NonDrawingFeatures.Remove(_currentBridge.FeatureObject.ID);
                        _currentBridge.Length = (float)selectedFeature.Feature.Geometry.Length;
                        _currentBridge.FeatureObject.Geometry = selectedFeature.Feature.Geometry;
                        _currentBridge = BridgeManager.Edit(_currentBridge);
                    }

                    ToolManager.TurnOff();
                    StateMachine.SelectNone();
                    _flag = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Ошибка редактирования{0}{1}", Environment.NewLine, ex.Message),
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            EndEdit?.Invoke(this, new BridgeEventArgs(_currentBridge));
            BridgeEndEdit?.Invoke(this, new BridgeEventArgs(_currentBridge));
        }

        #endregion

        #region Кнопка "Отмена"

        [Functional("CancelBridges", FunctionalType.Tool, typeof(BridgePanelResourceHelper), true)]
        [ChangeEnableOn("", "ITS.Client.MapInterfaceController.FeatureNone")]
        [ChangeEnableOn("ITS.Bridge.BeginEdit", "ITS.Bridge.EndEdit")]
        [ToolAction("CancelBridges", "ItemClick")]
        public void CancelBridges_ItemClick(object sender, EventArgs e)
        {
            if (StateMachine.SelectedFeatures.Count > 0)
            {
                var selectedFeature = StateMachine.SelectedFeatures.First();
                Map.RemoveFromTempLayer(selectedFeature.Feature);
                if (_currentBridge != null && BridgeLayerOnMap.Features.ContainsKey(_currentBridge.FeatureObject.ID))
                {
                    RendererSettings.NonDrawingFeatures.Remove(_currentBridge.FeatureObject.ID);
                }
                ToolManager.TurnOff();

                selectedFeature.Feature.Geometry = _geometry;
                Map.BeginRedrawRegion(StateMachine.SelectedFeatures.FirstOrDefault().Feature.Envelope);

                _flag = false;

                EndEdit?.Invoke(this, new BridgeEventArgs(_currentBridge));
                BridgeEndEdit?.Invoke(this, new BridgeEventArgs(_currentBridge));
                StateMachine.SelectNone();
            }
        }

        #endregion
        #endregion

        #region Вкладка Статус

        [Functional("SelectBridgeSet", FunctionalType.Tool, typeof(BridgePanelResourceHelper), selected: true)]
        [ChangeCheckedOn("IsBridgeDrawSetOn", "IsBridgeDrawSetOff")]
        [ToolAction("SelectBridgeSet", "ItemClick")]
        public void OnBridgeSetShow(object sender, EventArgs e)
        {
            BridgeConstants.IsDrawSet = !BridgeConstants.IsDrawSet;
            if (BridgeConstants.IsDrawSet)
            {
                IsBridgeDrawSetOn?.Invoke(sender, e);
            }
            else
            {
                IsBridgeDrawSetOff?.Invoke(sender, e);
            }
            Map.BeginRedraw();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки "Требуются".
        /// </summary>
        [Functional("SelectBridgeRequired", FunctionalType.Tool, typeof(BridgePanelResourceHelper), selected: true)]
        [ChangeCheckedOn("IsBridgeDrawRequiredOn", "IsBridgeDrawRequiredOff")]
        [ToolAction("SelectBridgeRequired", "ItemClick")]
        public void OnBridgeRequiredShow(object sender, EventArgs e)
        {
            BridgeConstants.IsDrawRequired = !BridgeConstants.IsDrawRequired;
            if (BridgeConstants.IsDrawRequired)
            {
                IsBridgeDrawRequiredOn?.Invoke(sender, e);
            }
            else
            {
                IsBridgeDrawRequiredOff?.Invoke(sender, e);
            }
            Map.BeginRedraw();
        }

        [Functional("SelectBridgeRepairs", FunctionalType.Tool, typeof(BridgePanelResourceHelper), selected: true)]
        [ChangeCheckedOn("IsBridgeDrawRepairsOn", "IsBridgeDrawRepairsOff")]
        [ToolAction("SelectBridgeRepairs", "ItemClick")]
        public void OnBridgeRepairsShow(object sender, EventArgs e)
        {
            BridgeConstants.IsDrawRepairs = !BridgeConstants.IsDrawRepairs;
            if (BridgeConstants.IsDrawRepairs)
            {
                IsBridgeDrawRepairsOn?.Invoke(sender, e);
            }
            else
            {
                IsBridgeDrawRepairsOff?.Invoke(sender, e);
            }
            Map.BeginRedraw();
        }

        [Functional("SelectBridgeTemporary", FunctionalType.Tool, typeof(BridgePanelResourceHelper), selected: true)]
        [ChangeCheckedOn("IsBridgeDrawTemporaryOn", "IsBridgeDrawTemporaryOff")]
        [ToolAction("SelectBridgeTemporary", "ItemClick")]
        public void OnBridgeTemporaryShow(object sender, EventArgs e)
        {
            BridgeConstants.IsDrawTemporary = !BridgeConstants.IsDrawTemporary;
            if (BridgeConstants.IsDrawTemporary)
            {
                IsBridgeDrawTemporaryOn?.Invoke(sender, e);
            }
            else
            {
                IsBridgeDrawTemporaryOff?.Invoke(sender, e);
            }
            Map.BeginRedraw();
        }

        [Functional("SelectBridgeDismantle", FunctionalType.Tool, typeof(BridgePanelResourceHelper), selected: true)]
        [ChangeCheckedOn("IsBridgeDrawDismantleOn", "IsBridgeDrawDismantleOff")]
        [ToolAction("SelectBridgeDismantle", "ItemClick")]
        public void OnBridgeDismantleShow(object sender, EventArgs e)
        {
            BridgeConstants.IsDrawDismantle = !BridgeConstants.IsDrawDismantle;
            if (BridgeConstants.IsDrawDismantle)
            {
                IsBridgeDrawDismantleOn?.Invoke(sender, e);
            }
            else
            {
                IsBridgeDrawDismantleOff?.Invoke(sender, e);
            }
            Map.BeginRedraw();
        }
        #endregion
        #endregion

        #region Events

        //private event Action<InfoOfFeature> FeatureSelected;
        private event Action<InfoOfFeature> FeatureDeselected;

        [Publishes("IsBridgeDrawSetOn")]
        public event EventHandler<EventArgs> IsBridgeDrawSetOn;

        [Publishes("IsBridgeDrawSetOff")]
        public event EventHandler<EventArgs> IsBridgeDrawSetOff;

        [Publishes("IsBridgeDrawRequiredOn")]
        public event EventHandler<EventArgs> IsBridgeDrawRequiredOn;

        [Publishes("IsBridgeDrawRequiredOff")]
        public event EventHandler<EventArgs> IsBridgeDrawRequiredOff;

        [Publishes("IsBridgeDrawTemporaryOn")]
        public event EventHandler<EventArgs> IsBridgeDrawTemporaryOn;

        [Publishes("IsBridgeDrawTemporaryOff")]
        public event EventHandler<EventArgs> IsBridgeDrawTemporaryOff;


        [Publishes("IsBridgeDrawDismantleOn")]
        public event EventHandler<EventArgs> IsBridgeDrawDismantleOn;

        [Publishes("IsBridgeDrawDismantleOff")]
        public event EventHandler<EventArgs> IsBridgeDrawDismantleOff;


        [Publishes("IsBridgeDrawRepairsOn")]
        public event EventHandler<EventArgs> IsBridgeDrawRepairsOn;

        [Publishes("IsBridgeDrawRepairsOff")]
        public event EventHandler<EventArgs> IsBridgeDrawRepairsOff;



        [Publishes("HasSelectedBridge")]
        public event EventHandler<EventArgs> HasSelectedBridge;

        [Publishes("HasNoSelectedBridge")]
        public event EventHandler<EventArgs> HasNoSelectedBridge;

        [Publishes("ITS.Bridge.BeginEdit")]
        public event EventHandler<EventArgs> BeginEdit;

        [Publishes("ITS.Bridge.EndEdit")]
        public event EventHandler<EventArgs> EndEdit;

        public event EventHandler<BridgeEventArgs> BridgeEndEdit;
        //public event EventHandler<BridgeEventArgs> BridgeAdded;
        public event EventHandler<BridgeEventArgs> BridgeDeleted;

        #endregion

        #region Event Handlers
        private void BridgePanel_BridgeDeleted(object sender, BridgeEventArgs e)
        {
            var bridge = e.Bridge;
            if (bridge != null)
            {
                BridgeLayerRenderer.bridgesGeometries
                    .Remove(bridge.FeatureObject.ID);
            }
        }

        private void OnGeometriesChanged(object sender, BridgeEventArgs e)
        {
            var bridge = e.Bridge;
            if (bridge != null)
            {
                BridgeLayerRenderer.bridgesGeometries[bridge.FeatureObject.ID]
                    .Refresh(bridge, bridge.FeatureObject.GetFeature());
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Метод, создающий слой мостовых сооружений, если его нет на карте
        /// </summary>
        private bool CreateBridgeLayer()
        {
            bool res = true;
            if (firstInteraction && LayerManager.GetByAlias(Map.Alias, BridgeConstants.BridgeLayerAlias) == null &&
                ApplicationService.CurrentUser.RolesText.Contains(AppRoles.ReadWrite))
            {
                var order = BridgeConstants.BridgeLayerOrderIndex;
                if (Map.Layers.ContainsLayerOrder(order) &&
                    MessageBox.Show($"В текущей карте уже есть слой с порядком {BridgeConstants.BridgeLayerOrderIndex}." +
                        $" Искать ли первый свободный порядок после {BridgeConstants.BridgeLayerOrderIndex}?", "Ошибка", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    order++;
                    while (Map.Layers.ContainsLayerOrder(order))
                    {
                        order++;
                    }
                }
                    
                AsyncLoaderForm.ShowMarquee((s, e) =>
                {
                    var layer = Map.CreateLayer(BridgeConstants.BridgeLayerAlias, LayerType.VectorLayer);
                    layer.IsPluginLayer = true;
                    layer.IsVisibleByDefault = true;
                    layer.IsVisible = true;
                    layer.IsSelected = true;
                    layer.Order = order;
                    var layerObject = layer.GetLayerObject();
                    var mapObj = MapManager
                        .GetByAlias(Map.Alias);
                    layerObject.Map = mapObj;
                    LayerManager.AddNew(layerObject);
                }, "Производится первоначальная настройка плагина");

                var la = LayerManager.GetByAlias(Map.Alias, BridgeConstants.BridgeLayerAlias);
                if (la == null)
                {
                    MessageBox.Show($"Не удалось добавить слой", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    res = false;
                }
                else
                {
                    firstInteraction = false;
                    res = true;
                }
            }
            return res;
        }
        private void DeselectAll()
        {
            var infos = StateMachine.SelectedFeatures.Select(x => x.Info).ToList();
            StateMachine.SelectNone();
            infos.ForEach(
                i =>
                {
                    var attr = ((IAttribute<bool>)i.Feature.Attributes.Find(a => a.AttrType.Name == "Selected"));
                    if (attr != null) attr.AttrValue = false;
                    FeatureDeselected?.Invoke(i);
                });
        }

        /// <summary>
        /// Выделение фич, используется всегда когда нужно выделить фичу.
        /// </summary>
        /// <param name="args">Координаты фичи.</param>
        private void SelectedFeature(Coordinate args)
        {
            //сохранение изменёных фич.
            if (_saveFeature != null && _isEdit)
            {
                _saveFeatures.Add(_saveFeature);
            }

            InfoOfFeature inf = null;
            Bridge selectedBridge = null;
            if (_isEdit)
            {
                if (_beginEdit != null)
                {
                    selectedBridge = BridgeAttributeHelper.GetBridgeByAttribute(_beginEdit.Feature);
                    inf = _beginEdit;
                }
                else
                {
                    if (StateMachine.SelectedFeatures != null)
                    {
                        inf = StateMachine.SelectedFeatures.Select(x => x.Info).First();
                    }
                    if (inf != null)
                        selectedBridge = BridgeAttributeHelper.GetBridgeByAttribute(inf.Feature);
                }
            }
            else
            {
                selectedBridge = GetSelectedBridge(args, out inf);
            }
            _saveFeature = inf;

            if (selectedBridge == null)
            {
                Map.BeginRedraw();
            }
            else
            {
                if (_isEdit)
                    //сохранение геометрии фичи.
                    if (!_oldGeometries.ContainsKey(inf))
                    {
                        _oldGeometries.Add(inf, (IGeometry)inf.Feature.Geometry.Clone());
                    }

                _currentBridge = selectedBridge;

                if (inf.Feature.Geometry is ILineString && _isEdit)
                {
                    var selectedLine = (SelectedLine)StateMachine.SelectFeature(inf);
                    BridgePanelHelper.SetSelected(inf.Feature, false);
                    selectedLine.PointableIsolation.ShowPoint = true;
                    selectedLine.PointableIsolation.ShowHidePoint = true;
                }
                else
                {
                    StateMachine.SelectFeature(inf, false);
                    BridgePanelHelper.SetSelected(inf.Feature, true);
                }
                HasSelectedBridge?.Invoke(null, EventArgs.Empty);
                Map.BeginRedraw();
            }
        }

        private Bridge GetSelectedBridge(Coordinate coord, out InfoOfFeature info)
        {
            return BridgePanelHelper.GetSelectedBridge(Map, BridgeManager, coord, _currentBridge, out info);
        }

        private InfoOfFeature GetFeatureByClickCoordinate(Coordinate coord)
        {
            var infos = Map.GetAllFeature(coord, 20);
            if (infos.Any())
            {
                InfoOfFeature info = null;
                Point coordPoint = new Point(coord);
                infos = infos.Where(a =>
                    a.Feature != null && a.LayerAlias == BridgeConstants.BridgeLayerAlias &&
                    IsVisible(BridgeAttributeHelper.GetBridgeByAttribute(a.Feature)) &&
                    a.Feature.Geometry.Distance(coordPoint) <= 10).ToArray();
                if (infos.Length > 1)
                {
                    var listBridge = new List<string>();
                    AsyncLoaderForm.ShowMarquee((s, ee) =>
                    {
                        listBridge = infos.Select(info2 => BridgeManager.GetByFeature(info2.FeatureId).ToString()).ToList();
                    }, "Загрузка");

                    var form = new SelectFeatureForm(listBridge);
                    if (form.ShowDialog() == DialogResult.OK)
                        info = form.SelectedItem >= 0 ? infos[form.SelectedItem] : null;
                    else return null;
                }
                else
                {
                    if (infos.Length == 1)
                    {
                        info = infos.Single();
                    }
                }
                return info;
            }
            return null;
        }

        private bool IsVisible(Bridge bridge)
        {
            if (bridge == null)
                return false;

            switch (bridge.Status)
            {
                case BridgeStatus.Set:
                    return BridgeConstants.IsDrawSet;
                case BridgeStatus.Required:
                    return BridgeConstants.IsDrawRequired;
                case BridgeStatus.Dismantle:
                    return BridgeConstants.IsDrawDismantle;
                case BridgeStatus.Repairs:
                    return BridgeConstants.IsDrawRepairs;
                case BridgeStatus.Temporary:
                    return BridgeConstants.IsDrawTemporary;
            }
            return true;
        }

        private void CreateNewBridge(IFeature bridgeFeature)
        {
            if (bridgeFeature == null)
                throw new ArgumentNullException(nameof(bridgeFeature));

            var featureObject = bridgeFeature.GetFeatureObject();
            featureObject.Layer = LayerManager.GetByAlias(Map.Alias, BridgeConstants.BridgeLayerAlias);
            BridgeLayer.AddFeature(featureObject);
            var bridge = bridgeCreator.GetDefaultBridge(bridgeFeature.Geometry as ILineString);
            bridge.FeatureObject = featureObject;

            ShowEditView(bridge);
        }

        private Bridge EditBridge(InfoOfFeature args)
        {
            try
            {
                Bridge bridge = null;
                AsyncLoaderForm.ShowMarquee((s, ee) => { bridge = BridgeManager.GetByFeature(args.FeatureId); },
                    "Загрузка для редактирования");
                ShowEditView(bridge);
                return bridge;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Ошибка редактирования {0}{1}", Environment.NewLine, ex.Message),
                    "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return null;
        }

        private void ShowEditView(Bridge bridge)
        {
            IBridgeEditView addView = null;
            AsyncLoaderForm.ShowMarquee((s, ee) =>
            {
                addView = BridgeConstants.Container.Resolve<IBridgeEditView>(
                new ParameterOverride("bridge", bridge),
                new ParameterOverride("bridgeManager", BridgeManager),
                new ParameterOverride("bridgeObstacleManager", BridgeObstacleManager),
                new ParameterOverride("bridgeSupportManager", BridgeSupportManager),
                new ParameterOverride("spanStructureManager", SpanStructureManager),
                new ParameterOverride("materialManager", MaterialManager),
                new ParameterOverride("defectManager", DefectManager),
                new ParameterOverride("defectTypeManager", DefectTypeManager),
                new ParameterOverride("defectScrollSectionManager", DefectScrollSectionManager),
                new ParameterOverride("typicalProjectManager", TypicalProjectManager),
                new ParameterOverride("infoOfRepairsManager", InfoOfRepairsManager),
                new ParameterOverride("territoryManager", TerritoryManager),
                new ParameterOverride("documentationInfoManager", DocumentationInfoManager));
            },
                    "Загрузка формы добавления");
            //var addView =
            //    BridgeConstants.Container.Resolve<IBridgeEditView>(
            //    new ParameterOverride("bridge", bridge), new ParameterOverride("bridgeManager", BridgeManager),
            //    new ParameterOverride("bridgeObstacleManager", BridgeObstacleManager),
            //    new ParameterOverride("bridgeSupportManager", BridgeSupportManager),
            //    new ParameterOverride("spanStructureManager", SpanStructureManager),
            //    new ParameterOverride("materialManager", MaterialManager),
            //    new ParameterOverride("defectManager", DefectManager),
            //    new ParameterOverride("defectTypeManager", DefectTypeManager),
            //    new ParameterOverride("defectScrollSectionManager", DefectScrollSectionManager),
            //    new ParameterOverride("typicalProjectManager", TypicalProjectManager),
            //    new ParameterOverride("infoOfRepairsManager", InfoOfRepairsManager),
            //    new ParameterOverride("territoryManager", TerritoryManager),
            //    new ParameterOverride("documentationInfoManager", DocumentationInfoManager));

            addView?.ShowViewDialog();
        }

        private void ShowBridgeInfo(InfoOfFeature args)
        {
            try
            {
                // Получили объект.
                Bridge bridge = null;
                AsyncLoaderForm.ShowMarquee((s, ee) => { bridge = BridgeManager.GetByFeature(args.FeatureId); },
                    "Загрузка информации об объекте");

                // Если не получили, выходим.
                if (bridge == null) return;

                // Отображаем информацию.
                var reportMaker = BridgeConstants.Container.Resolve<IBridgeReportMaker>(
                            new ParameterOverride("bridge", bridge));
                var infoView =
                    BridgeConstants.Container.Resolve<IBridgeInfoView>(
                        new ParameterOverride("bridge", bridge),
                        new ParameterOverride("bridgeManager", BridgeManager),
                        new ParameterOverride("reportMaker", reportMaker));
                infoView.ShowViewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Ошибка просмотра информации{0}{1}", Environment.NewLine,
                        ex.Message), "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}