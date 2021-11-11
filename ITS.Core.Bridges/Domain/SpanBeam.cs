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
    /// Балка
    /// </summary>
    [Serializable]
    public class SpanBeam : DomainObject<long>, IEquatable<SpanBeam>
    {
        /// <summary>
        /// Тип балки
        /// </summary>
        public SpanBeamType Type { get; set; }
        /// <summary>
        /// Тип балки в виде строки
        /// </summary>
        public string TypeAsString =>
            SpanBeamTypeStrings.Instance.GetName(Type);

        /// <summary>
        /// Количество балок в пролётном строении
        /// </summary>
        public int CountInSpan { get; set; }
        /// <summary>
        /// Высота балки
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// Материал балки
        /// </summary>
        public Material Material { get; set; }

        public SpanBeam(){}
        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(ITS.Core.Domain.DomainObject<long> T)
        {
            var obj = T as SpanBeam;
            if (obj == null) return;
            Type = obj.Type;
            CountInSpan = obj.CountInSpan;
            Height = obj.Height;
            Material = obj.Material;
        }
        public override string ToString()
        {
            return $"Тип:{TypeAsString} Количество:{CountInSpan}, Высота:{Height}, " +
                $"Материал:{Material}";
        }

        public bool Equals(SpanBeam other)
        {
            return other != null &&
                other.Type == Type &&
                other.CountInSpan == CountInSpan &&
                (Math.Abs(other.Height - Height) < 1e-10f) &&
                EqualityComparer<Material>.Default.Equals(other.Material, Material);
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
            var hashCode = 328139084;
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + CountInSpan.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Material>.Default.GetHashCode(Material);
            return hashCode;
        }
    }

}
