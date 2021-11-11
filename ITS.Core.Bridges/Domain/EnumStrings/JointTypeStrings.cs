using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления JointType (Тип стыков) в строку и обратно
	/// </summary>
	public class JointTypeStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<JointType>
	{
		/// <summary>
		/// Клепка
		/// </summary>
		private static readonly string StrRiveting = "Клепка";
		/// <summary>
		/// Сварка
		/// </summary>
		private static readonly string StrWelding = "Сварка";
		/// <summary>
		/// Высокопрочные болты
		/// </summary>
		private static readonly string StrHighStrengthBolts = "Высокопрочные болты";
		/// <summary>
		/// Мокрые со сваркой выпусков
		/// </summary>
		private static readonly string StrWetWeldedOutlets = "Мокрые со сваркой выпусков";
		/// <summary>
		/// Клеенные зубчатые
		/// </summary>
		private static readonly string StrGluedToothed = "Клеенные зубчатые";
		/// <summary>
		/// Полусухие
		/// </summary>
		private static readonly string StrSemiDry = "Полусухие";
		/// <summary>
		/// Сухие
		/// </summary>
		private static readonly string StrDry = "Сухие";
		/// <summary>
		/// Клееный с уступом
		/// </summary>
		private static readonly string StrGuedWithLedge = "Клееный с уступом";
		/// <summary>
		/// Клееный плоский
		/// </summary>
		private static readonly string StrGluedFlat = "Клееный плоский";
		/// <summary>
		/// Бетонируемые
		/// </summary>
		private static readonly string StrConcreted = "Бетонируемые";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public JointTypeStrings() { }
		private static JointTypeStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static JointTypeStrings Instance
			=> instance ?? (instance = new JointTypeStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления JointType (Тип стыков)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(JointType enumElement)
		{
			switch(enumElement)
			{
				case JointType.Riveting:
					return StrRiveting;
				case JointType.Welding:
					return StrWelding;
				case JointType.HighStrengthBolts:
					return StrHighStrengthBolts;
				case JointType.WetWeldedOutlets:
					return StrWetWeldedOutlets;
				case JointType.GluedToothed:
					return StrGluedToothed;
				case JointType.SemiDry:
					return StrSemiDry;
				case JointType.Dry:
					return StrDry;
				case JointType.GuedWithLedge:
					return StrGuedWithLedge;
				case JointType.GluedFlat:
					return StrGluedFlat;
				case JointType.Concreted:
					return StrConcreted;
				case JointType.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления JointType (Тип стыков) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override JointType GetElement(string name)
		{
			if (name == StrRiveting)
				return JointType.Riveting;
			if (name == StrWelding)
				return JointType.Welding;
			if (name == StrHighStrengthBolts)
				return JointType.HighStrengthBolts;
			if (name == StrWetWeldedOutlets)
				return JointType.WetWeldedOutlets;
			if (name == StrGluedToothed)
				return JointType.GluedToothed;
			if (name == StrSemiDry)
				return JointType.SemiDry;
			if (name == StrDry)
				return JointType.Dry;
			if (name == StrGuedWithLedge)
				return JointType.GuedWithLedge;
			if (name == StrGluedFlat)
				return JointType.GluedFlat;
			if (name == StrConcreted)
				return JointType.Concreted;
			if (name == StrNoData)
				return JointType.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}