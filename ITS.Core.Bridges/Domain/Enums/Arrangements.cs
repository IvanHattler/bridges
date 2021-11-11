using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Обустройство
	/// </summary>
	[Serializable]
	[Flags]
	public enum Arrangements : byte
	{
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData = 0,
		/// <summary>
		/// Отсутствуют
		/// </summary>
		None = 1,
		/// <summary>
		/// Лестницы
		/// </summary>
		Stairs = 2,
		/// <summary>
		/// Тележки смотровые
		/// </summary>
		InspectionTrolleys = 4,
		/// <summary>
		/// Люльки
		/// </summary>
		Cradles = 8,
		/// <summary>
		/// Смотровые хода
		/// </summary>
		ObservationMoves = 16,
		/// <summary>
		/// Люки
		/// </summary>
		Hatches = 32,
		/// <summary>
		/// Двери
		/// </summary>
		Doors = 64,
	}
}