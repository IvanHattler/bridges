using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Типы деформационных швов 
	/// </summary>
	[Serializable]
	public enum ExpansionJointType : byte
	{
		/// <summary>
		/// Закрытого типа с металлическим компенсатором
		/// </summary>
		ClosedMetalCompensator,
		/// <summary>
		/// Закрытого типа Торма Джоинт
		/// </summary>
		ClosedTormaJoint,
		/// <summary>
		/// Заполненного типа с мастичным заполнением и металлическим компенсатором
		/// </summary>
		FilledMasticAndMetalCompensator,
		/// <summary>
		/// Заполненного типа с мастичным заполнением и стальным окаймлением
		/// </summary>
		FilledMasticStellEdging,
		/// <summary>
		/// Заполненного типа с резиновым или полимерным компенсатором
		/// </summary>
		FilledRubberOrPolymerCompensator,
		/// <summary>
		/// Заполненного типа с двумя (тремя) резиновыми компенсаторами - модульный
		/// </summary>
		FilledTwoRubberCompensatorModular,
		/// <summary>
		/// Перекрытого типа со стальным скользящим листом
		/// </summary>
		OverlappedSteelSliding,
		/// <summary>
		/// Перекрытого типа со стальным скользящим листом двусторонний уравновешенного типа
		/// </summary>
		OverlappedSteelSlidingDoubleSidedBalanced,
		/// <summary>
		/// Перекрытого типа с гребенчатой плитой
		/// </summary>
		OverlappedCombType,
		/// <summary>
		/// Перекрытого типа откатного типа
		/// </summary>
		OverlappedSlidingType,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}