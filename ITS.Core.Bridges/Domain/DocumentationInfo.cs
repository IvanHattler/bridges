using ITS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Domain
{
    /// <summary>
    /// Информация о технической документации
    /// </summary>
    [Serializable]
    public class DocumentationInfo : DomainObject<long>, INumberable, IBridgeReferenceable
    {
        /// <summary>
        /// Номер документа
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Название, год изготовления
        /// </summary>
        public string NameAndDate { get; set; }
        /// <summary>
        /// Изготовитель
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// Место хранения
        /// </summary>
        public string Storage { get; set; }
        public Bridge Bridge { get; set; }

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public DocumentationInfo() { }
        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T)
        {
            if (!(T is DocumentationInfo doc))
                return;
            Number = doc.Number;
            NameAndDate = doc.NameAndDate;
            Creator = doc.Creator;
            Storage = doc.Storage;
            Bridge = doc.Bridge;
        }
        public override string ToString()
        {

            return $"Номер: {Number}, Название, год изготовления: {NameAndDate}, Изготовитель: {Creator}, Место хранения: {Storage}";
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
            var hashCode = -970884650;
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NameAndDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Creator);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Storage);
            return hashCode;
        }
    }
}
