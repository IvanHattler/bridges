using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Качество мостового сооружения
	/// </summary>
	[Serializable]
	public enum Quality : byte
	{
		/// <summary>
		/// 1
		/// </summary>
		Grade1,
		/// <summary>
		/// 2
		/// </summary>
		Grade2,
		/// <summary>
		/// 3
		/// </summary>
		Grade3,
		/// <summary>
		/// 4
		/// </summary>
		Grade4,
		/// <summary>
		/// 5
		/// </summary>
		Grade5,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}