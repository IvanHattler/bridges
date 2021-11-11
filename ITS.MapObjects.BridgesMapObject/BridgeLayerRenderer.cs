using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using GeoAPI.Geometries;
using ITS.Core.Domain;
using ITS.Core.Enums;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Attributes;
using ITS.GIS.MapEntities.Renderer;
using ITS.GIS.MapEntities.Styles;
using ITS.MapObjects.BridgesMapObject.Properties;
using Microsoft.Practices.Unity;
using NetTopologySuite.Geometries;
using NHibernate.Criterion;
using ITS.GIS.CoreToGeoTranslators;
using NetTopologySuite.Operation.Buffer;
using ITS.MapObjects.BridgesMapObject.Helpers;

namespace ITS.MapObjects.BridgesMapObject
{
    public interface IBridgeLayerRender : ICustomLayerRenderer
    {
        /// <summary>
        /// Список выделенных объектов. Key - id, Value - цвет выделения.
        /// </summary>
        Dictionary<long, Color> SelectedBridges { get; set; }

        /// <summary>
        /// Включена ли подсветка.
        /// </summary>
        bool BridgesHighlightingEnabled { get; set; }
    }

    public class BridgeLayerRenderer : IBridgeLayerRender
    {
        private readonly SimpleLayerRenderer _simpleLayerRenderer;
        private Matrix _transformMatrix = new Matrix();

        static Envelope env = null;
        public static SortedDictionary<long, BridgeRenderGeometry>
            bridgesGeometries = new SortedDictionary<long, BridgeRenderGeometry>();
        IEnumerable<KeyValuePair<long, IFeature>> features = null;

        public IMap _map;
        public string Alias => Resources.BridgeLayerAlias;
        public string PluginName => Resources.PluginToolName;
        public bool IsEnabled { get; set; }
        public string Description => "Стандартный";

        /// <summary>
        /// Список выделенных объектов. Key - id, Value - цвет выделения.
        /// </summary>
        public Dictionary<long, Color> SelectedBridges { get; set; }

        /// <summary>
        /// Включена ли подсветка.
        /// </summary>
        public bool BridgesHighlightingEnabled { get; set; }

        public BridgeLayerRenderer()
        {
            _simpleLayerRenderer = BridgeConstants.Container.Resolve<SimpleLayerRenderer>();
            SelectedBridges = new Dictionary<long, Color>();
            _map = BridgeConstants.Container.Resolve<IMap>();
            IsEnabled = true;
        }

        public void Render(Graphics g, ILayer layer, Envelope envelope, Matrix transformMatrix)
        {
            if (layer is IVectorLayer vLayer)
            {
                if (env == null ||
                    !env.AsGeometry().EqualsExact(envelope.AsGeometry()))
                {
                    env = envelope;
                    //Получили все геометрии заданной области
                    features =
                        vLayer.Features.Where(
                            f => f.Value.Geometry.GeometryType == "LineString" &&
                                envelope.Intersects(f.Value.Geometry.EnvelopeInternal));
                }
                // Переходим к отрисовке 
                Render(g, features, transformMatrix);
            }
        }

        public void Render(Graphics g, IEnumerable<IFeature> features, Matrix transformMatrix)
        {
            throw new NotImplementedException();
        }

        public void Render(Graphics g, IEnumerable<KeyValuePair<long, IFeature>> features, Matrix transformMatrix)
        {
            // Открываем контейнер для отрисовки.
            var gc = g.BeginContainer();

            // Применяем зум и смещения к контейнеру.
            g.Transform = transformMatrix;

            // Задаем максимальное качество отрисовки.
            //g.InterpolationMode = InterpolationMode.High;
            //g.SmoothingMode = SmoothingMode.HighQuality;
            //g.CompositingQuality = CompositingQuality.HighQuality;

            foreach (var feature in features)
            {
                DrawBridge(g, feature.Key, feature.Value);
            }

            // Закрываем контейнер.
            g.EndContainer(gc);
        }

        protected bool IsVisible(Bridge bridge)
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
                default:
                    return true;
            }
        }

        protected void DrawBridge(Graphics g, long id, IFeature feature)
        {
            var bridge = BridgeAttributeHelper.GetBridgeByAttribute(feature);
            if (bridge == null) return;

            var ls = feature.Geometry;
            if (ls == null) return;

            if (!IsVisible(bridge))
                return;

            if (ls.GeometryType == "LineString")
            {
                //bool selected = false;
                //var attr = (Attribute<bool>)BridgeAttributeHelper.GetAttribute(feature, "Selected");
                //if (attr != null && attr.AttrValue)
                //{
                //    selected = true;
                //}
#if DEBUG
                bridgesGeometries[id] = new BridgeRenderGeometry(bridge, feature);
#else
                if (!bridgesGeometries.ContainsKey(id))
                {
                    bridgesGeometries[id] = new BridgeRenderGeometry(bridge, feature);
                }
#endif
                Paint(bridgesGeometries[id].MainGeometry, g, bridgesGeometries[id].MainGeometryStyle);
                Paint(bridgesGeometries[id].StartMark, g, bridgesGeometries[id].StartMarkStyle);
                if (BridgeConstants.BridgeLengthVisible && _map.CoordSys.Zoom > 1)
                {
                    using (Pen pen = new Pen(Color.Red, bridgesGeometries[id].BridgeLengthLabelWidth))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        g.DrawPath(pen, bridgesGeometries[id].BridgeLengthLabel);
                    }
                }
                if (BridgesHighlightingEnabled && SelectedBridges.ContainsKey(bridge.ID))
                {
                    if (feature.Geometry.Coordinates.Count() >= 2)
                        using (var pen = new Pen(SelectedBridges[bridge.ID], 0.5f)
                        {
                            StartCap = LineCap.Square,
                            EndCap = LineCap.Square
                        })
                            g.DrawLines(pen,
                                bridgesGeometries[id].MainGeometry
                                .Coordinates.Select(c => new PointF((float)c.X, (float)c.Y)).ToArray());
                }
            }
        }

        protected virtual void Paint(IGeometry geometry, Graphics g, IStyle style)
        {
            if (geometry != null && !geometry.IsEmpty)
                    _simpleLayerRenderer.Paint(geometry, g, style, _transformMatrix);
        }
    }
}
