using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип главной опоры
	/// </summary>
	[Serializable]
	public enum SpanStructureType : byte
	{
		/// <summary>
		/// Плита
		/// </summary>
		Plate,
		/// <summary>
		/// Плита П-образная
		/// </summary>
		UShapedPlate,
		/// <summary>
		/// Балка ребристая с диафрагмами
		/// </summary>
		RibbedBeamWithDiaphragms,
		/// <summary>
		/// Балка ребристая без диафрагм
		/// </summary>
		RibbedBeamWithoutDiaphragms,
		/// <summary>
		/// Коробка
		/// </summary>
		Box,
		/// <summary>
		/// Коробка многоячеистая
		/// </summary>
		MultiCellBox,
		/// <summary>
		/// Ферма
		/// </summary>
		Farm,
		/// <summary>
		/// Прочее
		/// </summary>
		Other,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}