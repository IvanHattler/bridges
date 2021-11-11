using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип неподвижных опорных частей
	/// </summary>
	[Serializable]
	public enum BridgeMotionlessPartSupport : byte
	{
		/// <summary>
		/// Отсутствуют
		/// </summary>
		None,
		/// <summary>
		/// Прокладки из рубероида
		/// </summary>
		RoofingMaterialGaskets,
		/// <summary>
		/// Плоские (под балкой одна стальная пластина)
		/// </summary>
		Flat,
		/// <summary>
		/// Тангенциальные металлические
		/// </summary>
		TangentialMetal,
		/// <summary>
		/// Резино - фторопластовые (резина в обойме)
		/// </summary>
		RubberFluoroplastic,
		/// <summary>
		/// Балансирные
		/// </summary>
		Balancing,
		/// <summary>
		/// Комбинированные
		/// </summary>
		Combined,
		/// <summary>
		/// Шаровые сегментные
		/// </summary>
		BallSegment,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}