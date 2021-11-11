using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.Core.Bridges.Domain;

namespace ITS.MapObjects.BridgesMapObject.IViews
{
    public interface IBridgeEditView : IBaseView
    {
        Bridge Entity { get; set; }
    }
}
