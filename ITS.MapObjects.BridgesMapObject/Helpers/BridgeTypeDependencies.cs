using ITS.Core.Bridges.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public class BridgeTypeDependencies
    {
        public static ObstacleType[] GetAllowedObstacleTypes(BridgeType bridgeType)
        {
            switch (bridgeType)
            {
                case BridgeType.Overpass:
                    return new[] { ObstacleType.Road, ObstacleType.Railway, ObstacleType.TunnelOverpass,
                        ObstacleType.PowerLine };
                case BridgeType.Estacada:
                    break;//ничего
                case BridgeType.CattleDrive:
                    break;
                case BridgeType.Pontoon:
                    break;
                case BridgeType.FillType:
                    break;
                case BridgeType.Viaduct:
                    return new[] { ObstacleType.Ravine, ObstacleType.FloodedMeadow, ObstacleType.Gorge,
                        ObstacleType.Beam, ObstacleType.PowerLine};
                case BridgeType.Aqueduct:
                    return new[] { ObstacleType.Ravine, ObstacleType.FloodedMeadow, ObstacleType.Gorge,
                        ObstacleType.Beam, ObstacleType.PowerLine };
                case BridgeType.FlyingFerry:
                    break;
                case BridgeType.Drawbridge:
                    break;
                case BridgeType.Bridge:
                    return new[] { ObstacleType.River, ObstacleType.Lake, ObstacleType.Stream,
                    ObstacleType.Sukhodol, ObstacleType.FloodedMeadow, ObstacleType.Swamp, ObstacleType.Channel,
                    ObstacleType.PowerLine};
                case BridgeType.Tunnel:
                    return new[] { ObstacleType.Road, ObstacleType.Railway, ObstacleType.TunnelOverpass };
                case BridgeType.NoData:
                    break;
            }
            return Enum.GetValues(typeof(ObstacleType)).Cast<ObstacleType>().ToArray();
        }
    }
}
