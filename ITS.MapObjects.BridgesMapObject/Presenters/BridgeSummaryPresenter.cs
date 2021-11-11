using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoAPI.Geometries;
using GeoAPI.Operations.Buffer;
using ITS.Core.Enums;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.GIS.CoreToGeoTranslators;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Styles;
using ITS.MapObjects.BridgesMapObject.EventArgses;
using ITS.MapObjects.BridgesMapObject.IPresenters;
using ITS.MapObjects.BridgesMapObject.IViews;
using ITS.MapObjects.BridgesMapObject.Reports;
using ITS.ProjectBase.Utils.AsyncWorking;
using Microsoft.Practices.Unity;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Bridges.Domain.Base;
using ITS.Core.Domain.Photos;
using System.ComponentModel;

namespace ITS.MapObjects.BridgesMapObject.Presenters
{
    public class BridgeSummaryPresenter : IBridgeSummaryPresenter
    {
        private readonly IBridgeManager _bridgeManager;
        public BridgeSummaryPresenter()
        {
        }

        public BridgeSummaryPresenter(IBridgeManager bridgeManager)
        {
            _bridgeManager = bridgeManager;
        }

        [Dependency]
        public IMap Map { get; set; }

        #region IPresenter Members

        public void Init(IBridgeSummaryView view)
        {
            view.LoadBridge += Load_Handler;
            view.EditBridge += EditBridge_Handler;
            view.ShowOnMap += ShowOnMap_Handler;
            view.ExportToWord += Export_Handler;
            view.SavePassports += SavePassports_Handler;
            InitView(view);
        }

        #endregion

        private void InitView(IBridgeSummaryView view)
        {
            view.FillBridgeFilters(new Dictionary<Core.Domain.Filters.Filter, object>
            {
                {new ITS.Core.Domain.Filters.Filter {PropertyName = "Идентификатор", FilterType=FilterType.Id,PropertyPath="ID"},null},
                {new ITS.Core.Domain.Filters.Filter {PropertyName = "Тип сооружения", FilterType=FilterType.Selector,PropertyPath="ConstructionType"},GetTreeForEnum<BridgeType, BridgeTypeStrings>()},
                {new ITS.Core.Domain.Filters.Filter {PropertyName = "Название дороги", FilterType=FilterType.String,PropertyPath="RoadName"},null},
                {new ITS.Core.Domain.Filters.Filter {PropertyName = "Категория дороги", FilterType=FilterType.Selector,PropertyPath="RoadCategory"},GetTreeForEnum<RoadCategory,RoadCategoryStrings>()},
                {new ITS.Core.Domain.Filters.Filter {PropertyName = "Разметка", FilterType=FilterType.Selector,PropertyPath="Markup"},GetTreeForBool()},
                {new ITS.Core.Domain.Filters.Filter {PropertyName = "Ближайший населенный пункт", FilterType=FilterType.String,PropertyPath="NearestVillage"},null},
                {new ITS.Core.Domain.Filters.Filter {PropertyName = "Длина мостового сооружения", FilterType=FilterType.Numeric,PropertyPath="Length"},GetLength()},
                //{new ITS.Core.Domain.Filters.Filter {PropertyName = "Препятствия", FilterType=FilterType.String,PropertyPath="Obstacles"},null},
            });
        }

        private Dictionary<TreeNode, object> GetTreeForEnum<T, TStrings>()
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            var converter = new TStrings();
            return
                Enum.GetValues(typeof(T))
                    .Cast<T>()
                    .ToDictionary<T, TreeNode, object>(value => new TreeNode(converter.GetName(value)), value => value);
        }
        private Dictionary<TreeNode, object> GetTreeForBool()
        {
            return new Dictionary<TreeNode, object>()
            {
                { new TreeNode("1"), true},
                { new TreeNode("0"), false},
            };
        }
        private KeyValuePair<int[], Type> GetLength()
        {
            var ret = new int[2];
            ret[0] = 0;
            ret[1] = 10000;
            return new KeyValuePair<int[], Type>(ret, typeof(float));
        }

        private void Load_Handler(object sender, EventArgs e)
        {
            var view = (IBridgeSummaryView)sender;

            var bridgesFilters =
                new List<ITS.Core.Domain.Filters.Filter>(new[]
                {
                    new ITS.Core.Domain.Filters.Filter
                    {
                        FilterType = FilterType.String,
                        Function = FilterFunc.Eq,
                        PropertyPath = "FeatureObject.Layer.Map.Alias",
                        Values = new[] {Map.Alias},
                        PropertyName = "Карта"
                    }
                });
            bridgesFilters.AddRange(view.BridgeFilters);


            IEnumerable<Bridge> filteredBridge = null;
            AsyncLoaderForm.ShowMarquee((a, b) =>
                filteredBridge = _bridgeManager.FilterBridges(bridgesFilters), "Идет загрузка объекта");
            //todo: фильтры
            //filteredBridge = filteredBridge.Where(b =>
            //    b.Obstacles != null && b.Obstacles.Select(o => o.Type).Contains(ObstacleType.River))
            //    .ToList();
            view.Model = filteredBridge;
        }


        /// <summary>
        /// Обрабатывает нажатие кнопки редактирования объекта.
        /// </summary>
        private void EditBridge_Handler(object sender, BridgeEventArgs e)
        {
            Bridge bridge = _bridgeManager.GetByFeature(e.Bridge.FeatureObject.ID);
            var addView = BridgeConstants.Container.Resolve<IBridgeEditView>(new ParameterOverride("bridge", bridge));
            addView.ShowViewDialog();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки перемещения к месторасположению объекта.
        /// </summary>
        private void ShowOnMap_Handler(object sender, BridgeEventArgs e)
        {
            Map.ClearTempLayer();
            Map.CoordSys.ChangeLocationTo(e.Bridge.FeatureObject.Geometry.Centroid.X, e.Bridge.FeatureObject.Geometry.Centroid.Y);

            //IGeometry geometry = e.Bridge.FeatureObject.GetFeature().Geometry.Buffer(0.2, 4, EndCapStyle.Flat);
            //Map.AddToTempLayer(new Feature(geometry.Difference(e.Bridge.FeatureObject.Geometry), new AreaStyle(new InteriorStyle(Color.Green), new LineStyle(Color.Green, 2f))));

            //Map.AddToTempLayer(new Feature(BridgeLayerRenderer.GetBufferGeometry(
            //        e.Bridge.FeatureObject.GetFeature(), e.Bridge.WidthDimensionB / 2),
            //    new AreaStyle(new InteriorStyle(Color.Transparent), 
            //    new LineStyle(Color.Green, 7f))));

            Map.BeginRedraw();
        }

        private void Export_Handler(object sender, EventArgs e)
        {
            var view = (IBridgeSummaryView)sender;
            if (view.Model != null)
            {
                var dialog = new SaveFileDialog
                {
                    Filter = "Doc files (*.rtf)|*.rtf"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    AsyncLoaderForm.ShowMarquee((s, ee) =>
                        {
                            try
                            {
                                BridgeReport.ReportMake(dialog.FileName, view.Model.ToList(), 12);
                                MessageBox.Show("Сводная ведомость успешно экспортирована в Word", "Экспорт в Word...");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Произошла ошибка экспорта", "Экспорт в Word...");
                            }
                        },
                        "Идет формирование отчета...");

                    ReportHelper.Open(dialog.FileName);
                }
            }
            else MessageBox.Show("Сводная ведомость пуста!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SavePassports_Handler(object sender, EventArgs e)
        {
            var view = (IBridgeSummaryView)sender;
            if (view.Model != null)
            {
                var dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    AsyncLoaderForm.ShowContinuous((s, ee) =>
                        {
                            var background = s as BackgroundWorker;
                            int i = 0;
                            foreach(var bridge in view.Model)
                            {
                                LoadPhotos(bridge);
                                background.ReportProgress(++i);
                                try
                                {
                                    string filePath = System.IO.Path.Combine(dialog.SelectedPath,
                                        $"{bridge.ConstructionType}_" +
                                        $"{bridge.BridgeCode.Replace('/', '_')}_{bridge.ID}.rtf");
                                    BridgeReport.BridgePassportMake(filePath, bridge, 12);
                                }
                                catch (Exception) { }
                                background.ReportProgress(++i);
                            }
                        },
                        view.Model.Count() * 2,
                        "Идет сохранение паспортов...");
                }
            }
            else MessageBox.Show("Сводная ведомость пуста!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadPhotos(Bridge bridge)
        {
            if (!bridge.IsTransient() && bridge.Photos == null)
            {
                bridge.Photos = _bridgeManager.GetPhotosByBridge(bridge).ToList();
            }
        }
    }
}
