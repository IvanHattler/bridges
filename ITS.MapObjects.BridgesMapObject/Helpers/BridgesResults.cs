using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    /// <summary>
    /// Итоги по мостовым сооружениям
    /// </summary>
    public class BridgesResults
    {
        private IEnumerable<Bridge> _bridges;

        #region Counts
        /// <summary>
        /// Количество мостовых сооружений
        /// </summary>
        public int Count => _bridges.Count();

        /// <summary>
        /// Количество требуемых мостовых сооружений
        /// </summary>
        public int CountSet => _bridges.Count(b=>b.Status == BridgeStatus.Set);
        
        /// <summary>
        /// Количество требуемых мостовых сооружений
        /// </summary>
        public int CountRequired => _bridges.Count(b=>b.Status == BridgeStatus.Required);
        
        /// <summary>
        /// Количество демонтируемых мостовых сооружений
        /// </summary>
        public int CountDismantle => _bridges.Count(b=>b.Status == BridgeStatus.Dismantle);

        /// <summary>
        /// Количество пролётных строений
        /// </summary>
        public int SpanStructuresCount =>
            _bridges.Select(b => b.SpanStructures)
            .Select(sts => sts.Count).Sum();

        /// <summary>
        /// Количество опор
        /// </summary>
        public int SupportsCount =>
            _bridges.Select(b => b.Supports)
            .Select(sts => sts.Count).Sum();
        #endregion

        /// <summary>
        /// Средний подмостовой габарит
        /// </summary>
        public float UnderbridgeClearanceAvg =>
            _bridges.Select(b => b.SpanStructures)
            .Select(sts => sts.Average(st => st.UnderbridgeClearance)).Average();

        /// <summary>
        /// Средняя ширина проезжей части перед сооружением
        /// </summary>
        public float CarriagewayWidthBeforeAvg =>
            _bridges.Average(b => b.CarriagewayWidthBefore);

        /// <summary>
        /// Средняя ширина проезжей части за сооружением
        /// </summary>
        public float CarriagewayWidthAfterAvg =>
            _bridges.Average(b => b.CarriagewayWidthAfter);

        /// <summary>
        /// Средняя высота насыпи перед сооружением
        /// </summary>
        public float EmbankmentHeightBeforeAvg =>
            _bridges.Average(b => b.EmbankmentHeightBefore);

        /// <summary>
        /// Средняя высота насыпи за сооружением
        /// </summary>
        public float EmbankmentHeightAfterAvg =>
            _bridges.Average(b => b.EmbankmentHeightAfter);

        public BridgesResults()
        {

        }

        public BridgesResults(IEnumerable<Bridge> bridges)
        {
            _bridges = bridges ?? throw new ArgumentNullException(nameof(bridges));
        }
    }
}
