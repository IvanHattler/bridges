using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления LocationInPlan (Расположение в плане) в строку и обратно
	/// </summary>
	public class LocationInPlanStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<LocationInPlan>
	{
		/// <summary>
		/// Прямое
		/// </summary>
		private static readonly string StrDirect = "Прямое";
		/// <summary>
		/// Косое
		/// </summary>
		private static readonly string StrOblique = "Косое";
		/// <summary>
		/// Криволинейное
		/// </summary>
		private static readonly string StrСurvilinear = "Криволинейное";
		/// <summary>
		/// Сложное
		/// </summary>
		private static readonly string StrComplicated = "Сложное";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public LocationInPlanStrings() { }
		private static LocationInPlanStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static LocationInPlanStrings Instance
			=> instance ?? (instance = new LocationInPlanStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления LocationInPlan (Расположение в плане)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(LocationInPlan enumElement)
		{
			switch(enumElement)
			{
				case LocationInPlan.Direct:
					return StrDirect;
				case LocationInPlan.Oblique:
					return StrOblique;
				case LocationInPlan.Сurvilinear:
					return StrСurvilinear;
				case LocationInPlan.Complicated:
					return StrComplicated;
				case LocationInPlan.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления LocationInPlan (Расположение в плане) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override LocationInPlan GetElement(string name)
		{
			if (name == StrDirect)
				return LocationInPlan.Direct;
			if (name == StrOblique)
				return LocationInPlan.Oblique;
			if (name == StrСurvilinear)
				return LocationInPlan.Сurvilinear;
			if (name == StrComplicated)
				return LocationInPlan.Complicated;
			if (name == StrNoData)
				return LocationInPlan.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}