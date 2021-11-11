using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Domain
{
    /// <summary>
    /// Ограждение
    /// </summary>
    [Serializable]
    public class Protection : DomainObject<long>, IEquatable<Protection>
    {
        /// <summary>
        /// Тип ограждения
        /// </summary>
        public ProtectionType Type { get; set; }
        /// <summary>
        /// Высота ограждения
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Тип ограждения в виде строки
        /// </summary>
        public string TypeAsString 
            => ProtectionTypeStrings.Instance.GetName(Type);
        public Protection(ProtectionType type, float height)
        {
            Type = type;
            Height = height;
        }
        public Protection()
        {

        }
        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T)
        {
            if (T is Protection protection)
            {
                Type = protection.Type;
                Height = protection.Height;
            }
        }

        public override string ToString()
        {
            return $"Тип:{TypeAsString}, Высота:{Height}";
        }

        public bool Equals(Protection other)
        {
            return other != null &&
                other.Type == Type &&
                (Math.Abs(other.Height - Height) < 1e-10);
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
            var hashCode = -1347858467;
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            return hashCode;
        }
    }
}
