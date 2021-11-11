using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Виды основных работ при реконструкции и ремонте
	/// </summary>
	[Serializable]
	[Flags]
	public enum ReconstructionJobs : short
	{
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData = 0,
		/// <summary>
		/// Реконструкция или ремонт не проводились
		/// </summary>
		None = 1,
		/// <summary>
		/// Замена мостового полотна
		/// </summary>
		ReplacingBridgeDeck = 2,
		/// <summary>
		/// Замена тротуаров
		/// </summary>
		ReplacingSidewalks = 4,
		/// <summary>
		/// Усиление опор
		/// </summary>
		ReinforcementSupports = 8,
		/// <summary>
		/// Усиление пролетных строений
		/// </summary>
		ReinforcementSpans = 16,
		/// <summary>
		/// Уширение пролетных строений и опор приставными элементами с одной стороны
		/// </summary>
		WideningAttachOneSide = 32,
		/// <summary>
		/// Уширение пролетных строений и опор приставными элементами несимметрично с двух сторон
		/// </summary>
		WideningAttachTwoSideSymmetric = 64,
		/// <summary>
		/// Уширение пролетных строений и опор приставными элементами симметрично с двух сторон
		/// </summary>
		WideningAttachTwoSideAsymmetric = 128,
		/// <summary>
		/// Уширение пролетных строений накладной плитой
		/// </summary>
		WideningOverheadSlab = 256,
		/// <summary>
		/// Уширение проезжей части за счет тротуаров
		/// </summary>
		WideningSidewalk = 512,
		/// <summary>
		/// Замена балок пролетных строений
		/// </summary>
		ReplacingSpanBeams = 1024,
		/// <summary>
		/// Постройка параллельного мостового сооружения
		/// </summary>
		BuildParallelBridge = 2048,
	}
}