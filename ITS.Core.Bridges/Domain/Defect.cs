using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Bridges.Helpers;
using ITS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Domain
{
    [Serializable]
    public class Defect : DomainObject<long>, IBridgeReferenceable
    {
        //todo: реализовать положение не строкой
        /// <summary>
        /// Положение дефекта
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Тип дефекта
        /// </summary>
        public DefectType Type { get; set; }
        /// <summary>
        /// Параметры
        /// </summary>
        public string Params { get; set; }
        /// <summary>
        /// Категория
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Примечания
        /// </summary>
        public string Notes { get; set; }
        public Bridge Bridge { get; set; }

        public Dictionary<string, string> ParamsValues
            => Type == null ? null : DefectParamsParser.Parse(Params, Type?.Pattern);
        public Dictionary<string, string> PatternRules
            => Type == null ? null : Type.PatternRules;

        public Defect() { }
        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T)
        {
            var obj = T as Defect;
            if (obj == null) return;

            Location = obj.Location;
            Type = obj.Type;
            Params = obj.Params;
            Category = obj.Category;
            Notes = obj.Notes;
            Bridge = obj.Bridge;
        }
        public override string ToString()
        {
            return $"Положение: {Location}, Тип: {Type}, Параметры: {Params}, Категория: {Category}, Примечания: {Notes}";
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
            var hashCode = -953348633;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Location);
            hashCode = hashCode * -1521134295 + EqualityComparer<DefectType>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Params);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Category);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Notes);
            return hashCode;
        }
    }
}
