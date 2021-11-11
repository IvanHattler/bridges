using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления SpanStructureType (Тип главной опоры) в строку и обратно
	/// </summary>
	public class SpanStructureTypeStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<SpanStructureType>
	{
		/// <summary>
		/// Плита
		/// </summary>
		private static readonly string StrPlate = "Плита";
		/// <summary>
		/// Плита П-образная
		/// </summary>
		private static readonly string StrUShapedPlate = "Плита П-образная";
		/// <summary>
		/// Балка ребристая с диафрагмами
		/// </summary>
		private static readonly string StrRibbedBeamWithDiaphragms = "Балка ребристая с диафрагмами";
		/// <summary>
		/// Балка ребристая без диафрагм
		/// </summary>
		private static readonly string StrRibbedBeamWithoutDiaphragms = "Балка ребристая без диафрагм";
		/// <summary>
		/// Коробка
		/// </summary>
		private static readonly string StrBox = "Коробка";
		/// <summary>
		/// Коробка многоячеистая
		/// </summary>
		private static readonly string StrMultiCellBox = "Коробка многоячеистая";
		/// <summary>
		/// Ферма
		/// </summary>
		private static readonly string StrFarm = "Ферма";
		/// <summary>
		/// Прочее
		/// </summary>
		private static readonly string StrOther = "Прочее";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public SpanStructureTypeStrings() { }
		private static SpanStructureTypeStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static SpanStructureTypeStrings Instance
			=> instance ?? (instance = new SpanStructureTypeStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления SpanStructureType (Тип главной опоры)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(SpanStructureType enumElement)
		{
			switch(enumElement)
			{
				case SpanStructureType.Plate:
					return StrPlate;
				case SpanStructureType.UShapedPlate:
					return StrUShapedPlate;
				case SpanStructureType.RibbedBeamWithDiaphragms:
					return StrRibbedBeamWithDiaphragms;
				case SpanStructureType.RibbedBeamWithoutDiaphragms:
					return StrRibbedBeamWithoutDiaphragms;
				case SpanStructureType.Box:
					return StrBox;
				case SpanStructureType.MultiCellBox:
					return StrMultiCellBox;
				case SpanStructureType.Farm:
					return StrFarm;
				case SpanStructureType.Other:
					return StrOther;
				case SpanStructureType.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления SpanStructureType (Тип главной опоры) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override SpanStructureType GetElement(string name)
		{
			if (name == StrPlate)
				return SpanStructureType.Plate;
			if (name == StrUShapedPlate)
				return SpanStructureType.UShapedPlate;
			if (name == StrRibbedBeamWithDiaphragms)
				return SpanStructureType.RibbedBeamWithDiaphragms;
			if (name == StrRibbedBeamWithoutDiaphragms)
				return SpanStructureType.RibbedBeamWithoutDiaphragms;
			if (name == StrBox)
				return SpanStructureType.Box;
			if (name == StrMultiCellBox)
				return SpanStructureType.MultiCellBox;
			if (name == StrFarm)
				return SpanStructureType.Farm;
			if (name == StrOther)
				return SpanStructureType.Other;
			if (name == StrNoData)
				return SpanStructureType.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}