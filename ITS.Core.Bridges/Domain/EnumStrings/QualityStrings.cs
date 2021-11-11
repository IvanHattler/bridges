using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления Quality (Качество мостового сооружения) в строку и обратно
	/// </summary>
	public class QualityStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<Quality>
	{
		/// <summary>
		/// 1
		/// </summary>
		private static readonly string StrGrade1 = "1";
		/// <summary>
		/// 2
		/// </summary>
		private static readonly string StrGrade2 = "2";
		/// <summary>
		/// 3
		/// </summary>
		private static readonly string StrGrade3 = "3";
		/// <summary>
		/// 4
		/// </summary>
		private static readonly string StrGrade4 = "4";
		/// <summary>
		/// 5
		/// </summary>
		private static readonly string StrGrade5 = "5";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public QualityStrings() { }
		private static QualityStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static QualityStrings Instance
			=> instance ?? (instance = new QualityStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления Quality (Качество мостового сооружения)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(Quality enumElement)
		{
			switch(enumElement)
			{
				case Quality.Grade1:
					return StrGrade1;
				case Quality.Grade2:
					return StrGrade2;
				case Quality.Grade3:
					return StrGrade3;
				case Quality.Grade4:
					return StrGrade4;
				case Quality.Grade5:
					return StrGrade5;
				case Quality.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления Quality (Качество мостового сооружения) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override Quality GetElement(string name)
		{
			if (name == StrGrade1)
				return Quality.Grade1;
			if (name == StrGrade2)
				return Quality.Grade2;
			if (name == StrGrade3)
				return Quality.Grade3;
			if (name == StrGrade4)
				return Quality.Grade4;
			if (name == StrGrade5)
				return Quality.Grade5;
			if (name == StrNoData)
				return Quality.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}