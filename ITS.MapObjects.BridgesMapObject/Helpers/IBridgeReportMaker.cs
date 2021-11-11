using System.Collections.Generic;
using ITS.Core.Bridges.Domain;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public interface IBridgeReportMaker
    {
        int BridgeConditionRowsCount { get; }
        int BridgeRowsCount { get; }
        int? DefectsCount { get; }
        int? DocumentationsCount { get; }
        List<List<SpanStructure>> SpanStructureGroups { get; }
        int SpanStructureRowsCount { get; }
        List<List<BridgeSupport>> SupportGroups { get; }
        int SupportRowsCount { get; }

        List<object[]> GetBridgeConditionReport(string formerName);
        List<object[]> GetBridgeReport();
        List<object[]> GetDefectReport();
        List<object[]> GetDocumentationsReport();
        List<object[]> GetOthersInfoReport();
        List<object[]> GetSpanStructureReport(SpanStructure spanStructure);
        List<List<object[]>> GetSpanStructuresReports();
        List<object[]> GetSupportReport(BridgeSupport support);
        List<List<object[]>> GetSupportsReports();
        void Refresh();
    }
}