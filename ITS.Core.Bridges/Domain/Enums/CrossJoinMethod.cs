using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Cпособ поперечного объединения
	/// </summary>
	[Serializable]
	public enum CrossJoinMethod : byte
	{
		/// <summary>
		/// Не объединены
		/// </summary>
		None,
		/// <summary>
		/// По поперечным балкам и связям
		/// </summary>
		TransverseBeamsAndTies,
		/// <summary>
		/// По продольным и поперечным связям
		/// </summary>
		LongitudinalAndTransverseLinks,
		/// <summary>
		/// По плите и поперечным связям
		/// </summary>
		SlabAndCrossBraces,
		/// <summary>
		/// По шпонкам
		/// </summary>
		Dowels,
		/// <summary>
		/// По диафрагмам
		/// </summary>
		Diaphragms,
		/// <summary>
		/// По плите
		/// </summary>
		Stove,
		/// <summary>
		/// По плите и диафрагмам
		/// </summary>
		PlateAndDiaphragms,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}