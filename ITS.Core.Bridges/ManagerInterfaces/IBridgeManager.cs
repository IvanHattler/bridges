using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.Core.ManagerInterfaces;
using ITS.Core.Bridges.Domain;
using ITS.Core.Domain.Photos;

namespace ITS.Core.Bridges.ManagerInterfaces
{
    public interface IBridgeManager : IManager<Bridge, long>
    {
        List<Bridge> GetBridgesByFeatureObjectIDs(List<long> ids);

        Bridge GetByFeature(long featureId);

        IEnumerable<Bridge> FilterBridges(ICollection<Core.Domain.Filters.Filter> bridgeFilters);

        IEnumerable<Photo> GetPhotosByBridge(Bridge bridge);

        int GetFeatureVersion(long objectId);

        Dictionary<long, Dictionary<long, string>> GetBridgesInfoByFeatureObjectIDs(IEnumerable<long> featureIds);

        Dictionary<long, string> GetBridgeInfoByFeatureObjectID(long featureId);
    }
}
