using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип береговой опоры
	/// </summary>
	[Serializable]
	public enum ShoreSupportType : byte
	{
		/// <summary>
		/// Массивный обсыпной устой
		/// </summary>
		MassiveCrumblingAbutment,
		/// <summary>
		/// Массивный устой с обратными стенками
		/// </summary>
		MassiveAbutmentBackWalls,
		/// <summary>
		/// Устой однорядный свайного типа
		/// </summary>
		SingleRowPileAbutment,
		/// <summary>
		/// Устой однорядный стоечного типа
		/// </summary>
		SingleRowRackAbutment,
		/// <summary>
		/// Устой двухрядный (или козловой) свайного типа
		/// </summary>
		DoubleRowPileAbutment,
		/// <summary>
		/// Устой двухрядный (или козловой) стоечного типа
		/// </summary>
		DoubleRowRackAbutment,
		/// <summary>
		/// Устой лежневого типа
		/// </summary>
		StubAbutment,
		/// <summary>
		/// Ряжевый устой
		/// </summary>
		RageAbutment,
		/// <summary>
		/// Устой-угловая контрфорсная подпорная стенка
		/// </summary>
		AngleButtressRetainingWallAbutment,
		/// <summary>
		/// Устой столбчатый с ригелем
		/// </summary>
		ColumnarCrossbarAbutment,
		/// <summary>
		/// Устой арочного распорного моста
		/// </summary>
		ArchedSpacerBridgeAbutment,
		/// <summary>
		/// Анкерный устой висячего моста
		/// </summary>
		SuspensionBridgeAnchor,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}