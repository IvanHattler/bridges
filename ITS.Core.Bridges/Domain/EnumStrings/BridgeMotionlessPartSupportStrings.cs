using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления BridgeMotionlessPartSupport (Тип неподвижных опорных частей) в строку и обратно
	/// </summary>
	public class BridgeMotionlessPartSupportStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<BridgeMotionlessPartSupport>
	{
		/// <summary>
		/// Отсутствуют
		/// </summary>
		private static readonly string StrNone = "Отсутствуют";
		/// <summary>
		/// Прокладки из рубероида
		/// </summary>
		private static readonly string StrRoofingMaterialGaskets = "Прокладки из рубероида";
		/// <summary>
		/// Плоские (под балкой одна стальная пластина)
		/// </summary>
		private static readonly string StrFlat = "Плоские (под балкой одна стальная пластина)";
		/// <summary>
		/// Тангенциальные металлические
		/// </summary>
		private static readonly string StrTangentialMetal = "Тангенциальные металлические";
		/// <summary>
		/// Резино - фторопластовые (резина в обойме)
		/// </summary>
		private static readonly string StrRubberFluoroplastic = "Резино - фторопластовые (резина в обойме)";
		/// <summary>
		/// Балансирные
		/// </summary>
		private static readonly string StrBalancing = "Балансирные";
		/// <summary>
		/// Комбинированные
		/// </summary>
		private static readonly string StrCombined = "Комбинированные";
		/// <summary>
		/// Шаровые сегментные
		/// </summary>
		private static readonly string StrBallSegment = "Шаровые сегментные";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public BridgeMotionlessPartSupportStrings() { }
		private static BridgeMotionlessPartSupportStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static BridgeMotionlessPartSupportStrings Instance
			=> instance ?? (instance = new BridgeMotionlessPartSupportStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления BridgeMotionlessPartSupport (Тип неподвижных опорных частей)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(BridgeMotionlessPartSupport enumElement)
		{
			switch(enumElement)
			{
				case BridgeMotionlessPartSupport.None:
					return StrNone;
				case BridgeMotionlessPartSupport.RoofingMaterialGaskets:
					return StrRoofingMaterialGaskets;
				case BridgeMotionlessPartSupport.Flat:
					return StrFlat;
				case BridgeMotionlessPartSupport.TangentialMetal:
					return StrTangentialMetal;
				case BridgeMotionlessPartSupport.RubberFluoroplastic:
					return StrRubberFluoroplastic;
				case BridgeMotionlessPartSupport.Balancing:
					return StrBalancing;
				case BridgeMotionlessPartSupport.Combined:
					return StrCombined;
				case BridgeMotionlessPartSupport.BallSegment:
					return StrBallSegment;
				case BridgeMotionlessPartSupport.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления BridgeMotionlessPartSupport (Тип неподвижных опорных частей) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override BridgeMotionlessPartSupport GetElement(string name)
		{
			if (name == StrNone)
				return BridgeMotionlessPartSupport.None;
			if (name == StrRoofingMaterialGaskets)
				return BridgeMotionlessPartSupport.RoofingMaterialGaskets;
			if (name == StrFlat)
				return BridgeMotionlessPartSupport.Flat;
			if (name == StrTangentialMetal)
				return BridgeMotionlessPartSupport.TangentialMetal;
			if (name == StrRubberFluoroplastic)
				return BridgeMotionlessPartSupport.RubberFluoroplastic;
			if (name == StrBalancing)
				return BridgeMotionlessPartSupport.Balancing;
			if (name == StrCombined)
				return BridgeMotionlessPartSupport.Combined;
			if (name == StrBallSegment)
				return BridgeMotionlessPartSupport.BallSegment;
			if (name == StrNoData)
				return BridgeMotionlessPartSupport.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}