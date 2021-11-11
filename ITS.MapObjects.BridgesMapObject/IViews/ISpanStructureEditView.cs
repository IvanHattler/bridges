using ITS.Core.Bridges.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.MapObjects.BridgesMapObject.IViews
{
    public interface ISpanStructureEditView : IBaseView
    {
        SpanStructure Entity { get; set; }
    }
}
