using ITS.Core.Bridges.Domain.Enums;
using System;
using System.Text;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления ReconstructionJobs (Виды основных работ при реконструкции и ремонте) в строку и обратно
	/// </summary>
	public class ReconstructionJobsStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<ReconstructionJobs>
	{
		/// <summary>
		/// Реконструкция или ремонт не проводились
		/// </summary>
		private static readonly string StrNone = "Реконструкция или ремонт не проводились";
		/// <summary>
		/// Замена мостового полотна
		/// </summary>
		private static readonly string StrReplacingBridgeDeck = "Замена мостового полотна";
		/// <summary>
		/// Замена тротуаров
		/// </summary>
		private static readonly string StrReplacingSidewalks = "Замена тротуаров";
		/// <summary>
		/// Усиление опор
		/// </summary>
		private static readonly string StrReinforcementSupports = "Усиление опор";
		/// <summary>
		/// Усиление пролетных строений
		/// </summary>
		private static readonly string StrReinforcementSpans = "Усиление пролетных строений";
		/// <summary>
		/// Уширение пролетных строений и опор приставными элементами с одной стороны
		/// </summary>
		private static readonly string StrWideningAttachOneSide = "Уширение пролетных строений и опор приставными элементами с одной стороны";
		/// <summary>
		/// Уширение пролетных строений и опор приставными элементами несимметрично с двух сторон
		/// </summary>
		private static readonly string StrWideningAttachTwoSideSymmetric = "Уширение пролетных строений и опор приставными элементами несимметрично с двух сторон";
		/// <summary>
		/// Уширение пролетных строений и опор приставными элементами симметрично с двух сторон
		/// </summary>
		private static readonly string StrWideningAttachTwoSideAsymmetric = "Уширение пролетных строений и опор приставными элементами симметрично с двух сторон";
		/// <summary>
		/// Уширение пролетных строений накладной плитой
		/// </summary>
		private static readonly string StrWideningOverheadSlab = "Уширение пролетных строений накладной плитой";
		/// <summary>
		/// Уширение проезжей части за счет тротуаров
		/// </summary>
		private static readonly string StrWideningSidewalk = "Уширение проезжей части за счет тротуаров";
		/// <summary>
		/// Замена балок пролетных строений
		/// </summary>
		private static readonly string StrReplacingSpanBeams = "Замена балок пролетных строений";
		/// <summary>
		/// Постройка параллельного мостового сооружения
		/// </summary>
		private static readonly string StrBuildParallelBridge = "Постройка параллельного мостового сооружения";
		private readonly StringBuilder stringBuilder = new StringBuilder();

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public ReconstructionJobsStrings() { }
		private static ReconstructionJobsStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static ReconstructionJobsStrings Instance
			=> instance ?? (instance = new ReconstructionJobsStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления ReconstructionJobs (Виды основных работ при реконструкции и ремонте)
		/// </summary>
		/// <param name="reconstruction_jobs">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(ReconstructionJobs reconstruction_jobs)
		{
			stringBuilder.Clear();
			bool first = true;
			if(reconstruction_jobs == ReconstructionJobs.NoData)
			{
				return "Нет данных";
			}
			if ((reconstruction_jobs & ReconstructionJobs.None) == ReconstructionJobs.None)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrNone);
				first = false;
			}
			if ((reconstruction_jobs & ReconstructionJobs.ReplacingBridgeDeck) == ReconstructionJobs.ReplacingBridgeDeck)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrReplacingBridgeDeck);
				first = false;
			}
			if ((reconstruction_jobs & ReconstructionJobs.ReplacingSidewalks) == ReconstructionJobs.ReplacingSidewalks)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrReplacingSidewalks);
				first = false;
			}
			if ((reconstruction_jobs & ReconstructionJobs.ReinforcementSupports) == ReconstructionJobs.ReinforcementSupports)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrReinforcementSupports);
				first = false;
			}
			if ((reconstruction_jobs & ReconstructionJobs.ReinforcementSpans) == ReconstructionJobs.ReinforcementSpans)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrReinforcementSpans);
				first = false;
			}
			if ((reconstruction_jobs & ReconstructionJobs.WideningAttachOneSide) == ReconstructionJobs.WideningAttachOneSide)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrWideningAttachOneSide);
				first = false;
			}
			if ((reconstruction_jobs & ReconstructionJobs.WideningAttachTwoSideSymmetric) == ReconstructionJobs.WideningAttachTwoSideSymmetric)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrWideningAttachTwoSideSymmetric);
				first = false;
			}
			if ((reconstruction_jobs & ReconstructionJobs.WideningAttachTwoSideAsymmetric) == ReconstructionJobs.WideningAttachTwoSideAsymmetric)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrWideningAttachTwoSideAsymmetric);
				first = false;
			}
			if ((reconstruction_jobs & ReconstructionJobs.WideningOverheadSlab) == ReconstructionJobs.WideningOverheadSlab)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrWideningOverheadSlab);
				first = false;
			}
			if ((reconstruction_jobs & ReconstructionJobs.WideningSidewalk) == ReconstructionJobs.WideningSidewalk)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrWideningSidewalk);
				first = false;
			}
			if ((reconstruction_jobs & ReconstructionJobs.ReplacingSpanBeams) == ReconstructionJobs.ReplacingSpanBeams)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrReplacingSpanBeams);
				first = false;
			}
			if ((reconstruction_jobs & ReconstructionJobs.BuildParallelBridge) == ReconstructionJobs.BuildParallelBridge)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrBuildParallelBridge);
				first = false;
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Метод для элемента перечисления ReconstructionJobs (Виды основных работ при реконструкции и ремонте) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override ReconstructionJobs GetElement(string name)
		{
			var tmp = name.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
			var res = ReconstructionJobs.NoData;
			foreach (var item in tmp)
			{
				if (item == StrNone)
					res |= ReconstructionJobs.None;
				else if (item == StrReplacingBridgeDeck)
					res |= ReconstructionJobs.ReplacingBridgeDeck;
				else if (item == StrReplacingSidewalks)
					res |= ReconstructionJobs.ReplacingSidewalks;
				else if (item == StrReinforcementSupports)
					res |= ReconstructionJobs.ReinforcementSupports;
				else if (item == StrReinforcementSpans)
					res |= ReconstructionJobs.ReinforcementSpans;
				else if (item == StrWideningAttachOneSide)
					res |= ReconstructionJobs.WideningAttachOneSide;
				else if (item == StrWideningAttachTwoSideSymmetric)
					res |= ReconstructionJobs.WideningAttachTwoSideSymmetric;
				else if (item == StrWideningAttachTwoSideAsymmetric)
					res |= ReconstructionJobs.WideningAttachTwoSideAsymmetric;
				else if (item == StrWideningOverheadSlab)
					res |= ReconstructionJobs.WideningOverheadSlab;
				else if (item == StrWideningSidewalk)
					res |= ReconstructionJobs.WideningSidewalk;
				else if (item == StrReplacingSpanBeams)
					res |= ReconstructionJobs.ReplacingSpanBeams;
				else if (item == StrBuildParallelBridge)
					res |= ReconstructionJobs.BuildParallelBridge;
			}
			return res;
		}
	}
}