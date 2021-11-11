using ITS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Domain
{
    /// <summary>
    /// Код территории хранится в ID
    /// </summary>
    [Serializable]
    public class Territory : DomainObject<long>
    {
        /// <summary>
        /// Название территории
        /// </summary>
        public string Name { get; set; }
        //public int Code { get; set; }

        public Territory(string name)
        {
            Name = name;
        }
        public Territory() { }
        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T) { }
        public override string ToString()
        {
            return $"{Name} - {ID.ToString("D2")}";
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
            var hashCode = -1288459504;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            return hashCode;
        }
    }
}
