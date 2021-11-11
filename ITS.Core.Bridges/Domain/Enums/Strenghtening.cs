using System;

namespace ITS.Core.Bridges.Domain.Enums
{
	/// <summary>
	/// Укрепление
	/// </summary>
	[Serializable]
	public enum Strenghtening : byte
	{
		/// <summary>
		/// Каменная наброска, мощение
		/// </summary>
		RoughPaving,
		/// <summary>
		/// Монолитный бетон
		/// </summary>
		MonolithicConcrete,
		/// <summary>
		/// Сборные ж.б. плиты
		/// </summary>
		FerroconcreteSlabs,
		/// <summary>
		/// Решетчатые ж.б. конструкции с щебеночной засыпкой
		/// </summary>
		LatticeFerroconcreteGravelBackfill,
		/// <summary>
		/// Одерновка
		/// </summary>
		Odernovka,
		/// <summary>
		/// Тюфяки, матрасы-рено
		/// </summary>
		Mattresses,
		/// <summary>
		/// Габионы
		/// </summary>
		Gabions,
		/// <summary>
		/// Геотекстиль с щебеночной засыпкой
		/// </summary>
		GeotextileGravelBackfill,
		/// <summary>
		/// Нет укрепления
		/// </summary>
		None,
		/// <summary>
		/// Нет данных
		/// </summary>
		NoData,
	}
}