using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления FoundationType (Тип фундамента) в строку и обратно
	/// </summary>
	public class FoundationTypeStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<FoundationType>
	{
		/// <summary>
		/// Свайный
		/// </summary>
		private static readonly string StrPile = "Свайный";
		/// <summary>
		/// Плитный на естественном основании
		/// </summary>
		private static readonly string StrSlabNaturalBase = "Плитный на естественном основании";
		/// <summary>
		/// Низкий свайный ростверк
		/// </summary>
		private static readonly string StrLowPileGrillage = "Низкий свайный ростверк";
		/// <summary>
		/// Высокий свайный ростверк
		/// </summary>
		private static readonly string StrHighPileGrillage = "Высокий свайный ростверк";
		/// <summary>
		/// Безростверковый из отдельных столбов
		/// </summary>
		private static readonly string StrGrillagelessSeparatePillars = "Безростверковый из отдельных столбов";
		/// <summary>
		/// Опускной колодец
		/// </summary>
		private static readonly string StrCoffer = "Опускной колодец";
		/// <summary>
		/// Кессонный
		/// </summary>
		private static readonly string StrCaisson = "Кессонный";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public FoundationTypeStrings() { }
		private static FoundationTypeStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static FoundationTypeStrings Instance
			=> instance ?? (instance = new FoundationTypeStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления FoundationType (Тип фундамента)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(FoundationType enumElement)
		{
			switch(enumElement)
			{
				case FoundationType.Pile:
					return StrPile;
				case FoundationType.SlabNaturalBase:
					return StrSlabNaturalBase;
				case FoundationType.LowPileGrillage:
					return StrLowPileGrillage;
				case FoundationType.HighPileGrillage:
					return StrHighPileGrillage;
				case FoundationType.GrillagelessSeparatePillars:
					return StrGrillagelessSeparatePillars;
				case FoundationType.Coffer:
					return StrCoffer;
				case FoundationType.Caisson:
					return StrCaisson;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления FoundationType (Тип фундамента) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override FoundationType GetElement(string name)
		{
			if (name == StrPile)
				return FoundationType.Pile;
			if (name == StrSlabNaturalBase)
				return FoundationType.SlabNaturalBase;
			if (name == StrLowPileGrillage)
				return FoundationType.LowPileGrillage;
			if (name == StrHighPileGrillage)
				return FoundationType.HighPileGrillage;
			if (name == StrGrillagelessSeparatePillars)
				return FoundationType.GrillagelessSeparatePillars;
			if (name == StrCoffer)
				return FoundationType.Coffer;
			if (name == StrCaisson)
				return FoundationType.Caisson;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}