using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления SlopeProfile (Профиль уклона) в строку и обратно
	/// </summary>
	public class SlopeProfileStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<SlopeProfile>
	{
		/// <summary>
		/// Λ
		/// </summary>
		private static readonly string StrConvexCurve = "Λ";
		/// <summary>
		/// V
		/// </summary>
		private static readonly string StrConcaveCurve = "V";
		/// <summary>
		/// /
		/// </summary>
		private static readonly string StrUp = "/";
		/// <summary>
		/// \\
		/// </summary>
		private static readonly string StrDown = "\\";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public SlopeProfileStrings() { }
		private static SlopeProfileStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static SlopeProfileStrings Instance
			=> instance ?? (instance = new SlopeProfileStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления SlopeProfile (Профиль уклона)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(SlopeProfile enumElement)
		{
			switch(enumElement)
			{
				case SlopeProfile.ConvexCurve:
					return StrConvexCurve;
				case SlopeProfile.ConcaveCurve:
					return StrConcaveCurve;
				case SlopeProfile.Up:
					return StrUp;
				case SlopeProfile.Down:
					return StrDown;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления SlopeProfile (Профиль уклона) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override SlopeProfile GetElement(string name)
		{
			if (name == StrConvexCurve)
				return SlopeProfile.ConvexCurve;
			if (name == StrConcaveCurve)
				return SlopeProfile.ConcaveCurve;
			if (name == StrUp)
				return SlopeProfile.Up;
			if (name == StrDown)
				return SlopeProfile.Down;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}