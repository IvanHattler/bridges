using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления ObstacleType (Тип препятствия) в строку и обратно
	/// </summary>
	public class ObstacleTypeStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<ObstacleType>
	{
		/// <summary>
		/// Река
		/// </summary>
		private static readonly string StrRiver = "Река";
		/// <summary>
		/// Ручей
		/// </summary>
		private static readonly string StrStream = "Ручей";
		/// <summary>
		/// Суходол
		/// </summary>
		private static readonly string StrSukhodol = "Суходол";
		/// <summary>
		/// Железная дорога
		/// </summary>
		private static readonly string StrRailway = "Железная дорога";
		/// <summary>
		/// Автодорога
		/// </summary>
		private static readonly string StrRoad = "Автодорога";
		/// <summary>
		/// Овраг
		/// </summary>
		private static readonly string StrRavine = "Овраг";
		/// <summary>
		/// Балка
		/// </summary>
		private static readonly string StrBeam = "Балка";
		/// <summary>
		/// Затапливаемый луг
		/// </summary>
		private static readonly string StrFloodedMeadow = "Затапливаемый луг";
		/// <summary>
		/// Ущелье
		/// </summary>
		private static readonly string StrGorge = "Ущелье";
		/// <summary>
		/// Болото
		/// </summary>
		private static readonly string StrSwamp = "Болото";
		/// <summary>
		/// Плотина
		/// </summary>
		private static readonly string StrDam = "Плотина";
		/// <summary>
		/// Канал
		/// </summary>
		private static readonly string StrChannel = "Канал";
		/// <summary>
		/// Озеро
		/// </summary>
		private static readonly string StrLake = "Озеро";
		/// <summary>
		/// Скотопрогон
		/// </summary>
		private static readonly string StrCattleDrive = "Скотопрогон";
		/// <summary>
		/// Линия электропередач
		/// </summary>
		private static readonly string StrPowerLine = "Линия электропередач";
		/// <summary>
		/// Тоннельный путепровод
		/// </summary>
		private static readonly string StrTunnelOverpass = "Тоннельный путепровод";
		/// <summary>
		/// Другие препятствия
		/// </summary>
		private static readonly string StrOther = "Другие препятствия";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public ObstacleTypeStrings() { }
		private static ObstacleTypeStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static ObstacleTypeStrings Instance
			=> instance ?? (instance = new ObstacleTypeStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления ObstacleType (Тип препятствия)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(ObstacleType enumElement)
		{
			switch(enumElement)
			{
				case ObstacleType.River:
					return StrRiver;
				case ObstacleType.Stream:
					return StrStream;
				case ObstacleType.Sukhodol:
					return StrSukhodol;
				case ObstacleType.Railway:
					return StrRailway;
				case ObstacleType.Road:
					return StrRoad;
				case ObstacleType.Ravine:
					return StrRavine;
				case ObstacleType.Beam:
					return StrBeam;
				case ObstacleType.FloodedMeadow:
					return StrFloodedMeadow;
				case ObstacleType.Gorge:
					return StrGorge;
				case ObstacleType.Swamp:
					return StrSwamp;
				case ObstacleType.Dam:
					return StrDam;
				case ObstacleType.Channel:
					return StrChannel;
				case ObstacleType.Lake:
					return StrLake;
				case ObstacleType.CattleDrive:
					return StrCattleDrive;
				case ObstacleType.PowerLine:
					return StrPowerLine;
				case ObstacleType.TunnelOverpass:
					return StrTunnelOverpass;
				case ObstacleType.Other:
					return StrOther;
				case ObstacleType.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления ObstacleType (Тип препятствия) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override ObstacleType GetElement(string name)
		{
			if (name == StrRiver)
				return ObstacleType.River;
			if (name == StrStream)
				return ObstacleType.Stream;
			if (name == StrSukhodol)
				return ObstacleType.Sukhodol;
			if (name == StrRailway)
				return ObstacleType.Railway;
			if (name == StrRoad)
				return ObstacleType.Road;
			if (name == StrRavine)
				return ObstacleType.Ravine;
			if (name == StrBeam)
				return ObstacleType.Beam;
			if (name == StrFloodedMeadow)
				return ObstacleType.FloodedMeadow;
			if (name == StrGorge)
				return ObstacleType.Gorge;
			if (name == StrSwamp)
				return ObstacleType.Swamp;
			if (name == StrDam)
				return ObstacleType.Dam;
			if (name == StrChannel)
				return ObstacleType.Channel;
			if (name == StrLake)
				return ObstacleType.Lake;
			if (name == StrCattleDrive)
				return ObstacleType.CattleDrive;
			if (name == StrPowerLine)
				return ObstacleType.PowerLine;
			if (name == StrTunnelOverpass)
				return ObstacleType.TunnelOverpass;
			if (name == StrOther)
				return ObstacleType.Other;
			if (name == StrNoData)
				return ObstacleType.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}