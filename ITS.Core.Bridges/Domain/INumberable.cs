using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Domain
{
    /// <summary>
    /// Интерфейс для типов, имеющих порядковый номер
    /// </summary>
    public interface INumberable
    {
        /// <summary>
        /// Порядковый номер данного объекта
        /// </summary>
        int Number { get; set; }
    }
}
