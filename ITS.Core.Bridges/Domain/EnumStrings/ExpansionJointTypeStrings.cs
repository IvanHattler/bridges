using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления ExpansionJointType (Типы деформационных швов ) в строку и обратно
	/// </summary>
	public class ExpansionJointTypeStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<ExpansionJointType>
	{
		/// <summary>
		/// Закрытого типа с металлическим компенсатором
		/// </summary>
		private static readonly string StrClosedMetalCompensator = "Закрытого типа с металлическим компенсатором";
		/// <summary>
		/// Закрытого типа Торма Джоинт
		/// </summary>
		private static readonly string StrClosedTormaJoint = "Закрытого типа Торма Джоинт";
		/// <summary>
		/// Заполненного типа с мастичным заполнением и металлическим компенсатором
		/// </summary>
		private static readonly string StrFilledMasticAndMetalCompensator = "Заполненного типа с мастичным заполнением и металлическим компенсатором";
		/// <summary>
		/// Заполненного типа с мастичным заполнением и стальным окаймлением
		/// </summary>
		private static readonly string StrFilledMasticStellEdging = "Заполненного типа с мастичным заполнением и стальным окаймлением";
		/// <summary>
		/// Заполненного типа с резиновым или полимерным компенсатором
		/// </summary>
		private static readonly string StrFilledRubberOrPolymerCompensator = "Заполненного типа с резиновым или полимерным компенсатором";
		/// <summary>
		/// Заполненного типа с двумя (тремя) резиновыми компенсаторами - модульный
		/// </summary>
		private static readonly string StrFilledTwoRubberCompensatorModular = "Заполненного типа с двумя (тремя) резиновыми компенсаторами - модульный";
		/// <summary>
		/// Перекрытого типа со стальным скользящим листом
		/// </summary>
		private static readonly string StrOverlappedSteelSliding = "Перекрытого типа со стальным скользящим листом";
		/// <summary>
		/// Перекрытого типа со стальным скользящим листом двусторонний уравновешенного типа
		/// </summary>
		private static readonly string StrOverlappedSteelSlidingDoubleSidedBalanced = "Перекрытого типа со стальным скользящим листом двусторонний уравновешенного типа";
		/// <summary>
		/// Перекрытого типа с гребенчатой плитой
		/// </summary>
		private static readonly string StrOverlappedCombType = "Перекрытого типа с гребенчатой плитой";
		/// <summary>
		/// Перекрытого типа откатного типа
		/// </summary>
		private static readonly string StrOverlappedSlidingType = "Перекрытого типа откатного типа";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public ExpansionJointTypeStrings() { }
		private static ExpansionJointTypeStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static ExpansionJointTypeStrings Instance
			=> instance ?? (instance = new ExpansionJointTypeStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления ExpansionJointType (Типы деформационных швов )
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(ExpansionJointType enumElement)
		{
			switch(enumElement)
			{
				case ExpansionJointType.ClosedMetalCompensator:
					return StrClosedMetalCompensator;
				case ExpansionJointType.ClosedTormaJoint:
					return StrClosedTormaJoint;
				case ExpansionJointType.FilledMasticAndMetalCompensator:
					return StrFilledMasticAndMetalCompensator;
				case ExpansionJointType.FilledMasticStellEdging:
					return StrFilledMasticStellEdging;
				case ExpansionJointType.FilledRubberOrPolymerCompensator:
					return StrFilledRubberOrPolymerCompensator;
				case ExpansionJointType.FilledTwoRubberCompensatorModular:
					return StrFilledTwoRubberCompensatorModular;
				case ExpansionJointType.OverlappedSteelSliding:
					return StrOverlappedSteelSliding;
				case ExpansionJointType.OverlappedSteelSlidingDoubleSidedBalanced:
					return StrOverlappedSteelSlidingDoubleSidedBalanced;
				case ExpansionJointType.OverlappedCombType:
					return StrOverlappedCombType;
				case ExpansionJointType.OverlappedSlidingType:
					return StrOverlappedSlidingType;
				case ExpansionJointType.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления ExpansionJointType (Типы деформационных швов ) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override ExpansionJointType GetElement(string name)
		{
			if (name == StrClosedMetalCompensator)
				return ExpansionJointType.ClosedMetalCompensator;
			if (name == StrClosedTormaJoint)
				return ExpansionJointType.ClosedTormaJoint;
			if (name == StrFilledMasticAndMetalCompensator)
				return ExpansionJointType.FilledMasticAndMetalCompensator;
			if (name == StrFilledMasticStellEdging)
				return ExpansionJointType.FilledMasticStellEdging;
			if (name == StrFilledRubberOrPolymerCompensator)
				return ExpansionJointType.FilledRubberOrPolymerCompensator;
			if (name == StrFilledTwoRubberCompensatorModular)
				return ExpansionJointType.FilledTwoRubberCompensatorModular;
			if (name == StrOverlappedSteelSliding)
				return ExpansionJointType.OverlappedSteelSliding;
			if (name == StrOverlappedSteelSlidingDoubleSidedBalanced)
				return ExpansionJointType.OverlappedSteelSlidingDoubleSidedBalanced;
			if (name == StrOverlappedCombType)
				return ExpansionJointType.OverlappedCombType;
			if (name == StrOverlappedSlidingType)
				return ExpansionJointType.OverlappedSlidingType;
			if (name == StrNoData)
				return ExpansionJointType.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}