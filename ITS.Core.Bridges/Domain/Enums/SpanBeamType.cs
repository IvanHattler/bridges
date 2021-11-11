using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Тип балок
	/// </summary>
	[Serializable]
	public enum SpanBeamType : byte
	{
		/// <summary>
		/// Плитные с ненапрягаемой арматурой для прямых участков пути
		/// </summary>
		SlabsTensionFreeStraightTrackSections,
		/// <summary>
		/// Плитные с ненапрягаемой арматурой для кривых участков пути
		/// </summary>
		SlabsTensionFreeCurvedTrackSections,
		/// <summary>
		/// Плитные с ненапрягаемой арматурой для стационарных пролётных строений
		/// </summary>
		SlabsTensionFreeStationarySpans,
		/// <summary>
		/// Ребристые с ненапрягаемой арматурой для кривых участков пути
		/// </summary>
		RibbedTensionFreeCurvedTrackSections,
		/// <summary>
		/// Станционные с предварительно напрягаемой арматурой для прямых участков пути
		/// </summary>
		StationaryPrestressedStraightTrackSections,
		/// <summary>
		/// Станционные с предварительно напрягаемой арматурой для кривых участков пути
		/// </summary>
		StationaryPrestressedCurvedTrackSections,
	}
}