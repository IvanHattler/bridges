using ITS.Core.Bridges.Domain.Enums;
using System;
using System.Text;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления Communications (Коммуникации) в строку и обратно
	/// </summary>
	public class CommunicationsStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<Communications>
	{
		/// <summary>
		/// Отсутствуют
		/// </summary>
		private static readonly string StrNone = "Отсутствуют";
		/// <summary>
		/// Теплосеть
		/// </summary>
		private static readonly string StrHeatingNetwork = "Теплосеть";
		/// <summary>
		/// Водопровод
		/// </summary>
		private static readonly string StrWaterPipeline = "Водопровод";
		/// <summary>
		/// Газопровод
		/// </summary>
		private static readonly string StrGasPipeline = "Газопровод";
		/// <summary>
		/// Электрокабель
		/// </summary>
		private static readonly string StrElectricCable = "Электрокабель";
		/// <summary>
		/// Кабель связи
		/// </summary>
		private static readonly string StrCommunicationCable = "Кабель связи";
		/// <summary>
		/// Телекабель
		/// </summary>
		private static readonly string StrTelecable = "Телекабель";
		private readonly StringBuilder stringBuilder = new StringBuilder();

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public CommunicationsStrings() { }
		private static CommunicationsStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static CommunicationsStrings Instance
			=> instance ?? (instance = new CommunicationsStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления Communications (Коммуникации)
		/// </summary>
		/// <param name="communications">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(Communications communications)
		{
			stringBuilder.Clear();
			bool first = true;
			if(communications == Communications.NoData)
			{
				return "Нет данных";
			}
			if ((communications & Communications.None) == Communications.None)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrNone);
				first = false;
			}
			if ((communications & Communications.HeatingNetwork) == Communications.HeatingNetwork)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrHeatingNetwork);
				first = false;
			}
			if ((communications & Communications.WaterPipeline) == Communications.WaterPipeline)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrWaterPipeline);
				first = false;
			}
			if ((communications & Communications.GasPipeline) == Communications.GasPipeline)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrGasPipeline);
				first = false;
			}
			if ((communications & Communications.ElectricCable) == Communications.ElectricCable)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrElectricCable);
				first = false;
			}
			if ((communications & Communications.CommunicationCable) == Communications.CommunicationCable)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrCommunicationCable);
				first = false;
			}
			if ((communications & Communications.Telecable) == Communications.Telecable)
			{
				if(!first) stringBuilder.Append(", ");
				stringBuilder.Append(StrTelecable);
				first = false;
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Метод для элемента перечисления Communications (Коммуникации) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override Communications GetElement(string name)
		{
			var tmp = name.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
			var res = Communications.NoData;
			foreach (var item in tmp)
			{
				if (item == StrNone)
					res |= Communications.None;
				else if (item == StrHeatingNetwork)
					res |= Communications.HeatingNetwork;
				else if (item == StrWaterPipeline)
					res |= Communications.WaterPipeline;
				else if (item == StrGasPipeline)
					res |= Communications.GasPipeline;
				else if (item == StrElectricCable)
					res |= Communications.ElectricCable;
				else if (item == StrCommunicationCable)
					res |= Communications.CommunicationCable;
				else if (item == StrTelecable)
					res |= Communications.Telecable;
			}
			return res;
		}
	}
}