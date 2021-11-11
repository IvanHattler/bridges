using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Статическая система мостового сооружения
	/// </summary>
	[Serializable]
	public enum SpanStructureSystem : byte
	{
		/// <summary>
		/// Балочно-разрезная
		/// </summary>
		BeamCut,
		/// <summary>
		/// Балочная неразрезная с постоянной высотой пролетного строения
		/// </summary>
		ContinuousBeamConstantHeight,
		/// <summary>
		/// Балочная неразрезная с переменной высотой пролетного строения
		/// </summary>
		ContinuousBeamVariableHeight,
		/// <summary>
		/// Балочно-консольная
		/// </summary>
		BeamCantilever,
		/// <summary>
		/// Балочно-консольная с подвесным пролетом
		/// </summary>
		BeamCantileverSuspendedSpan,
		/// <summary>
		/// Балочная температурно-неразрезная
		/// </summary>
		BeamTemperatureContinuous,
		/// <summary>
		/// Арочная трехшарнирная
		/// </summary>
		ArchedThreeHinged,
		/// <summary>
		/// Арочная двухшарнирная
		/// </summary>
		ArchedDoubleHinged,
		/// <summary>
		/// Арочная с затяжкой
		/// </summary>
		ArchedTightening,
		/// <summary>
		/// Арочная бесшарнирная
		/// </summary>
		ArchedHingeless,
		/// <summary>
		/// Арочно-балочная внешне распорная с ездой поверху
		/// </summary>
		ArchedBeamExternallySpacerRideTop,
		/// <summary>
		/// Арочно-балочная внешне безраспорная
		/// </summary>
		ArchedBeamExternallyWithoutExpansion,
		/// <summary>
		/// Арочная ферма с ездой посередине
		/// </summary>
		ArchedFarmRideMiddle,
		/// <summary>
		/// Висячая с заделкой канатов в анкерных устоях
		/// </summary>
		HangingEmbeddedRopesInAnchorAbutments,
		/// <summary>
		/// Висячая с заделкой канатов в балке жесткости
		/// </summary>
		HangingWithRopesStiffeningBeam,
		/// <summary>
		/// Вантовая с балкой жесткости
		/// </summary>
		CableStayedWithStiffeningBeam,
		/// <summary>
		/// Комбинированная система
		/// </summary>
		Combined,
		/// <summary>
		/// Рамная
		/// </summary>
		Frame,
		/// <summary>
		/// Рамно-консольная
		/// </summary>
		FrameConsole,
		/// <summary>
		/// Рамно-подвесная
		/// </summary>
		FrameSuspended,
		/// <summary>
		/// Рамная с наклонными опорами (“Бегущая лань”)
		/// </summary>
		FrameInclinedSupports,
		/// <summary>
		/// Рамная с V-образными опорами
		/// </summary>
		FrameVShapedSupports,
		/// <summary>
		/// Разводной мост раскрывающейся системы
		/// </summary>
		DropDownSwing,
		/// <summary>
		/// Разводной мост поворотной системы
		/// </summary>
		SwingAxle,
		/// <summary>
		/// Разводной мост вертикально-подъемной системы
		/// </summary>
		VerticalLiftSwing,
		/// <summary>
		/// Ригельно-подкосная
		/// </summary>
		CrossbarAndStrut,
		/// <summary>
		/// Подкосная
		/// </summary>
		Podkosnaya,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}