using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using ITS.Core.Domain;

namespace ITS.Core.Bridges.Domain
{
    /// <summary>
    /// Материал.
    /// </summary>
    [Serializable]
    public class Material : DomainObject<long>, IEquatable<Material>
    {
        /// <summary>
        /// Название материала.
        /// </summary>
        public string Name { get; set; }

        public Material()
        {
        }

        public Material(string name)
        {
            Name = name;
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
            var hashCode = 890389916;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        
        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T)
        {
            if( T is Material material)
            {
                Name = material.Name;
            }
        }
        public override string ToString()
        {
            return Name;
        }

        public bool Equals(Material other)
        {
            return other != null &&
                other.Name == Name;
        }
    }
}
