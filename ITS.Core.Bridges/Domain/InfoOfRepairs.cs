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
    /// Информация о ремонтах, реконструкциях
    /// </summary>
    [Serializable]
    public class InfoOfRepairs : DomainObject<long>, IBridgeReferenceable
    {
        /// <summary>
        /// Работы
        /// </summary>
        public ReconstructionJobs Jobs { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }
        public Bridge Bridge { get; set; }

        /// <summary>
        /// Работы в виде строки
        /// </summary>
        public string JobsAsString =>
            ReconstructionJobsStrings.Instance.GetName(Jobs);

        public InfoOfRepairs() { }
        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T)
        {
            if (T is InfoOfRepairs infoOfRepairs)
            {
                Jobs = infoOfRepairs.Jobs;
                Date = infoOfRepairs.Date;
                Bridge = infoOfRepairs.Bridge;
            }
        }
        public override string ToString()
        {
            string date = 
                Date == DateTime.MinValue 
                ? "Нет данных" 
                : Date.ToShortDateString();
            return $"{date}:{JobsAsString}";
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
            var hashCode = -1044384604;
            hashCode = hashCode * -1521134295 + Jobs.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }
    }
}
