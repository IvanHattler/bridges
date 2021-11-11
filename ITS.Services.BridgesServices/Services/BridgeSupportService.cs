using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;
using ITS.Core;
using ITS.Core.Security;
using ITS.Core.Bridges.DataInterfaces;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.ServiceInterfaces;
using ITS.ProjectBase.Data;
using ITS.ProjectBase.Service;
using ITS.ProjectBase.Utils.ExceptionHandling;
using ITS.ProjectBase.Utils.WCF.Compressor;
using ITS.ProjectBase.Utils.WCF.FaultContracts;
using ITS.Core.Domain.Photos;

namespace ITS.Services.BridgesServices.Services
{
    [MessageCompression(Compress.Reply | Compress.Request)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
        InstanceContextMode = InstanceContextMode.PerSession,
        UseSynchronizationContext = false,
        AutomaticSessionShutdown = true)]
    public class BridgeSupportService : AbstractService<BridgeSupport, long>, IBridgeSupportService
    {
        protected override IDAO<BridgeSupport, long> GetDAO()
        {
            try
            {
                return ApplicationService.GetDaoService().GetDao<IBridgeSupportDAO>();
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                throw;
            }
        }
    }
    
}
