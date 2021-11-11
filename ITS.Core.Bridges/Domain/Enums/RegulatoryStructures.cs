using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Регуляционные сооружения
	/// </summary>
	[Serializable]
	[Flags]
	public enum RegulatoryStructures : byte
	{
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData = 0,
		/// <summary>
		/// Регуляционных сооружений нет
		/// </summary>
		None = 1,
		/// <summary>
		/// Конус
		/// </summary>
		Cone = 2,
		/// <summary>
		/// Укрепление берега различными конструкциями
		/// </summary>
		StrengtheningCoastVariousStructures = 4,
		/// <summary>
		/// Подпорная или заборная стенка
		/// </summary>
		RetainingOrFenceWall = 8,
		/// <summary>
		/// Струенаправляющая дамба с различными видами укрепления откосов
		/// </summary>
		JetGuideSlopeReinforcement = 16,
		/// <summary>
		/// Струенаправляющая дамба с траверсами
		/// </summary>
		JetGuideWithTraverses = 32,
		/// <summary>
		/// Струенаправляющая дамба и укрепление берега
		/// </summary>
		JetGuideShoreReinforcement = 64,
	}
}