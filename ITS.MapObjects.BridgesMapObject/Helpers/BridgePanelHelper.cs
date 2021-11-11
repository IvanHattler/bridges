using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoAPI.Geometries;
using ITS.GIS.MapEntities.Attributes;
using ITS.GIS.MapEntities;
using ITS.Client.Interface.StateMachine;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.ProjectBase.Utils.AsyncWorking;
using NetTopologySuite.Geometries;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public class BridgePanelHelper
    {
        public static void SetVisiblity(IFeature feature, bool value)
        {
            var visible = (IAttribute<bool>)feature.Attributes.Find(a => a.AttrType.Name == "Visible");
            if (visible == null)
            {
                visible = new Attribute<bool>(new AttributeType<bool>("Visible"), value);
                feature.Attributes.Add(visible);
            }
            else
            {
                visible.AttrValue = value;
            }
        }

        public static void SetSelected(IFeature feature, bool value)
        {
            var selected = (IAttribute<bool>)feature.Attributes.Find(a => a.AttrType.Name == "Selected");
            if (selected == null)
            {
                selected = new Attribute<bool>(new AttributeType<bool>("Selected"), value);
                feature.Attributes.Add(selected);
            }
            else
            {
                selected.AttrValue = value;
            }
        }
        
        public static List<Bridge> GetBridges(IStateMachine stateMachine)
        {
            if (stateMachine.SelectedFeatures.Any())
            {
                return
                    stateMachine.SelectedFeatures.Select(
                        sf => ((Attribute<Bridge>)sf.Feature.Attributes.Find(a => a.AttrType.Name == "Bridge")).AttrValue).ToList();
            }
            return new List<Bridge>();
        }

        public static Bridge GetSelectedBridge(IMap handledMap, IBridgeManager bridgeManager,
            Coordinate coord, Bridge currentBridge, out InfoOfFeature info)
        {
            Bridge choosenBridge = null;
            var list = handledMap.GetAllFeature(coord, BridgeConstants.BridgeLayerAlias)
                // Выбираем те фичи, у которых нет атрибута видимости (тогда они видимые) или он есть и его значение true.
                .Where(i => i.Feature.Attributes.All(a => a.AttrType.Name != "IsVisible") ||
                            ((Attribute<bool>)i.Feature.Attributes.First(a => a.AttrType.Name == "IsVisible"))
                                .AttrValue).ToList();
            var listPoints = handledMap.GetAllFeature(coord, 20)
                .Where(i => i.LayerAlias == BridgeConstants.BridgeLayerAlias)
                .Where(i => i.Feature.Geometry.GeometryType == "Point")
                .Where(i => i.Feature.Attributes.All(a => a.AttrType.Name != "IsVisible") ||
                            ((Attribute<bool>)i.Feature.Attributes.First(a => a.AttrType.Name == "IsVisible"))
                                .AttrValue);
            foreach (var p in listPoints)
            {
                if (list.All(x => x.FeatureId != p.FeatureId))
                {
                    var attr = (Attribute<IGeometry>)p.Feature.Attributes.FirstOrDefault(a => a.AttrType.Name == "Boundary");
                    if (attr != null)
                    {
                        var polygon = new Polygon((ILinearRing)attr.AttrValue);

                        if (polygon.Intersects(new Point(coord)))
                            list.Add(p);
                    }
                }
            }
            var args = list.ToArray();
            if (args.Length == 0)
            {
                var tempFeatures = handledMap.GetAllFeature(coord, handledMap.TempLayerAlias);
                if (
                    tempFeatures.Any(
                        f =>
                            f.Feature.Attributes.Any(
                                a =>
                                    a.AttrType.Name == "Bridge" &&
                                    ((Attribute<Bridge>)a).AttrValue == currentBridge)))
                {
                    info = tempFeatures.First(
                        f =>
                            f.Feature.Attributes.Any(
                                a =>
                                    a.AttrType.Name == "Bridge" &&
                                    ((Attribute<Bridge>)a).AttrValue == currentBridge));
                    return currentBridge;
                }
                info = null;
                return null;

            }
            if (args.Length == 1)
            {
                //StateMachine.SelectFeatureAdd(args.First());
                info = args.First();
                choosenBridge = bridgeManager.GetByFeature(args.First().FeatureId);
            }
            //Если объектов в указанном месте несколько
            else
            {
                var bridges =
                    args.Select(arg => bridgeManager.GetByFeature(arg.FeatureId))
                        .Where(x => x != null)
                        .ToList();
                var s = bridges.Select(x => x.ToString()).ToList();
                var f = new SelectFeatureForm(s) { Text = @"ITSGIS: выбор объекта" };
                if (f.ShowDialog() == DialogResult.OK && f.SelectedItem >= 0 && f.SelectedItem < args.Length)
                {
                    //StateMachine.SelectFeatureAdd(args[f.SelectedItem]);
                    info = args[f.SelectedItem];
                    choosenBridge = bridgeManager.GetByFeature(args[f.SelectedItem].FeatureId);
                }
                else
                {
                    info = null;
                }
            }
            return choosenBridge;

        }
    }
}
