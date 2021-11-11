using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления SpanBeamType (Тип балок) в строку и обратно
	/// </summary>
	public class SpanBeamTypeStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<SpanBeamType>
	{
		/// <summary>
		/// Плитные с ненапрягаемой арматурой для прямых участков пути
		/// </summary>
		private static readonly string StrSlabsTensionFreeStraightTrackSections = "Плитные с ненапрягаемой арматурой для прямых участков пути";
		/// <summary>
		/// Плитные с ненапрягаемой арматурой для кривых участков пути
		/// </summary>
		private static readonly string StrSlabsTensionFreeCurvedTrackSections = "Плитные с ненапрягаемой арматурой для кривых участков пути";
		/// <summary>
		/// Плитные с ненапрягаемой арматурой для стационарных пролётных строений
		/// </summary>
		private static readonly string StrSlabsTensionFreeStationarySpans = "Плитные с ненапрягаемой арматурой для стационарных пролётных строений";
		/// <summary>
		/// Ребристые с ненапрягаемой арматурой для кривых участков пути
		/// </summary>
		private static readonly string StrRibbedTensionFreeCurvedTrackSections = "Ребристые с ненапрягаемой арматурой для кривых участков пути";
		/// <summary>
		/// Станционные с предварительно напрягаемой арматурой для прямых участков пути
		/// </summary>
		private static readonly string StrStationaryPrestressedStraightTrackSections = "Станционные с предварительно напрягаемой арматурой для прямых участков пути";
		/// <summary>
		/// Станционные с предварительно напрягаемой арматурой для кривых участков пути
		/// </summary>
		private static readonly string StrStationaryPrestressedCurvedTrackSections = "Станционные с предварительно напрягаемой арматурой для кривых участков пути";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public SpanBeamTypeStrings() { }
		private static SpanBeamTypeStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static SpanBeamTypeStrings Instance
			=> instance ?? (instance = new SpanBeamTypeStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления SpanBeamType (Тип балок)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(SpanBeamType enumElement)
		{
			switch(enumElement)
			{
				case SpanBeamType.SlabsTensionFreeStraightTrackSections:
					return StrSlabsTensionFreeStraightTrackSections;
				case SpanBeamType.SlabsTensionFreeCurvedTrackSections:
					return StrSlabsTensionFreeCurvedTrackSections;
				case SpanBeamType.SlabsTensionFreeStationarySpans:
					return StrSlabsTensionFreeStationarySpans;
				case SpanBeamType.RibbedTensionFreeCurvedTrackSections:
					return StrRibbedTensionFreeCurvedTrackSections;
				case SpanBeamType.StationaryPrestressedStraightTrackSections:
					return StrStationaryPrestressedStraightTrackSections;
				case SpanBeamType.StationaryPrestressedCurvedTrackSections:
					return StrStationaryPrestressedCurvedTrackSections;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления SpanBeamType (Тип балок) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override SpanBeamType GetElement(string name)
		{
			if (name == StrSlabsTensionFreeStraightTrackSections)
				return SpanBeamType.SlabsTensionFreeStraightTrackSections;
			if (name == StrSlabsTensionFreeCurvedTrackSections)
				return SpanBeamType.SlabsTensionFreeCurvedTrackSections;
			if (name == StrSlabsTensionFreeStationarySpans)
				return SpanBeamType.SlabsTensionFreeStationarySpans;
			if (name == StrRibbedTensionFreeCurvedTrackSections)
				return SpanBeamType.RibbedTensionFreeCurvedTrackSections;
			if (name == StrStationaryPrestressedStraightTrackSections)
				return SpanBeamType.StationaryPrestressedStraightTrackSections;
			if (name == StrStationaryPrestressedCurvedTrackSections)
				return SpanBeamType.StationaryPrestressedCurvedTrackSections;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}