using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Security;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.Core.Bridges.ServiceInterfaces;
using ITS.Core.Domain.Photos;
using ITS.Managers.BaseManagers;
using ITS.ProjectBase.Utils.ExceptionHandling;
using ITS.ProjectBase.Utils.WCF.FaultContracts;

namespace ITS.Managers.BridgesManagers.Managers
{
    public sealed class DefectTypeManager : AbstractManager<DefectType, long, IDefectTypeService>,
        IDefectTypeManager
    {

    }
}
