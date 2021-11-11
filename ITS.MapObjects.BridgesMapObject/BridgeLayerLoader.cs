using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.Core.Bridges.Domain;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Attributes;
using ITS.GIS.MapEntities.Loader;
using ITS.MapObjects.BridgesMapObject.Properties;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.Unity;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.MapObjects.BridgesMapObject.Helpers;

namespace ITS.MapObjects.BridgesMapObject
{
    public class BridgeLayerLoader : ICustomLayerLoader
    {
        /// <summary>
        /// Менеджер.
        /// </summary>
        private readonly IBridgeManager _bridgeManager;

        public BridgeLayerLoader()
        {
            _bridgeManager = BridgeConstants.Container.Resolve<IBridgeManager>();
        }

        public string LayerName
        {
            get { return Resources.BridgeLayerAlias; }
        }

        public string AttributeName
        {
            get { return BridgeConstants.BridgeAttributeName; }
        }

        public void Load(List<long> listIds, IMap map)
        {
            if (listIds.Count == 0) return;

            List<long> idsInLayer;
            lock (map.SyncRoot)
            {
                var layer = (IVectorLayer)map.Layers[Resources.BridgeLayerAlias];
                idsInLayer = listIds.Where(id => layer.Features.ContainsKey(id)).ToList();
            }
            var bridges = LoadBridgesByIds(idsInLayer);
            
            lock (map.SyncRoot)
            {
                var layer = (IVectorLayer)map.Layers[Resources.BridgeLayerAlias];
                foreach (var bridge in bridges)
                {
                    if (layer.Features.ContainsKey(bridge.FeatureObject.ID))
                    {
                        var f = layer.Features[bridge.FeatureObject.ID];
                        var attrRR = (Attribute<Bridge>)BridgeAttributeHelper.GetAttribute(f, AttributeName);
                        if (attrRR == null)
                        {
                            attrRR = new Attribute<Bridge>(new AttributeType<Bridge>(AttributeName), bridge);
                            f.Attributes.Add(attrRR);
                        }
                        else
                        {
                            attrRR.AttrValue = bridge;
                        }
                    }
                }
            }
        }

        private IEnumerable<Bridge> LoadBridgesByIds(List<long> ids)
        {
            return _bridgeManager.GetBridgesByFeatureObjectIDs(ids);
        }
    }
}
