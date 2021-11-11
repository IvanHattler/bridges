using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Расположение в плане
	/// </summary>
	[Serializable]
	public enum LocationInPlan : byte
	{
		/// <summary>
		/// Прямое
		/// </summary>
		Direct,
		/// <summary>
		/// Косое
		/// </summary>
		Oblique,
		/// <summary>
		/// Криволинейное
		/// </summary>
		Сurvilinear,
		/// <summary>
		/// Сложное
		/// </summary>
		Complicated,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}