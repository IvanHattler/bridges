using ITS.Core.Bridges.Domain.Enums;
using System;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
	/// <summary>
	/// Класс-преобразователь перечисления IntermediateSupportType (Тип промежуточной опоры) в строку и обратно
	/// </summary>
	public class IntermediateSupportTypeStrings : ITS.Core.Bridges.Domain.Base.EnumStrings<IntermediateSupportType>
	{
		/// <summary>
		/// Массивная
		/// </summary>
		private static readonly string StrMassive = "Массивная";
		/// <summary>
		/// Массивная с ригелем
		/// </summary>
		private static readonly string StrMassiveWithCrossbar = "Массивная с ригелем";
		/// <summary>
		/// Массивно-столбчатая
		/// </summary>
		private static readonly string StrMassiveColumnar = "Массивно-столбчатая";
		/// <summary>
		/// Одностолбчатая с ригелем
		/// </summary>
		private static readonly string StrSingleColumnWithCrossbar = "Одностолбчатая с ригелем";
		/// <summary>
		/// Столбчатая безригельная
		/// </summary>
		private static readonly string StrColumnarCrossbarless = "Столбчатая безригельная";
		/// <summary>
		/// Однорядная свайного типа
		/// </summary>
		private static readonly string StrSingleRowPile = "Однорядная свайного типа";
		/// <summary>
		/// Двухрядная свайного типа
		/// </summary>
		private static readonly string StrDoubleRowPile = "Двухрядная свайного типа";
		/// <summary>
		/// Однорядная стоечного типа
		/// </summary>
		private static readonly string StrSingleRowRack = "Однорядная стоечного типа";
		/// <summary>
		/// Двухрядная стоечного типа
		/// </summary>
		private static readonly string StrDoubleRowRack = "Двухрядная стоечного типа";
		/// <summary>
		/// Однорядная стоечная со встроенным ригелем
		/// </summary>
		private static readonly string StrSingleRowRackWithBuiltInCrossbar = "Однорядная стоечная со встроенным ригелем";
		/// <summary>
		/// Столбчатая
		/// </summary>
		private static readonly string StrColumnar = "Столбчатая";
		/// <summary>
		/// Опоры-стенки
		/// </summary>
		private static readonly string StrWallSupports = "Опоры-стенки";
		/// <summary>
		/// Ряжевая
		/// </summary>
		private static readonly string StrRagged = "Ряжевая";
		/// <summary>
		/// Стоечная с качающимися стойками
		/// </summary>
		private static readonly string StrRackWithSwingingStruts = "Стоечная с качающимися стойками";
		/// <summary>
		/// Столбчатая с V-образным разветвлением
		/// </summary>
		private static readonly string StrColumnarWithVShapedBranch = "Столбчатая с V-образным разветвлением";
		/// <summary>
		/// Рамная
		/// </summary>
		private static readonly string StrFrame = "Рамная";
		/// <summary>
		/// Пилон висячего моста
		/// </summary>
		private static readonly string StrSuspensionBridgePylon = "Пилон висячего моста";
		/// <summary>
		/// Нет данных
		/// </summary>
		private static readonly string StrNoData = "Нет данных";

		/// <summary>
		/// Конструктор по-умолчанию
		/// </summary>
		public IntermediateSupportTypeStrings() { }
		private static IntermediateSupportTypeStrings instance;
		/// <summary>
		/// Свойство для обращения к методам без создания нового экземпляра этого класса
		/// </summary>
		public static IntermediateSupportTypeStrings Instance
			=> instance ?? (instance = new IntermediateSupportTypeStrings());

		/// <summary>
		/// Метод для получения строкового представления элемента перечисления IntermediateSupportType (Тип промежуточной опоры)
		/// </summary>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Строка-результат преобразования</returns>
		public override string GetFullName(IntermediateSupportType enumElement)
		{
			switch(enumElement)
			{
				case IntermediateSupportType.Massive:
					return StrMassive;
				case IntermediateSupportType.MassiveWithCrossbar:
					return StrMassiveWithCrossbar;
				case IntermediateSupportType.MassiveColumnar:
					return StrMassiveColumnar;
				case IntermediateSupportType.SingleColumnWithCrossbar:
					return StrSingleColumnWithCrossbar;
				case IntermediateSupportType.ColumnarCrossbarless:
					return StrColumnarCrossbarless;
				case IntermediateSupportType.SingleRowPile:
					return StrSingleRowPile;
				case IntermediateSupportType.DoubleRowPile:
					return StrDoubleRowPile;
				case IntermediateSupportType.SingleRowRack:
					return StrSingleRowRack;
				case IntermediateSupportType.DoubleRowRack:
					return StrDoubleRowRack;
				case IntermediateSupportType.SingleRowRackWithBuiltInCrossbar:
					return StrSingleRowRackWithBuiltInCrossbar;
				case IntermediateSupportType.Columnar:
					return StrColumnar;
				case IntermediateSupportType.WallSupports:
					return StrWallSupports;
				case IntermediateSupportType.Ragged:
					return StrRagged;
				case IntermediateSupportType.RackWithSwingingStruts:
					return StrRackWithSwingingStruts;
				case IntermediateSupportType.ColumnarWithVShapedBranch:
					return StrColumnarWithVShapedBranch;
				case IntermediateSupportType.Frame:
					return StrFrame;
				case IntermediateSupportType.SuspensionBridgePylon:
					return StrSuspensionBridgePylon;
				case IntermediateSupportType.NoData:
					return StrNoData;
			}
			throw new ArgumentException("Некорректный элемент перечисления", "enumElement");
		}

		/// <summary>
		/// Метод для элемента перечисления IntermediateSupportType (Тип промежуточной опоры) из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
		public override IntermediateSupportType GetElement(string name)
		{
			if (name == StrMassive)
				return IntermediateSupportType.Massive;
			if (name == StrMassiveWithCrossbar)
				return IntermediateSupportType.MassiveWithCrossbar;
			if (name == StrMassiveColumnar)
				return IntermediateSupportType.MassiveColumnar;
			if (name == StrSingleColumnWithCrossbar)
				return IntermediateSupportType.SingleColumnWithCrossbar;
			if (name == StrColumnarCrossbarless)
				return IntermediateSupportType.ColumnarCrossbarless;
			if (name == StrSingleRowPile)
				return IntermediateSupportType.SingleRowPile;
			if (name == StrDoubleRowPile)
				return IntermediateSupportType.DoubleRowPile;
			if (name == StrSingleRowRack)
				return IntermediateSupportType.SingleRowRack;
			if (name == StrDoubleRowRack)
				return IntermediateSupportType.DoubleRowRack;
			if (name == StrSingleRowRackWithBuiltInCrossbar)
				return IntermediateSupportType.SingleRowRackWithBuiltInCrossbar;
			if (name == StrColumnar)
				return IntermediateSupportType.Columnar;
			if (name == StrWallSupports)
				return IntermediateSupportType.WallSupports;
			if (name == StrRagged)
				return IntermediateSupportType.Ragged;
			if (name == StrRackWithSwingingStruts)
				return IntermediateSupportType.RackWithSwingingStruts;
			if (name == StrColumnarWithVShapedBranch)
				return IntermediateSupportType.ColumnarWithVShapedBranch;
			if (name == StrFrame)
				return IntermediateSupportType.Frame;
			if (name == StrSuspensionBridgePylon)
				return IntermediateSupportType.SuspensionBridgePylon;
			if (name == StrNoData)
				return IntermediateSupportType.NoData;
			throw new ArgumentException("Некорректная входная строка", "name");
		}
	}
}