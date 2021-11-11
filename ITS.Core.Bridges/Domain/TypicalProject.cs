using ITS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Domain
{
    /// <summary>
    /// Типовой проект
    /// </summary>
    [Serializable]
    public class TypicalProject : DomainObject<long>, IEquatable<TypicalProject>
    {
        /// <summary>
        /// Название типового проекта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// К чему относится проект: опоры или пролётные строения
        /// </summary>
        public string Target { get; set; }
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

        public bool Equals(TypicalProject other)
        {
            return other != null &&
                other.Name == Name &&
                other.Target == Target;
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
            var hashCode = -985799836;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Target);
            return hashCode;
        }
    }
}
