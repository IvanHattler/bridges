using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип стыков
	/// </summary>
	[Serializable]
	public enum JointType : byte
	{
		/// <summary>
		/// Клепка
		/// </summary>
		Riveting,
		/// <summary>
		/// Сварка
		/// </summary>
		Welding,
		/// <summary>
		/// Высокопрочные болты
		/// </summary>
		HighStrengthBolts,
		/// <summary>
		/// Мокрые со сваркой выпусков
		/// </summary>
		WetWeldedOutlets,
		/// <summary>
		/// Клеенные зубчатые
		/// </summary>
		GluedToothed,
		/// <summary>
		/// Полусухие
		/// </summary>
		SemiDry,
		/// <summary>
		/// Сухие
		/// </summary>
		Dry,
		/// <summary>
		/// Клееный с уступом
		/// </summary>
		GuedWithLedge,
		/// <summary>
		/// Клееный плоский
		/// </summary>
		GluedFlat,
		/// <summary>
		/// Бетонируемые
		/// </summary>
		Concreted,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}