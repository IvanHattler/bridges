using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Domain.Enums
{
    [Serializable]
    public enum ConstructionType
    {
        /// <summary>
        /// Железобетонный
        /// </summary>
        Ferroconcrete,
        /// <summary>
        /// Каменный
        /// </summary>
        Stone,
        /// <summary>
        /// Металлический
        /// </summary>
        Metall,
        /// <summary>
        /// Деревянный
        /// </summary>
        Wood,
        /// <summary>
        /// Подвесной
        /// </summary>
        Suspension,
        /// <summary>
        /// Наплавной
        /// </summary>
        Floating,
        /// <summary>
        /// Нет данных
        /// </summary>
        NoData,
    }
}
