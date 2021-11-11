using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип движения
	/// </summary>
	[Serializable]
	[Flags]
	public enum MoveType : byte
	{
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData = 0,
		/// <summary>
		/// Автомобильный
		/// </summary>
		Car = 1,
		/// <summary>
		/// Железнодорожный
		/// </summary>
		Railway = 2,
		/// <summary>
		/// Пешеходный и велосипедный
		/// </summary>
		Pedestrian = 4,
		/// <summary>
		/// Для животных
		/// </summary>
		ForAnimals = 8,
		/// <summary>
		/// Для подачи воды
		/// </summary>
		ForWaterSupply = 16,
		/// <summary>
		/// Трубопроводный
		/// </summary>
		Pipeline = 32,
		/// <summary>
		/// Метромост
		/// </summary>
		MetroBridge = 64,
	}
}