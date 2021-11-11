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
    /// Пересекаемое препятствие
    /// </summary>
    [Serializable]
    public class BridgeObstacle : DomainObject<long>, IEquatable<BridgeObstacle>, IBridgeReferenceable
    {
        /// <summary>
        /// Тип препятствия
        /// </summary>
        public ObstacleType Type { get; set; }
        /// <summary>
        /// Название препятствия
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Мост, к которому относится
        /// </summary>
        public Bridge Bridge { get; set; }

        /// <summary>
        /// Тип в виде строки
        /// </summary>
        public string TypeAsString =>
             ObstacleTypeStrings.Instance.GetName(Type);
        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public BridgeObstacle() { }
        public BridgeObstacle(ObstacleType type, string name)
        {
            Type = type;
            Name = name;
        }
        
        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T)
        {
            var obst = T as BridgeObstacle;
            if (obst == null) return;

            Bridge = obst.Bridge;
            Name = obst.Name;
            Type = obst.Type;
        }
        /// <summary>
        /// Название типа с маленькой буквы, потом название препятствия
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder(TypeAsString);
            sb[0] = char.ToLower(sb[0]);
            return $"{sb} {Name}";
        }

        public bool Equals(BridgeObstacle other)
        {
            return other != null &&
                other.Type == Type &&
                other.Name == Name;
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
            var hashCode = -1548186239;
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
