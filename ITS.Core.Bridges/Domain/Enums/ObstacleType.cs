using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип препятствия
	/// </summary>
	[Serializable]
	public enum ObstacleType : byte
	{
		/// <summary>
		/// Река
		/// </summary>
		River,
		/// <summary>
		/// Ручей
		/// </summary>
		Stream,
		/// <summary>
		/// Суходол
		/// </summary>
		Sukhodol,
		/// <summary>
		/// Железная дорога
		/// </summary>
		Railway,
		/// <summary>
		/// Автодорога
		/// </summary>
		Road,
		/// <summary>
		/// Овраг
		/// </summary>
		Ravine,
		/// <summary>
		/// Балка
		/// </summary>
		Beam,
		/// <summary>
		/// Затапливаемый луг
		/// </summary>
		FloodedMeadow,
		/// <summary>
		/// Ущелье
		/// </summary>
		Gorge,
		/// <summary>
		/// Болото
		/// </summary>
		Swamp,
		/// <summary>
		/// Плотина
		/// </summary>
		Dam,
		/// <summary>
		/// Канал
		/// </summary>
		Channel,
		/// <summary>
		/// Озеро
		/// </summary>
		Lake,
		/// <summary>
		/// Скотопрогон
		/// </summary>
		CattleDrive,
		/// <summary>
		/// Линия электропередач
		/// </summary>
		PowerLine,
		/// <summary>
		/// Тоннельный путепровод
		/// </summary>
		TunnelOverpass,
		/// <summary>
		/// Другие препятствия
		/// </summary>
		Other,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}