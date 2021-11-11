using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип промежуточной опоры
	/// </summary>
	[Serializable]
	public enum IntermediateSupportType : byte
	{
		/// <summary>
		/// Массивная
		/// </summary>
		Massive,
		/// <summary>
		/// Массивная с ригелем
		/// </summary>
		MassiveWithCrossbar,
		/// <summary>
		/// Массивно-столбчатая
		/// </summary>
		MassiveColumnar,
		/// <summary>
		/// Одностолбчатая с ригелем
		/// </summary>
		SingleColumnWithCrossbar,
		/// <summary>
		/// Столбчатая безригельная
		/// </summary>
		ColumnarCrossbarless,
		/// <summary>
		/// Однорядная свайного типа
		/// </summary>
		SingleRowPile,
		/// <summary>
		/// Двухрядная свайного типа
		/// </summary>
		DoubleRowPile,
		/// <summary>
		/// Однорядная стоечного типа
		/// </summary>
		SingleRowRack,
		/// <summary>
		/// Двухрядная стоечного типа
		/// </summary>
		DoubleRowRack,
		/// <summary>
		/// Однорядная стоечная со встроенным ригелем
		/// </summary>
		SingleRowRackWithBuiltInCrossbar,
		/// <summary>
		/// Столбчатая
		/// </summary>
		Columnar,
		/// <summary>
		/// Опоры-стенки
		/// </summary>
		WallSupports,
		/// <summary>
		/// Ряжевая
		/// </summary>
		Ragged,
		/// <summary>
		/// Стоечная с качающимися стойками
		/// </summary>
		RackWithSwingingStruts,
		/// <summary>
		/// Столбчатая с V-образным разветвлением
		/// </summary>
		ColumnarWithVShapedBranch,
		/// <summary>
		/// Рамная
		/// </summary>
		Frame,
		/// <summary>
		/// Пилон висячего моста
		/// </summary>
		SuspensionBridgePylon,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}