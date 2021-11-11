using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип водоотвода
	/// </summary>
	[Serializable]
	public enum DrainageType : byte
	{
		/// <summary>
		/// Сток воды вдоль проезжей части за счет уклонов за пределы мостового сооружения
		/// </summary>
		WaterSlopes,
		/// <summary>
		/// Через зазоры в проезжей части мостового сооружения
		/// </summary>
		TheGapsCarriageway,
		/// <summary>
		/// По лоткам за пределы мостового сооружения
		/// </summary>
		ByTrays,
		/// <summary>
		/// Сброс воды поперек мостового сооружения через тротуары
		/// </summary>
		WaterDischargeSidewalks,
		/// <summary>
		/// Водоотвод не организован
		/// </summary>
		None,
		/// <summary>
		/// Через водоотводные трубки со сбросом под мостовое сооружение
		/// </summary>
		DrainPipesDischargeUnderBridge,
		/// <summary>
		/// Через водоотводные трубки с отводом воды по водопроводу вдоль мостового сооружения
		/// </summary>
		DrainPipesWaterSupply,
		/// <summary>
		/// Комбинированный
		/// </summary>
		Combined,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}