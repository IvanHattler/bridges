using ITS.Core.Bridges.Domain.Enums;
using System;
using System.Text;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления RegulatoryStructures (Регуляционные сооружения) в строку и обратно
	/// </summary>
	public class RegulatoryStructuresStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<RegulatoryStructures>
	{
		/// <summary>
		/// Регуляционных сооружений нет
		/// </summary>
		private static readonly string StrNone = "Регуляционных сооружений нет";
		/// <summary>
		/// Конус
		/// </summary>
		private static readonly string StrCone = "Конус";
		/// <summary>
		/// Укрепление берега различными конструкциями
		/// </summary>
		private static readonly string StrStrengtheningCoastVariousStructures = "Укрепление берега различными конструкциями";
		/// <summary>
		/// Подпорная или заборная стенка
		/// </summary>
		private static readonly string StrRetainingOrFenceWall = "Подпорная или заборная стенка";
		/// <summary>
		/// Струенаправляющая дамба с различными видами укрепления откосов
		/// </summary>
		private static readonly string StrJetGuideSlopeReinforcement = "Струенаправляющая дамба с различными видами укрепления откосов";
		/// <summary>
		/// Струенаправляющая дамба с траверсами
		/// </summary>
		private static readonly string StrJetGuideWithTraverses = "Струенаправляющая дамба с траверсами";
		/// <summary>
		/// Струенаправляющая дамба и укрепление берега
		/// </summary>
		private static readonly string StrJetGuideShoreReinforcement = "Струенаправляющая дамба и укрепление берега";
		private readonly StringBuilder stringBuilder = new StringBuilder();

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public RegulatoryStructuresStrings() { }
		private static RegulatoryStructuresStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static RegulatoryStructuresStrings Instance
			=> instance ?? (instance = new RegulatoryStructuresStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления RegulatoryStructures (Регуляционные сооружения)
		/// </summary>
		/// <param name="regulatory_structures">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(RegulatoryStructures regulatory_structures)
		{
			stringBuilder.Clear();
			bool first = true;
			if(regulatory_structures == RegulatoryStructures.NoData)
			{
				return "Нет данных";
			}
			if ((regulatory_structures & RegulatoryStructures.None) == RegulatoryStructures.None)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrNone);
				first = false;
			}
			if ((regulatory_structures & RegulatoryStructures.Cone) == RegulatoryStructures.Cone)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrCone);
				first = false;
			}
			if ((regulatory_structures & RegulatoryStructures.StrengtheningCoastVariousStructures) == RegulatoryStructures.StrengtheningCoastVariousStructures)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrStrengtheningCoastVariousStructures);
				first = false;
			}
			if ((regulatory_structures & RegulatoryStructures.RetainingOrFenceWall) == RegulatoryStructures.RetainingOrFenceWall)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrRetainingOrFenceWall);
				first = false;
			}
			if ((regulatory_structures & RegulatoryStructures.JetGuideSlopeReinforcement) == RegulatoryStructures.JetGuideSlopeReinforcement)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrJetGuideSlopeReinforcement);
				first = false;
			}
			if ((regulatory_structures & RegulatoryStructures.JetGuideWithTraverses) == RegulatoryStructures.JetGuideWithTraverses)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrJetGuideWithTraverses);
				first = false;
			}
			if ((regulatory_structures & RegulatoryStructures.JetGuideShoreReinforcement) == RegulatoryStructures.JetGuideShoreReinforcement)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrJetGuideShoreReinforcement);
				first = false;
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Метод для элемента перечисления RegulatoryStructures (Регуляционные сооружения) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override RegulatoryStructures GetElement(string name)
		{
			var tmp = name.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
			var res = RegulatoryStructures.NoData;
			foreach (var item in tmp)
			{
				if (item == StrNone)
					res |= RegulatoryStructures.None;
				else if (item == StrCone)
					res |= RegulatoryStructures.Cone;
				else if (item == StrStrengtheningCoastVariousStructures)
					res |= RegulatoryStructures.StrengtheningCoastVariousStructures;
				else if (item == StrRetainingOrFenceWall)
					res |= RegulatoryStructures.RetainingOrFenceWall;
				else if (item == StrJetGuideSlopeReinforcement)
					res |= RegulatoryStructures.JetGuideSlopeReinforcement;
				else if (item == StrJetGuideWithTraverses)
					res |= RegulatoryStructures.JetGuideWithTraverses;
				else if (item == StrJetGuideShoreReinforcement)
					res |= RegulatoryStructures.JetGuideShoreReinforcement;
			}
			return res;
		}
	}
}