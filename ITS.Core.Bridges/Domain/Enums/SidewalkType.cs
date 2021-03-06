using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип тротуара
	/// </summary>
	[Serializable]
	public enum SidewalkType : byte
	{
		/// <summary>
		/// В уровне одежды по плите проезжей части
		/// </summary>
		ClothingAlongTheSlab,
		/// <summary>
		/// Пониженные в уровне проезжей части из сборных плит (блоков)
		/// </summary>
		LoweredCarriagewayBlocks,
		/// <summary>
		/// Пониженные в уровне проезжей части с монолитной плитой
		/// </summary>
		LoweredCarriagewayMonolithicSlab,
		/// <summary>
		/// Повышенного типа из сборных типовых блоков
		/// </summary>
		IncreasedFromBlocks,
		/// <summary>
		/// Повышенного типа из свай
		/// </summary>
		IncreasedFromPiles,
		/// <summary>
		/// Тротуаров нет (зоны для прохода пешеходов)
		/// </summary>
		None,
		/// <summary>
		/// Деревянные конструкции
		/// </summary>
		Wood,
		/// <summary>
		/// На консолях, повышенного типа
		/// </summary>
		ConsolesIncreased,
		/// <summary>
		/// На консолях, в уровне проезжей части	
		/// </summary>
		ConsolesCarriageway,
		/// <summary>
		/// На консолях, пониженного типа
		/// </summary>
		ConsolesLowered,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}