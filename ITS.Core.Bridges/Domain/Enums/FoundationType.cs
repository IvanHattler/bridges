using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип фундамента
	/// </summary>
	[Serializable]
	public enum FoundationType : byte
	{
		/// <summary>
		/// Свайный
		/// </summary>
		Pile,
		/// <summary>
		/// Плитный на естественном основании
		/// </summary>
		SlabNaturalBase,
		/// <summary>
		/// Низкий свайный ростверк
		/// </summary>
		LowPileGrillage,
		/// <summary>
		/// Высокий свайный ростверк
		/// </summary>
		HighPileGrillage,
		/// <summary>
		/// Безростверковый из отдельных столбов
		/// </summary>
		GrillagelessSeparatePillars,
		/// <summary>
		/// Опускной колодец
		/// </summary>
		Coffer,
		/// <summary>
		/// Кессонный
		/// </summary>
		Caisson,
	}
}