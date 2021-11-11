using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Статус моста
	/// </summary>
	[Serializable]
	public enum BridgeStatus : byte
	{
		/// <summary>
		/// [ У ] становлен
		/// </summary>
		Set,
		/// <summary>
		/// [ Т ] ребуется
		/// </summary>
		Required,
		/// <summary>
		/// [ Д ] емонтировать
		/// </summary>
		Dismantle,
		/// <summary>
		/// [ Р ] емонт
		/// </summary>
		Repairs,
		/// <summary>
		/// [ В ] ременный
		/// </summary>
		Temporary,
	}
}