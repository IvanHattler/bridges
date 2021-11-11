using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Категория дороги
	/// </summary>
	[Serializable]
	public enum RoadCategory : byte
	{
		/// <summary>
		/// IА
		/// </summary>
		IA,
		/// <summary>
		/// IБ
		/// </summary>
		IB,
		/// <summary>
		/// IВ
		/// </summary>
		IC,
		/// <summary>
		/// II
		/// </summary>
		II,
		/// <summary>
		/// III
		/// </summary>
		III,
		/// <summary>
		/// IV
		/// </summary>
		IV,
		/// <summary>
		/// V
		/// </summary>
		V,
	}
}