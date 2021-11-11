using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип подвижных опорных частей
	/// </summary>
	[Serializable]
	public enum BridgeMovablePartSupport : byte
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
		/// Плоские металлические
		/// </summary>
		FlatMetal,
		/// <summary>
		/// Тангенциальные металлические
		/// </summary>
		TangentialMetal,
		/// <summary>
		/// Резино-металлические (РОЧ)
		/// </summary>
		RubberMetal,
		/// <summary>
		/// Резино-фторопластовые, тефлоновые и др. полимерные
		/// </summary>
		RubberFluoroplastic,
		/// <summary>
		/// Катковые (один каток)
		/// </summary>
		OneRoller,
		/// <summary>
		/// Валковые (железобетонные)
		/// </summary>
		RollerReinforcedConcrete,
		/// <summary>
		/// Многокатковые
		/// </summary>
		MultiRoller,
		/// <summary>
		/// Секторные
		/// </summary>
		Sectoral,
		/// <summary>
		/// Балансирные
		/// </summary>
		Balancing,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}