using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления SpanStructureSystem (Статическая система мостового сооружения) в строку и обратно
	/// </summary>
	public class SpanStructureSystemStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<SpanStructureSystem>
	{
		/// <summary>
		/// Балочно-разрезная
		/// </summary>
		private static readonly string StrBeamCut = "Балочно-разрезная";
		/// <summary>
		/// Балочная неразрезная с постоянной высотой пролетного строения
		/// </summary>
		private static readonly string StrContinuousBeamConstantHeight = "Балочная неразрезная с постоянной высотой пролетного строения";
		/// <summary>
		/// Балочная неразрезная с переменной высотой пролетного строения
		/// </summary>
		private static readonly string StrContinuousBeamVariableHeight = "Балочная неразрезная с переменной высотой пролетного строения";
		/// <summary>
		/// Балочно-консольная
		/// </summary>
		private static readonly string StrBeamCantilever = "Балочно-консольная";
		/// <summary>
		/// Балочно-консольная с подвесным пролетом
		/// </summary>
		private static readonly string StrBeamCantileverSuspendedSpan = "Балочно-консольная с подвесным пролетом";
		/// <summary>
		/// Балочная температурно-неразрезная
		/// </summary>
		private static readonly string StrBeamTemperatureContinuous = "Балочная температурно-неразрезная";
		/// <summary>
		/// Арочная трехшарнирная
		/// </summary>
		private static readonly string StrArchedThreeHinged = "Арочная трехшарнирная";
		/// <summary>
		/// Арочная двухшарнирная
		/// </summary>
		private static readonly string StrArchedDoubleHinged = "Арочная двухшарнирная";
		/// <summary>
		/// Арочная с затяжкой
		/// </summary>
		private static readonly string StrArchedTightening = "Арочная с затяжкой";
		/// <summary>
		/// Арочная бесшарнирная
		/// </summary>
		private static readonly string StrArchedHingeless = "Арочная бесшарнирная";
		/// <summary>
		/// Арочно-балочная внешне распорная с ездой поверху
		/// </summary>
		private static readonly string StrArchedBeamExternallySpacerRideTop = "Арочно-балочная внешне распорная с ездой поверху";
		/// <summary>
		/// Арочно-балочная внешне безраспорная
		/// </summary>
		private static readonly string StrArchedBeamExternallyWithoutExpansion = "Арочно-балочная внешне безраспорная";
		/// <summary>
		/// Арочная ферма с ездой посередине
		/// </summary>
		private static readonly string StrArchedFarmRideMiddle = "Арочная ферма с ездой посередине";
		/// <summary>
		/// Висячая с заделкой канатов в анкерных устоях
		/// </summary>
		private static readonly string StrHangingEmbeddedRopesInAnchorAbutments = "Висячая с заделкой канатов в анкерных устоях";
		/// <summary>
		/// Висячая с заделкой канатов в балке жесткости
		/// </summary>
		private static readonly string StrHangingWithRopesStiffeningBeam = "Висячая с заделкой канатов в балке жесткости";
		/// <summary>
		/// Вантовая с балкой жесткости
		/// </summary>
		private static readonly string StrCableStayedWithStiffeningBeam = "Вантовая с балкой жесткости";
		/// <summary>
		/// Комбинированная система
		/// </summary>
		private static readonly string StrCombined = "Комбинированная система";
		/// <summary>
		/// Рамная
		/// </summary>
		private static readonly string StrFrame = "Рамная";
		/// <summary>
		/// Рамно-консольная
		/// </summary>
		private static readonly string StrFrameConsole = "Рамно-консольная";
		/// <summary>
		/// Рамно-подвесная
		/// </summary>
		private static readonly string StrFrameSuspended = "Рамно-подвесная";
		/// <summary>
		/// Рамная с наклонными опорами (“Бегущая лань”)
		/// </summary>
		private static readonly string StrFrameInclinedSupports = "Рамная с наклонными опорами (“Бегущая лань”)";
		/// <summary>
		/// Рамная с V-образными опорами
		/// </summary>
		private static readonly string StrFrameVShapedSupports = "Рамная с V-образными опорами";
		/// <summary>
		/// Разводной мост раскрывающейся системы
		/// </summary>
		private static readonly string StrDropDownSwing = "Разводной мост раскрывающейся системы";
		/// <summary>
		/// Разводной мост поворотной системы
		/// </summary>
		private static readonly string StrSwingAxle = "Разводной мост поворотной системы";
		/// <summary>
		/// Разводной мост вертикально-подъемной системы
		/// </summary>
		private static readonly string StrVerticalLiftSwing = "Разводной мост вертикально-подъемной системы";
		/// <summary>
		/// Ригельно-подкосная
		/// </summary>
		private static readonly string StrCrossbarAndStrut = "Ригельно-подкосная";
		/// <summary>
		/// Подкосная
		/// </summary>
		private static readonly string StrPodkosnaya = "Подкосная";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public SpanStructureSystemStrings() { }
		private static SpanStructureSystemStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static SpanStructureSystemStrings Instance
			=> instance ?? (instance = new SpanStructureSystemStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления SpanStructureSystem (Статическая система мостового сооружения)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(SpanStructureSystem enumElement)
		{
			switch(enumElement)
			{
				case SpanStructureSystem.BeamCut:
					return StrBeamCut;
				case SpanStructureSystem.ContinuousBeamConstantHeight:
					return StrContinuousBeamConstantHeight;
				case SpanStructureSystem.ContinuousBeamVariableHeight:
					return StrContinuousBeamVariableHeight;
				case SpanStructureSystem.BeamCantilever:
					return StrBeamCantilever;
				case SpanStructureSystem.BeamCantileverSuspendedSpan:
					return StrBeamCantileverSuspendedSpan;
				case SpanStructureSystem.BeamTemperatureContinuous:
					return StrBeamTemperatureContinuous;
				case SpanStructureSystem.ArchedThreeHinged:
					return StrArchedThreeHinged;
				case SpanStructureSystem.ArchedDoubleHinged:
					return StrArchedDoubleHinged;
				case SpanStructureSystem.ArchedTightening:
					return StrArchedTightening;
				case SpanStructureSystem.ArchedHingeless:
					return StrArchedHingeless;
				case SpanStructureSystem.ArchedBeamExternallySpacerRideTop:
					return StrArchedBeamExternallySpacerRideTop;
				case SpanStructureSystem.ArchedBeamExternallyWithoutExpansion:
					return StrArchedBeamExternallyWithoutExpansion;
				case SpanStructureSystem.ArchedFarmRideMiddle:
					return StrArchedFarmRideMiddle;
				case SpanStructureSystem.HangingEmbeddedRopesInAnchorAbutments:
					return StrHangingEmbeddedRopesInAnchorAbutments;
				case SpanStructureSystem.HangingWithRopesStiffeningBeam:
					return StrHangingWithRopesStiffeningBeam;
				case SpanStructureSystem.CableStayedWithStiffeningBeam:
					return StrCableStayedWithStiffeningBeam;
				case SpanStructureSystem.Combined:
					return StrCombined;
				case SpanStructureSystem.Frame:
					return StrFrame;
				case SpanStructureSystem.FrameConsole:
					return StrFrameConsole;
				case SpanStructureSystem.FrameSuspended:
					return StrFrameSuspended;
				case SpanStructureSystem.FrameInclinedSupports:
					return StrFrameInclinedSupports;
				case SpanStructureSystem.FrameVShapedSupports:
					return StrFrameVShapedSupports;
				case SpanStructureSystem.DropDownSwing:
					return StrDropDownSwing;
				case SpanStructureSystem.SwingAxle:
					return StrSwingAxle;
				case SpanStructureSystem.VerticalLiftSwing:
					return StrVerticalLiftSwing;
				case SpanStructureSystem.CrossbarAndStrut:
					return StrCrossbarAndStrut;
				case SpanStructureSystem.Podkosnaya:
					return StrPodkosnaya;
				case SpanStructureSystem.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления SpanStructureSystem (Статическая система мостового сооружения) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override SpanStructureSystem GetElement(string name)
		{
			if (name == StrBeamCut)
				return SpanStructureSystem.BeamCut;
			if (name == StrContinuousBeamConstantHeight)
				return SpanStructureSystem.ContinuousBeamConstantHeight;
			if (name == StrContinuousBeamVariableHeight)
				return SpanStructureSystem.ContinuousBeamVariableHeight;
			if (name == StrBeamCantilever)
				return SpanStructureSystem.BeamCantilever;
			if (name == StrBeamCantileverSuspendedSpan)
				return SpanStructureSystem.BeamCantileverSuspendedSpan;
			if (name == StrBeamTemperatureContinuous)
				return SpanStructureSystem.BeamTemperatureContinuous;
			if (name == StrArchedThreeHinged)
				return SpanStructureSystem.ArchedThreeHinged;
			if (name == StrArchedDoubleHinged)
				return SpanStructureSystem.ArchedDoubleHinged;
			if (name == StrArchedTightening)
				return SpanStructureSystem.ArchedTightening;
			if (name == StrArchedHingeless)
				return SpanStructureSystem.ArchedHingeless;
			if (name == StrArchedBeamExternallySpacerRideTop)
				return SpanStructureSystem.ArchedBeamExternallySpacerRideTop;
			if (name == StrArchedBeamExternallyWithoutExpansion)
				return SpanStructureSystem.ArchedBeamExternallyWithoutExpansion;
			if (name == StrArchedFarmRideMiddle)
				return SpanStructureSystem.ArchedFarmRideMiddle;
			if (name == StrHangingEmbeddedRopesInAnchorAbutments)
				return SpanStructureSystem.HangingEmbeddedRopesInAnchorAbutments;
			if (name == StrHangingWithRopesStiffeningBeam)
				return SpanStructureSystem.HangingWithRopesStiffeningBeam;
			if (name == StrCableStayedWithStiffeningBeam)
				return SpanStructureSystem.CableStayedWithStiffeningBeam;
			if (name == StrCombined)
				return SpanStructureSystem.Combined;
			if (name == StrFrame)
				return SpanStructureSystem.Frame;
			if (name == StrFrameConsole)
				return SpanStructureSystem.FrameConsole;
			if (name == StrFrameSuspended)
				return SpanStructureSystem.FrameSuspended;
			if (name == StrFrameInclinedSupports)
				return SpanStructureSystem.FrameInclinedSupports;
			if (name == StrFrameVShapedSupports)
				return SpanStructureSystem.FrameVShapedSupports;
			if (name == StrDropDownSwing)
				return SpanStructureSystem.DropDownSwing;
			if (name == StrSwingAxle)
				return SpanStructureSystem.SwingAxle;
			if (name == StrVerticalLiftSwing)
				return SpanStructureSystem.VerticalLiftSwing;
			if (name == StrCrossbarAndStrut)
				return SpanStructureSystem.CrossbarAndStrut;
			if (name == StrPodkosnaya)
				return SpanStructureSystem.Podkosnaya;
			if (name == StrNoData)
				return SpanStructureSystem.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}