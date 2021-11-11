using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Профиль уклона
	/// </summary>
	[Serializable]
	public enum SlopeProfile : byte
	{
		/// <summary>
		/// Λ
		/// </summary>
		ConvexCurve,
		/// <summary>
		/// V
		/// </summary>
		ConcaveCurve,
		/// <summary>
		/// /
		/// </summary>
		Up,
		/// <summary>
		/// \\
		/// </summary>
		Down,
	}
}