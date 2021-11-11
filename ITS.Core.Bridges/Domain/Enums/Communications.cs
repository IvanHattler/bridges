using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Коммуникации
	/// </summary>
	[Serializable]
	[Flags]
	public enum Communications : byte
	{
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData = 0,
		/// <summary>
		/// Отсутствуют
		/// </summary>
		None = 1,
		/// <summary>
		/// Теплосеть
		/// </summary>
		HeatingNetwork = 2,
		/// <summary>
		/// Водопровод
		/// </summary>
		WaterPipeline = 4,
		/// <summary>
		/// Газопровод
		/// </summary>
		GasPipeline = 8,
		/// <summary>
		/// Электрокабель
		/// </summary>
		ElectricCable = 16,
		/// <summary>
		/// Кабель связи
		/// </summary>
		CommunicationCable = 32,
		/// <summary>
		/// Телекабель
		/// </summary>
		Telecable = 64,
	}
}