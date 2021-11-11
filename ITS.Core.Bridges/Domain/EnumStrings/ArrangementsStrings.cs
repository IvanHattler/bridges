using ITS.Core.Bridges.Domain.Enums;
using System;
using System.Text;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления Arrangements (Обустройство) в строку и обратно
	/// </summary>
	public class ArrangementsStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<Arrangements>
	{
		/// <summary>
		/// Отсутствуют
		/// </summary>
		private static readonly string StrNone = "Отсутствуют";
		/// <summary>
		/// Лестницы
		/// </summary>
		private static readonly string StrStairs = "Лестницы";
		/// <summary>
		/// Тележки смотровые
		/// </summary>
		private static readonly string StrInspectionTrolleys = "Тележки смотровые";
		/// <summary>
		/// Люльки
		/// </summary>
		private static readonly string StrCradles = "Люльки";
		/// <summary>
		/// Смотровые хода
		/// </summary>
		private static readonly string StrObservationMoves = "Смотровые хода";
		/// <summary>
		/// Люки
		/// </summary>
		private static readonly string StrHatches = "Люки";
		/// <summary>
		/// Двери
		/// </summary>
		private static readonly string StrDoors = "Двери";
		private readonly StringBuilder stringBuilder = new StringBuilder();

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public ArrangementsStrings() { }
		private static ArrangementsStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static ArrangementsStrings Instance
			=> instance ?? (instance = new ArrangementsStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления Arrangements (Обустройство)
		/// </summary>
		/// <param name="arrangements">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(Arrangements arrangements)
		{
			stringBuilder.Clear();
			bool first = true;
			if(arrangements == Arrangements.NoData)
			{
				return "Нет данных";
			}
			if ((arrangements & Arrangements.None) == Arrangements.None)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrNone);
				first = false;
			}
			if ((arrangements & Arrangements.Stairs) == Arrangements.Stairs)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrStairs);
				first = false;
			}
			if ((arrangements & Arrangements.InspectionTrolleys) == Arrangements.InspectionTrolleys)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrInspectionTrolleys);
				first = false;
			}
			if ((arrangements & Arrangements.Cradles) == Arrangements.Cradles)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrCradles);
				first = false;
			}
			if ((arrangements & Arrangements.ObservationMoves) == Arrangements.ObservationMoves)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrObservationMoves);
				first = false;
			}
			if ((arrangements & Arrangements.Hatches) == Arrangements.Hatches)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrHatches);
				first = false;
			}
			if ((arrangements & Arrangements.Doors) == Arrangements.Doors)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrDoors);
				first = false;
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Метод для элемента перечисления Arrangements (Обустройство) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override Arrangements GetElement(string name)
		{
			var tmp = name.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
			var res = Arrangements.NoData;
			foreach (var item in tmp)
			{
				if (item == StrNone)
					res |= Arrangements.None;
				else if (item == StrStairs)
					res |= Arrangements.Stairs;
				else if (item == StrInspectionTrolleys)
					res |= Arrangements.InspectionTrolleys;
				else if (item == StrCradles)
					res |= Arrangements.Cradles;
				else if (item == StrObservationMoves)
					res |= Arrangements.ObservationMoves;
				else if (item == StrHatches)
					res |= Arrangements.Hatches;
				else if (item == StrDoors)
					res |= Arrangements.Doors;
			}
			return res;
		}
	}
}