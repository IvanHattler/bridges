using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления ShoreSupportType (Тип береговой опоры) в строку и обратно
	/// </summary>
	public class ShoreSupportTypeStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<ShoreSupportType>
	{
		/// <summary>
		/// Массивный обсыпной устой
		/// </summary>
		private static readonly string StrMassiveCrumblingAbutment = "Массивный обсыпной устой";
		/// <summary>
		/// Массивный устой с обратными стенками
		/// </summary>
		private static readonly string StrMassiveAbutmentBackWalls = "Массивный устой с обратными стенками";
		/// <summary>
		/// Устой однорядный свайного типа
		/// </summary>
		private static readonly string StrSingleRowPileAbutment = "Устой однорядный свайного типа";
		/// <summary>
		/// Устой однорядный стоечного типа
		/// </summary>
		private static readonly string StrSingleRowRackAbutment = "Устой однорядный стоечного типа";
		/// <summary>
		/// Устой двухрядный (или козловой) свайного типа
		/// </summary>
		private static readonly string StrDoubleRowPileAbutment = "Устой двухрядный (или козловой) свайного типа";
		/// <summary>
		/// Устой двухрядный (или козловой) стоечного типа
		/// </summary>
		private static readonly string StrDoubleRowRackAbutment = "Устой двухрядный (или козловой) стоечного типа";
		/// <summary>
		/// Устой лежневого типа
		/// </summary>
		private static readonly string StrStubAbutment = "Устой лежневого типа";
		/// <summary>
		/// Ряжевый устой
		/// </summary>
		private static readonly string StrRageAbutment = "Ряжевый устой";
		/// <summary>
		/// Устой-угловая контрфорсная подпорная стенка
		/// </summary>
		private static readonly string StrAngleButtressRetainingWallAbutment = "Устой-угловая контрфорсная подпорная стенка";
		/// <summary>
		/// Устой столбчатый с ригелем
		/// </summary>
		private static readonly string StrColumnarCrossbarAbutment = "Устой столбчатый с ригелем";
		/// <summary>
		/// Устой арочного распорного моста
		/// </summary>
		private static readonly string StrArchedSpacerBridgeAbutment = "Устой арочного распорного моста";
		/// <summary>
		/// Анкерный устой висячего моста
		/// </summary>
		private static readonly string StrSuspensionBridgeAnchor = "Анкерный устой висячего моста";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public ShoreSupportTypeStrings() { }
		private static ShoreSupportTypeStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static ShoreSupportTypeStrings Instance
			=> instance ?? (instance = new ShoreSupportTypeStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления ShoreSupportType (Тип береговой опоры)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(ShoreSupportType enumElement)
		{
			switch(enumElement)
			{
				case ShoreSupportType.MassiveCrumblingAbutment:
					return StrMassiveCrumblingAbutment;
				case ShoreSupportType.MassiveAbutmentBackWalls:
					return StrMassiveAbutmentBackWalls;
				case ShoreSupportType.SingleRowPileAbutment:
					return StrSingleRowPileAbutment;
				case ShoreSupportType.SingleRowRackAbutment:
					return StrSingleRowRackAbutment;
				case ShoreSupportType.DoubleRowPileAbutment:
					return StrDoubleRowPileAbutment;
				case ShoreSupportType.DoubleRowRackAbutment:
					return StrDoubleRowRackAbutment;
				case ShoreSupportType.StubAbutment:
					return StrStubAbutment;
				case ShoreSupportType.RageAbutment:
					return StrRageAbutment;
				case ShoreSupportType.AngleButtressRetainingWallAbutment:
					return StrAngleButtressRetainingWallAbutment;
				case ShoreSupportType.ColumnarCrossbarAbutment:
					return StrColumnarCrossbarAbutment;
				case ShoreSupportType.ArchedSpacerBridgeAbutment:
					return StrArchedSpacerBridgeAbutment;
				case ShoreSupportType.SuspensionBridgeAnchor:
					return StrSuspensionBridgeAnchor;
				case ShoreSupportType.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления ShoreSupportType (Тип береговой опоры) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override ShoreSupportType GetElement(string name)
		{
			if (name == StrMassiveCrumblingAbutment)
				return ShoreSupportType.MassiveCrumblingAbutment;
			if (name == StrMassiveAbutmentBackWalls)
				return ShoreSupportType.MassiveAbutmentBackWalls;
			if (name == StrSingleRowPileAbutment)
				return ShoreSupportType.SingleRowPileAbutment;
			if (name == StrSingleRowRackAbutment)
				return ShoreSupportType.SingleRowRackAbutment;
			if (name == StrDoubleRowPileAbutment)
				return ShoreSupportType.DoubleRowPileAbutment;
			if (name == StrDoubleRowRackAbutment)
				return ShoreSupportType.DoubleRowRackAbutment;
			if (name == StrStubAbutment)
				return ShoreSupportType.StubAbutment;
			if (name == StrRageAbutment)
				return ShoreSupportType.RageAbutment;
			if (name == StrAngleButtressRetainingWallAbutment)
				return ShoreSupportType.AngleButtressRetainingWallAbutment;
			if (name == StrColumnarCrossbarAbutment)
				return ShoreSupportType.ColumnarCrossbarAbutment;
			if (name == StrArchedSpacerBridgeAbutment)
				return ShoreSupportType.ArchedSpacerBridgeAbutment;
			if (name == StrSuspensionBridgeAnchor)
				return ShoreSupportType.SuspensionBridgeAnchor;
			if (name == StrNoData)
				return ShoreSupportType.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}