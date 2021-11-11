using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления BridgeMovablePartSupport (Тип подвижных опорных частей) в строку и обратно
	/// </summary>
	public class BridgeMovablePartSupportStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<BridgeMovablePartSupport>
	{
		/// <summary>
		/// Отсутствуют
		/// </summary>
		private static readonly string StrNone = "Отсутствуют";
		/// <summary>
		/// Прокладки из рубероида
		/// </summary>
		private static readonly string StrRoofingMaterialGaskets = "Прокладки из рубероида";
		/// <summary>
		/// Плоские металлические
		/// </summary>
		private static readonly string StrFlatMetal = "Плоские металлические";
		/// <summary>
		/// Тангенциальные металлические
		/// </summary>
		private static readonly string StrTangentialMetal = "Тангенциальные металлические";
		/// <summary>
		/// Резино-металлические (РОЧ)
		/// </summary>
		private static readonly string StrRubberMetal = "Резино-металлические (РОЧ)";
		/// <summary>
		/// Резино-фторопластовые, тефлоновые и др. полимерные
		/// </summary>
		private static readonly string StrRubberFluoroplastic = "Резино-фторопластовые, тефлоновые и др. полимерные";
		/// <summary>
		/// Катковые (один каток)
		/// </summary>
		private static readonly string StrOneRoller = "Катковые (один каток)";
		/// <summary>
		/// Валковые (железобетонные)
		/// </summary>
		private static readonly string StrRollerReinforcedConcrete = "Валковые (железобетонные)";
		/// <summary>
		/// Многокатковые
		/// </summary>
		private static readonly string StrMultiRoller = "Многокатковые";
		/// <summary>
		/// Секторные
		/// </summary>
		private static readonly string StrSectoral = "Секторные";
		/// <summary>
		/// Балансирные
		/// </summary>
		private static readonly string StrBalancing = "Балансирные";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public BridgeMovablePartSupportStrings() { }
		private static BridgeMovablePartSupportStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static BridgeMovablePartSupportStrings Instance
			=> instance ?? (instance = new BridgeMovablePartSupportStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления BridgeMovablePartSupport (Тип подвижных опорных частей)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(BridgeMovablePartSupport enumElement)
		{
			switch(enumElement)
			{
				case BridgeMovablePartSupport.None:
					return StrNone;
				case BridgeMovablePartSupport.RoofingMaterialGaskets:
					return StrRoofingMaterialGaskets;
				case BridgeMovablePartSupport.FlatMetal:
					return StrFlatMetal;
				case BridgeMovablePartSupport.TangentialMetal:
					return StrTangentialMetal;
				case BridgeMovablePartSupport.RubberMetal:
					return StrRubberMetal;
				case BridgeMovablePartSupport.RubberFluoroplastic:
					return StrRubberFluoroplastic;
				case BridgeMovablePartSupport.OneRoller:
					return StrOneRoller;
				case BridgeMovablePartSupport.RollerReinforcedConcrete:
					return StrRollerReinforcedConcrete;
				case BridgeMovablePartSupport.MultiRoller:
					return StrMultiRoller;
				case BridgeMovablePartSupport.Sectoral:
					return StrSectoral;
				case BridgeMovablePartSupport.Balancing:
					return StrBalancing;
				case BridgeMovablePartSupport.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления BridgeMovablePartSupport (Тип подвижных опорных частей) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override BridgeMovablePartSupport GetElement(string name)
		{
			if (name == StrNone)
				return BridgeMovablePartSupport.None;
			if (name == StrRoofingMaterialGaskets)
				return BridgeMovablePartSupport.RoofingMaterialGaskets;
			if (name == StrFlatMetal)
				return BridgeMovablePartSupport.FlatMetal;
			if (name == StrTangentialMetal)
				return BridgeMovablePartSupport.TangentialMetal;
			if (name == StrRubberMetal)
				return BridgeMovablePartSupport.RubberMetal;
			if (name == StrRubberFluoroplastic)
				return BridgeMovablePartSupport.RubberFluoroplastic;
			if (name == StrOneRoller)
				return BridgeMovablePartSupport.OneRoller;
			if (name == StrRollerReinforcedConcrete)
				return BridgeMovablePartSupport.RollerReinforcedConcrete;
			if (name == StrMultiRoller)
				return BridgeMovablePartSupport.MultiRoller;
			if (name == StrSectoral)
				return BridgeMovablePartSupport.Sectoral;
			if (name == StrBalancing)
				return BridgeMovablePartSupport.Balancing;
			if (name == StrNoData)
				return BridgeMovablePartSupport.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}