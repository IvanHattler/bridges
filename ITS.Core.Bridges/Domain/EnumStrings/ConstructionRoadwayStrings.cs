using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления ConstructionRoadway (Конструкция проезжей части) в строку и обратно
	/// </summary>
	public class ConstructionRoadwayStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<ConstructionRoadway>
	{
		/// <summary>
		/// Железобетонная плита в составе основной несущей железобетонной конструкции
		/// </summary>
		private static readonly string StrFerroconcreteSlabInMainSupStruct = "Железобетонная плита в составе основной несущей железобетонной конструкции";
		/// <summary>
		/// Железобетонная плита, включенная в совместную работу с металлическими главными балками
		/// </summary>
		private static readonly string StrFerroconcreteSlabWithBeams = "Железобетонная плита, включенная в совместную работу с металлическими главными балками";
		/// <summary>
		/// Железобетонная плита по балкам без объединения
		/// </summary>
		private static readonly string StrFerroconcreteSlabOnBeams = "Железобетонная плита по балкам без объединения";
		/// <summary>
		/// Ортотропная плита в составе главных и поперечных балок
		/// </summary>
		private static readonly string StrOrthotropicSlab = "Ортотропная плита в составе главных и поперечных балок";
		/// <summary>
		/// Деревянная
		/// </summary>
		private static readonly string StrWood = "Деревянная";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public ConstructionRoadwayStrings() { }
		private static ConstructionRoadwayStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static ConstructionRoadwayStrings Instance
			=> instance ?? (instance = new ConstructionRoadwayStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления ConstructionRoadway (Конструкция проезжей части)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(ConstructionRoadway enumElement)
		{
			switch(enumElement)
			{
				case ConstructionRoadway.FerroconcreteSlabInMainSupStruct:
					return StrFerroconcreteSlabInMainSupStruct;
				case ConstructionRoadway.FerroconcreteSlabWithBeams:
					return StrFerroconcreteSlabWithBeams;
				case ConstructionRoadway.FerroconcreteSlabOnBeams:
					return StrFerroconcreteSlabOnBeams;
				case ConstructionRoadway.OrthotropicSlab:
					return StrOrthotropicSlab;
				case ConstructionRoadway.Wood:
					return StrWood;
				case ConstructionRoadway.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления ConstructionRoadway (Конструкция проезжей части) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override ConstructionRoadway GetElement(string name)
		{
			if (name == StrFerroconcreteSlabInMainSupStruct)
				return ConstructionRoadway.FerroconcreteSlabInMainSupStruct;
			if (name == StrFerroconcreteSlabWithBeams)
				return ConstructionRoadway.FerroconcreteSlabWithBeams;
			if (name == StrFerroconcreteSlabOnBeams)
				return ConstructionRoadway.FerroconcreteSlabOnBeams;
			if (name == StrOrthotropicSlab)
				return ConstructionRoadway.OrthotropicSlab;
			if (name == StrWood)
				return ConstructionRoadway.Wood;
			if (name == StrNoData)
				return ConstructionRoadway.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}