using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Наличие переходных плит
	/// </summary>
	[Serializable]
	public enum AdapterPlatesAvailability : byte
	{
		/// <summary>
		/// Нет (0)
		/// </summary>
		No,
		/// <summary>
		/// Есть (1)
		/// </summary>
		Yes,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}