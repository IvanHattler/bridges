using ITS.Core.Bridges.Domain;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public static class BridgeAttributeHelper
    {
        /// <summary>
        /// Получить атрибут геометрии по его названию.
        /// </summary>
        /// <param name="feature">Геометрия</param>
        /// <param name="name">Название атрибута</param>
        /// <returns></returns>
        public static IAttribute GetAttribute(IFeature feature, string name)
        {
            return feature.Attributes.Find(a => a.AttrType.Name == name);
        }

        public static Bridge GetBridgeByAttribute(IFeature feature)
        {
            var attr = (Attribute<Bridge>)GetAttribute(feature, BridgeConstants.BridgeAttributeName);
            return attr == null ? null : attr.AttrValue;
        }
    }
}
