using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.Core.Bridges.Domain;

namespace ITS.MapObjects.BridgesMapObject.EventArgses
{
   public class BridgeEventArgs : EventArgs
    {
        public BridgeEventArgs(Bridge bridge)
        {
            Bridge = bridge;
        }

        public Bridge Bridge { get; private set; }

    }
}
