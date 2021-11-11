using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления RoadCategory (Категория дороги) в строку и обратно
	/// </summary>
	public class RoadCategoryStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<RoadCategory>
	{
		/// <summary>
		/// IА
		/// </summary>
		private static readonly string StrIA = "IА";
		/// <summary>
		/// IБ
		/// </summary>
		private static readonly string StrIB = "IБ";
		/// <summary>
		/// IВ
		/// </summary>
		private static readonly string StrIC = "IВ";
		/// <summary>
		/// II
		/// </summary>
		private static readonly string StrII = "II";
		/// <summary>
		/// III
		/// </summary>
		private static readonly string StrIII = "III";
		/// <summary>
		/// IV
		/// </summary>
		private static readonly string StrIV = "IV";
		/// <summary>
		/// V
		/// </summary>
		private static readonly string StrV = "V";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public RoadCategoryStrings() { }
		private static RoadCategoryStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static RoadCategoryStrings Instance
			=> instance ?? (instance = new RoadCategoryStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления RoadCategory (Категория дороги)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(RoadCategory enumElement)
		{
			switch(enumElement)
			{
				case RoadCategory.IA:
					return StrIA;
				case RoadCategory.IB:
					return StrIB;
				case RoadCategory.IC:
					return StrIC;
				case RoadCategory.II:
					return StrII;
				case RoadCategory.III:
					return StrIII;
				case RoadCategory.IV:
					return StrIV;
				case RoadCategory.V:
					return StrV;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления RoadCategory (Категория дороги) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override RoadCategory GetElement(string name)
		{
			if (name == StrIA)
				return RoadCategory.IA;
			if (name == StrIB)
				return RoadCategory.IB;
			if (name == StrIC)
				return RoadCategory.IC;
			if (name == StrII)
				return RoadCategory.II;
			if (name == StrIII)
				return RoadCategory.III;
			if (name == StrIV)
				return RoadCategory.IV;
			if (name == StrV)
				return RoadCategory.V;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}