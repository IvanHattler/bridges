using ITS.Core.Domain;
using System;
using System.Collections.Generic;

namespace ITS.Core.Bridges.Domain
{
    /// <summary>
    /// Раздел дефекта
    /// </summary>
    [Serializable]
    public class DefectScrollSection : DomainObject<long>
    {
        public string Name { get; set; }
        public string FullName { get; set; }

        public DefectScrollSection() { }
        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T) { }
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
            var hashCode = -1094819469;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            return hashCode;
        }
    }
}