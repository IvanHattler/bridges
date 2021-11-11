using ITS.Core.Bridges.Domain.Enums;
using System;
using System.Text;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления MoveType (Тип движения) в строку и обратно
	/// </summary>
	public class MoveTypeStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<MoveType>
	{
		/// <summary>
		/// Автомобильный
		/// </summary>
		private static readonly string StrCar = "Автомобильный";
		/// <summary>
		/// Железнодорожный
		/// </summary>
		private static readonly string StrRailway = "Железнодорожный";
		/// <summary>
		/// Пешеходный и велосипедный
		/// </summary>
		private static readonly string StrPedestrian = "Пешеходный и велосипедный";
		/// <summary>
		/// Для животных
		/// </summary>
		private static readonly string StrForAnimals = "Для животных";
		/// <summary>
		/// Для подачи воды
		/// </summary>
		private static readonly string StrForWaterSupply = "Для подачи воды";
		/// <summary>
		/// Трубопроводный
		/// </summary>
		private static readonly string StrPipeline = "Трубопроводный";
		/// <summary>
		/// Метромост
		/// </summary>
		private static readonly string StrMetroBridge = "Метромост";
		private readonly StringBuilder stringBuilder = new StringBuilder();

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public MoveTypeStrings() { }
		private static MoveTypeStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static MoveTypeStrings Instance
			=> instance ?? (instance = new MoveTypeStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления MoveType (Тип движения)
		/// </summary>
		/// <param name="move_type">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(MoveType move_type)
		{
			stringBuilder.Clear();
			bool first = true;
			if(move_type == MoveType.NoData)
			{
				return "Нет данных";
			}
			if ((move_type & MoveType.Car) == MoveType.Car)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrCar);
				first = false;
			}
			if ((move_type & MoveType.Railway) == MoveType.Railway)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrRailway);
				first = false;
			}
			if ((move_type & MoveType.Pedestrian) == MoveType.Pedestrian)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrPedestrian);
				first = false;
			}
			if ((move_type & MoveType.ForAnimals) == MoveType.ForAnimals)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrForAnimals);
				first = false;
			}
			if ((move_type & MoveType.ForWaterSupply) == MoveType.ForWaterSupply)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrForWaterSupply);
				first = false;
			}
			if ((move_type & MoveType.Pipeline) == MoveType.Pipeline)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrPipeline);
				first = false;
			}
			if ((move_type & MoveType.MetroBridge) == MoveType.MetroBridge)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrMetroBridge);
				first = false;
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Метод для элемента перечисления MoveType (Тип движения) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override MoveType GetElement(string name)
		{
			var tmp = name.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
			var res = MoveType.NoData;
			foreach (var item in tmp)
			{
				if (item == StrCar)
					res |= MoveType.Car;
				else if (item == StrRailway)
					res |= MoveType.Railway;
				else if (item == StrPedestrian)
					res |= MoveType.Pedestrian;
				else if (item == StrForAnimals)
					res |= MoveType.ForAnimals;
				else if (item == StrForWaterSupply)
					res |= MoveType.ForWaterSupply;
				else if (item == StrPipeline)
					res |= MoveType.Pipeline;
				else if (item == StrMetroBridge)
					res |= MoveType.MetroBridge;
			}
			return res;
		}
	}
}