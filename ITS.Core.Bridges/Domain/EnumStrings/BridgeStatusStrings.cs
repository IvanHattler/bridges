using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления BridgeStatus (Статус моста) в строку и обратно
	/// </summary>
	public class BridgeStatusStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<BridgeStatus>
	{
		/// <summary>
		/// [ У ] становлен
		/// </summary>
		private static readonly string StrSet = "[ У ] становлен";
		/// <summary>
		/// [ Т ] ребуется
		/// </summary>
		private static readonly string StrRequired = "[ Т ] ребуется";
		/// <summary>
		/// [ Д ] емонтировать
		/// </summary>
		private static readonly string StrDismantle = "[ Д ] емонтировать";
		/// <summary>
		/// [ Р ] емонт
		/// </summary>
		private static readonly string StrRepairs = "[ Р ] емонт";
		/// <summary>
		/// [ В ] ременный
		/// </summary>
		private static readonly string StrTemporary = "[ В ] ременный";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public BridgeStatusStrings() { }
		private static BridgeStatusStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static BridgeStatusStrings Instance
			=> instance ?? (instance = new BridgeStatusStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления BridgeStatus (Статус моста)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(BridgeStatus enumElement)
		{
			switch(enumElement)
			{
				case BridgeStatus.Set:
					return StrSet;
				case BridgeStatus.Required:
					return StrRequired;
				case BridgeStatus.Dismantle:
					return StrDismantle;
				case BridgeStatus.Repairs:
					return StrRepairs;
				case BridgeStatus.Temporary:
					return StrTemporary;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления BridgeStatus (Статус моста) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override BridgeStatus GetElement(string name)
		{
			if (name == StrSet)
				return BridgeStatus.Set;
			if (name == StrRequired)
				return BridgeStatus.Required;
			if (name == StrDismantle)
				return BridgeStatus.Dismantle;
			if (name == StrRepairs)
				return BridgeStatus.Repairs;
			if (name == StrTemporary)
				return BridgeStatus.Temporary;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}