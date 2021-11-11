using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.WCF;
using ITS.ProjectBase.Utils.ExceptionHandling;
using ITS.Core.Bridges.Domain;
using ITS.Core.ServiceInterfaces;
using ITS.ProjectBase.Utils.WCF.FaultContracts;
using ITS.Core.Domain.Photos;

namespace ITS.Core.Bridges.ServiceInterfaces
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    [ExceptionShielding(Policies.AbstractServicePolicy)]
    public interface IBridgeService : IAbstractService<Bridge, long>
    {
        [UseNetDataContractSerializer]
        [OperationContract(Action = nameof(GetBridgesByFeatureObjectIDs))]
        [FaultContract(typeof(BaseFault))]
        List<Bridge> GetBridgesByFeatureObjectIDs(List<long> ids);

        [UseNetDataContractSerializer]
        [OperationContract(Action = nameof(GetByFeature))]
        [FaultContract(typeof(BaseFault))]
        Bridge GetByFeature(long featureId);

        [UseNetDataContractSerializer]
        [OperationContract(Action = nameof(FilterBridges))]
        [FaultContract(typeof(BaseFault))]
        [FaultContract(typeof(GeoAccessDeniedFault))]
        IEnumerable<Bridge> FilterBridges(ICollection<ITS.Core.Domain.Filters.Filter> bridgeFilters);

        [UseNetDataContractSerializer]
        [OperationContract(Action = nameof(GetPhotosByBridge))]
        [FaultContract(typeof(BaseFault))]
        IEnumerable<Photo> GetPhotosByBridge(Bridge bridge);

        [UseNetDataContractSerializer]
        [OperationContract(Action = nameof(GetFeatureVersion))]
        [FaultContract(typeof(BaseFault))]
        int GetFeatureVersion(long objectId);

        [UseNetDataContractSerializer]
        [OperationContract(Action = nameof(GetBridgesInfoByFeatureObjectIDs))]
        [FaultContract(typeof(BaseFault))]
        Dictionary<long, Dictionary<long, string>> GetBridgesInfoByFeatureObjectIDs(IEnumerable<long> featureIds);

        [UseNetDataContractSerializer]
        [OperationContract(Action = nameof(GetBridgeInfoByFeatureObjectID))]
        [FaultContract(typeof(BaseFault))]
        Dictionary<long, string> GetBridgeInfoByFeatureObjectID(long featureId);
    }
}
