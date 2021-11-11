using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления AdapterPlatesAvailability (Наличие переходных плит) в строку и обратно
	/// </summary>
	public class AdapterPlatesAvailabilityStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<AdapterPlatesAvailability>
	{
		/// <summary>
		/// Нет (0)
		/// </summary>
		private static readonly string StrNo = "Нет (0)";
		/// <summary>
		/// Есть (1)
		/// </summary>
		private static readonly string StrYes = "Есть (1)";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public AdapterPlatesAvailabilityStrings() { }
		private static AdapterPlatesAvailabilityStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static AdapterPlatesAvailabilityStrings Instance
			=> instance ?? (instance = new AdapterPlatesAvailabilityStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления AdapterPlatesAvailability (Наличие переходных плит)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(AdapterPlatesAvailability enumElement)
		{
			switch(enumElement)
			{
				case AdapterPlatesAvailability.No:
					return StrNo;
				case AdapterPlatesAvailability.Yes:
					return StrYes;
				case AdapterPlatesAvailability.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления AdapterPlatesAvailability (Наличие переходных плит) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override AdapterPlatesAvailability GetElement(string name)
		{
			if (name == StrNo)
				return AdapterPlatesAvailability.No;
			if (name == StrYes)
				return AdapterPlatesAvailability.Yes;
			if (name == StrNoData)
				return AdapterPlatesAvailability.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}