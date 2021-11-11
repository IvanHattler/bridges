using ITS.Core.Bridges.Helpers;
using ITS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Domain
{
    /// <summary>
    /// Тип дефекта
    /// </summary>
    [Serializable]
    public class DefectType : DomainObject<long>
    {
        /// <summary>
        /// Тип дефекта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Паттерн параметров
        /// </summary>
        public string Pattern { get; set; }
        /// <summary>
        /// Раздел дефекта
        /// </summary>
        public DefectScrollSection Section { get; set; }

        /// <summary>
        /// Правила считывания параметров дефекта
        /// </summary>
        public Dictionary<string, string> PatternRules
            => DefectParamsParser.GetRules(Pattern);

        public DefectType() { }
        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T)
        {

        }
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
		/// Играет роль хэш-функции для определенного типа.
		/// </summary>
		/// <returns>
		/// Хэш-код для текущего объекта <see cref="T:System.Object"/>.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
        {
            var hashCode = 162391545;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Pattern);
            hashCode = hashCode * -1521134295 + EqualityComparer<DefectScrollSection>.Default.GetHashCode(Section);
            return hashCode;
        }
    }
}
