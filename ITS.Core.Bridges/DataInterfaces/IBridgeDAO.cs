using System.Collections.Generic;
using ITS.Core.Domain.Organizations;
using ITS.Core.Bridges.Domain;
using ITS.ProjectBase.Data;
using ITS.Core.Domain.Photos;

namespace ITS.Core.Bridges.DataInterfaces
{
    public interface IBridgeDAO : IDAO<Bridge, long>
    {
        List<Bridge> GetBridgesByFeatureObjectIDs(List<long> ids);

        Bridge GetByFeature(long featureId);

        IEnumerable<Bridge> FilterBridges(ICollection<ITS.Core.Domain.Filters.Filter> bridgeFilters);

        IEnumerable<Photo> GetPhotosByBridge(Bridge bridge);

        int GetFeatureVersion(long objectId);

        Dictionary<long, Dictionary<long, string>> GetBridgesInfoByFeatureObjectIDs(IEnumerable<long> featureIds);

        Dictionary<long, string> GetBridgeInfoByFeatureObjectID(long featureId);
    }
}