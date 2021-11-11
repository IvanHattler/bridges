using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления DrainageType (Тип водоотвода) в строку и обратно
	/// </summary>
	public class DrainageTypeStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<DrainageType>
	{
		/// <summary>
		/// Сток воды вдоль проезжей части за счет уклонов за пределы мостового сооружения
		/// </summary>
		private static readonly string StrWaterSlopes = "Сток воды вдоль проезжей части за счет уклонов за пределы мостового сооружения";
		/// <summary>
		/// Через зазоры в проезжей части мостового сооружения
		/// </summary>
		private static readonly string StrTheGapsCarriageway = "Через зазоры в проезжей части мостового сооружения";
		/// <summary>
		/// По лоткам за пределы мостового сооружения
		/// </summary>
		private static readonly string StrByTrays = "По лоткам за пределы мостового сооружения";
		/// <summary>
		/// Сброс воды поперек мостового сооружения через тротуары
		/// </summary>
		private static readonly string StrWaterDischargeSidewalks = "Сброс воды поперек мостового сооружения через тротуары";
		/// <summary>
		/// Водоотвод не организован
		/// </summary>
		private static readonly string StrNone = "Водоотвод не организован";
		/// <summary>
		/// Через водоотводные трубки со сбросом под мостовое сооружение
		/// </summary>
		private static readonly string StrDrainPipesDischargeUnderBridge = "Через водоотводные трубки со сбросом под мостовое сооружение";
		/// <summary>
		/// Через водоотводные трубки с отводом воды по водопроводу вдоль мостового сооружения
		/// </summary>
		private static readonly string StrDrainPipesWaterSupply = "Через водоотводные трубки с отводом воды по водопроводу вдоль мостового сооружения";
		/// <summary>
		/// Комбинированный
		/// </summary>
		private static readonly string StrCombined = "Комбинированный";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public DrainageTypeStrings() { }
		private static DrainageTypeStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static DrainageTypeStrings Instance
			=> instance ?? (instance = new DrainageTypeStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления DrainageType (Тип водоотвода)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(DrainageType enumElement)
		{
			switch(enumElement)
			{
				case DrainageType.WaterSlopes:
					return StrWaterSlopes;
				case DrainageType.TheGapsCarriageway:
					return StrTheGapsCarriageway;
				case DrainageType.ByTrays:
					return StrByTrays;
				case DrainageType.WaterDischargeSidewalks:
					return StrWaterDischargeSidewalks;
				case DrainageType.None:
					return StrNone;
				case DrainageType.DrainPipesDischargeUnderBridge:
					return StrDrainPipesDischargeUnderBridge;
				case DrainageType.DrainPipesWaterSupply:
					return StrDrainPipesWaterSupply;
				case DrainageType.Combined:
					return StrCombined;
				case DrainageType.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления DrainageType (Тип водоотвода) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override DrainageType GetElement(string name)
		{
			if (name == StrWaterSlopes)
				return DrainageType.WaterSlopes;
			if (name == StrTheGapsCarriageway)
				return DrainageType.TheGapsCarriageway;
			if (name == StrByTrays)
				return DrainageType.ByTrays;
			if (name == StrWaterDischargeSidewalks)
				return DrainageType.WaterDischargeSidewalks;
			if (name == StrNone)
				return DrainageType.None;
			if (name == StrDrainPipesDischargeUnderBridge)
				return DrainageType.DrainPipesDischargeUnderBridge;
			if (name == StrDrainPipesWaterSupply)
				return DrainageType.DrainPipesWaterSupply;
			if (name == StrCombined)
				return DrainageType.Combined;
			if (name == StrNoData)
				return DrainageType.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}