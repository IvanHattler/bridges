using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Domain
{
    /// <summary>
    /// Интерфейся для типов, являющихся частью мостового сооружения
    /// </summary>
    public interface IBridgeReferenceable
    {
        /// <summary>
        /// Мостовое сооружение, на которое ссылается данный объект
        /// </summary>
        Bridge Bridge { get; set; }
    }
}
