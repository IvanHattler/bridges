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
    public interface ISpanStructureService : IAbstractService<SpanStructure, long>
    {

    }
}
