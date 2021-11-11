using ITS.Core.ServiceInterfaces;
using ITS.Core.Bridges.DataInterfaces;
using ITS.Core.Bridges.ServiceInterfaces;
using ITS.Data.Bridges.DAO;
using ITS.Services.BridgesServices.Services;
using Microsoft.Practices.Unity;

namespace ITS.Services.BridgesServices
{
    /// <summary>
    ///     Конфигуратор сервисов.
    /// </summary>
    public class BridgeServiceConfigurator : IServiceConfigurator
    {
        /// <summary>
        ///     Конфигурирует сервис.
        /// </summary>
        /// <param name="container">Контейнер.</param>
        /// <param name="manager">Менеджер хостов.</param>
        public void Configure(IUnityContainer container, IServiceHostManager manager)
        {
            container.RegisterType<IBridgeDAO, BridgeDAO>()
                .RegisterType<IBridgeObstacleDAO, BridgeObstacleDAO>()
                .RegisterType<IBridgeSupportDAO, BridgeSupportDAO>()
                .RegisterType<ISpanStructureDAO, SpanStructureDAO>()
                .RegisterType<IMaterialDAO, MaterialDAO>()
                .RegisterType<IDefectDAO, DefectDAO>()
                .RegisterType<IDefectTypeDAO, DefectTypeDAO>()
                .RegisterType<IDefectScrollSectionDAO, DefectScrollSectionDAO>()
                .RegisterType<ITypicalProjectDAO, TypicalProjectDAO>()
                .RegisterType<IInfoOfRepairsDAO, InfoOfRepairsDAO>()
                .RegisterType<ITerritoryDAO, TerritoryDAO>()
                .RegisterType<IDocumentationInfoDAO, DocumentationInfoDAO>();
            manager.Register(typeof(IBridgeService), typeof(BridgeService), "bridges/bridge")
                .Register(typeof(IBridgeObstacleService), typeof(BridgeObstacleService), "bridges/bridge_obstacle")
                .Register(typeof(IBridgeSupportService), typeof(BridgeSupportService), "bridges/bridge_support")
                .Register(typeof(ISpanStructureService), typeof(SpanStructureService), "bridges/span_structure")
                .Register(typeof(IMaterialService), typeof(MaterialService), "bridges/material")
                .Register(typeof(IDefectService), typeof(DefectService), "bridges/defect")
                .Register(typeof(IDefectTypeService), typeof(DefectTypeService), "bridges/defect_type")
                .Register(typeof(IDefectScrollSectionService), typeof(DefectScrollSectionService), "bridges/defect_scroll_section")
                .Register(typeof(ITypicalProjectService), typeof(TypicalProjectService), "bridges/typical_project")
                .Register(typeof(IInfoOfRepairsService), typeof(InfoOfRepairsService), "bridges/info_of_repairs")
                .Register(typeof(ITerritoryService), typeof(TerritoryService), "bridges/territory")
                .Register(typeof(IDocumentationInfoService), typeof(DocumentationInfoService), "bridges/documentation_info");
        }
    }
}
