using GeoAPI.Geometries;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.Core.Domain.FeatureObjects;
using ITS.Core.Passports;
using ITS.Core.Passports.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Renderer;
using ITS.MapObjects.BridgesMapObject.Helpers;
using ITS.Core.Domain.Filters;
using ITS.Core.Enums;
using ITS.Core.Bridges.Domain;
using ITS.MapObjects.BridgesMapObject.Reports;
using ITS.Common.RtfWriter;
using Color = System.Drawing.Color;

namespace ITS.MapObjects.BridgesMapObject.Passport
{
    public class BridgesPassportizator : ICustomPassportizator
    {
        private IBridgeManager _bridgeManager;

        private IBridgeManager BridgeManager
        {
            get
            {
                return _bridgeManager ??
                       (_bridgeManager = BridgeConstants.Container.Resolve<IBridgeManager>());
            }
        }

        protected IMap Map => BridgeConstants.Container.Resolve<IMap>();


        protected IBridgeLayerRender BridgeLayerRenderer
        {
            get
            {
                return BridgeConstants.Container.Resolve<ILayerRendererContainer>()
                    .CustomRenderers
                    .FirstOrDefault(r => r.Alias == Layers.First() && r.IsEnabled)
                        as IBridgeLayerRender;
            }
        }


        public List<string> Layers { get; } = new List<string> { BridgeConstants.BridgeLayerAlias };

        public PassportableType PassportableType => PassportableType.Bridge;

        public string ContentName => "СВОДНАЯ ВЕДОМОСТЬ МОСТОВЫХ СООРУЖЕНИЙ";

        public IGeometry Region { set; private get; }

        public bool CheckUpdates(Dictionary<long, int> versions)
        {
            return
                versions.Any(
                    version => BridgeManager.GetFeatureVersion(version.Key) != version.Value);
        }

        public void ClearSelection()
        {
            if (BridgeLayerRenderer == null) return;
            BridgeLayerRenderer.SelectedBridges.Clear();
            Map.BeginRedraw();
        }

        public void FillSummaryTable(Dictionary<long, int[]> objects, ref object document, Dictionary<string, object> parameters = null)
        {
            var filter = new Filter
            {
                PropertyName = "Идентификатор",
                FilterType = FilterType.Id,
                Function = FilterFunc.Id,
                PropertyPath = "ID",
                Values = objects.Keys.Cast<object>().ToArray()
            };
            var bridges = objects.Any() ? BridgeManager
                .FilterBridges(new List<Filter> { filter }).ToList() : new List<Bridge>();

            var projectType = (ProjectType)parameters["ProjectType"];
            //var docType = (DocumentType)parameters["DocumentType"];

            if (projectType == ProjectType.Passport)
            {
                BridgeReport.ReportMake((RtfDocument)document, bridges);
            }
        }

        public string GetDescriptionByObjectId(long id)
        {
            return BridgeManager.GetByID(id).GetShortDescription();
        }

        public Dictionary<long, Dictionary<long, string>> GetFeatureIdObjectIdDescription(IEnumerable<long> featureIds)
        {
            return BridgeManager.GetBridgesInfoByFeatureObjectIDs(featureIds);
        }

        public KeyValuePair<long, FeatureObject> GetObjectByClick(Coordinate coordinate)
        {
            InfoOfFeature info;
            var bridge = BridgePanelHelper.GetSelectedBridge(Map, BridgeManager, coordinate, null, out info);
            if (bridge == null)
                return new KeyValuePair<long, FeatureObject>(-1, null);
            return new KeyValuePair<long, FeatureObject>(bridge.ID, bridge.FeatureObject);
        }

        public Dictionary<long, string> GetObjectIdDescription(long featureId)
        {
            return BridgeManager.GetBridgeInfoByFeatureObjectID(featureId);
        }

        public IEnumerable<KeyValuePair<long, FeatureObject>> GetObjectsByClick(Coordinate coordinate)
        {
            InfoOfFeature info;
            var rm = BridgePanelHelper.GetSelectedBridge(Map, BridgeManager, coordinate, null, out info);
            if (rm == null)
                return new List<KeyValuePair<long, FeatureObject>> { new KeyValuePair<long, FeatureObject>(-1, null) };
            return new List<KeyValuePair<long, FeatureObject>> { new KeyValuePair<long, FeatureObject>(rm.ID, rm.FeatureObject) };
        }

        public Dictionary<ObjectSummaryReportElementType, object> GetObjectSummaryReportData(Dictionary<long, int[]> objects, Dictionary<string, object> parameters = null)
        {
            return null;
        }

        public int GetPartitionOrder(ProjectType projectType, DocumentType docType)
        {
            //todo: исправить числа
            return 1000;
        }

        //здесь есть странность, в IDs приходят не id мостов, а какие то другие id
        public string GetPassportizatorSummary(IEnumerable<long> IDs)
        {
            //Не оптимально, но на будущее, когда будет не только количество
            //var bridges = BridgeManager.GetBridgesByFeatureObjectIDs(IDs.ToList());
            return $"Количество: {IDs.Count()}";
        }

        public void HighlightObject(long objectId, Color color)
        {
            if (BridgeLayerRenderer == null) return;
            if (BridgeLayerRenderer.SelectedBridges.ContainsKey(objectId))
                BridgeLayerRenderer.SelectedBridges[objectId] = color;
            else
            {
                BridgeLayerRenderer.SelectedBridges.Add(objectId, color);
            }
            Map.BeginRedraw();
        }

        public void SetHighlightingEnabled(bool value)
        {
            if (BridgeLayerRenderer == null) return;
            BridgeLayerRenderer.BridgesHighlightingEnabled = value;
            Map.BeginRedraw();
        }

        public void SetSelection(Dictionary<long, Color> selectionColors)
        {
            if (BridgeLayerRenderer == null) return;
            BridgeLayerRenderer.SelectedBridges = selectionColors;
            Map.BeginRedraw();
        }

        public void UnhighlightObject(long objectId)
        {
            if (BridgeLayerRenderer == null || !BridgeLayerRenderer.SelectedBridges.ContainsKey(objectId)) return;
            BridgeLayerRenderer.SelectedBridges.Remove(objectId);
            Map.BeginRedraw();
        }
    }
}
