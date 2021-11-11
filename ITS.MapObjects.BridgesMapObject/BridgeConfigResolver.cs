using ITS.Core.ManagerInterfaces;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.Core.Bridges.ServiceInterfaces;
using ITS.GIS.MapEntities.Renderer;
using ITS.Managers.BridgesManagers.Managers;
using ITS.MapObjects.BaseMapObject.Misc;
using ITS.MapObjects.BaseMapObject.Misc.PluginAttributes;
using ITS.MapObjects.BridgesMapObject.Properties;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using ITS.GIS.MapEntities.Loader;
using ITS.MapObjects.BridgesMapObject.IPresenters;
using ITS.MapObjects.BridgesMapObject.IViews;
using ITS.MapObjects.BridgesMapObject.Presenters;
using ITS.MapObjects.BridgesMapObject.Views;
using ITS.ProjectBase.Utils.Container;
using ITS.MapObjects.BridgesMapObject.Helpers;
using ITS.Core.Passports;
using ITS.MapObjects.BridgesMapObject.Passport;

namespace ITS.MapObjects.BridgesMapObject
{
    /// <summary>
    /// Регистратор компонентов плагина в IoC-контейнере.
    /// </summary>
    public class BridgeConfigResolver : IUnityConfigResolver
    {
        #region Implementation of IUnityConfigResolver

        public void ConfigureContainer(IUnityContainer container)
        {
            // Менеджер ресурсов.
            container.RegisterInstance(Resources.ResourceManager);

            // Панель с кнопками.
            container.RegisterType<IMapObjectManager, BridgePanel>(BridgeConstants.ToolName);

            // Регистрация менеджеров.
            container.RegisterType<IBridgeManager, BridgeManager>(
                new Interceptor(new InterfaceInterceptor()),
                new InterceptionBehavior<BridgeMapUpdateInterception>())
                 .RegisterType<IBridgeObstacleManager, BridgeObstacleManager>()
                 .RegisterType<IBridgeSupportManager, BridgeSupportManager>()
                 .RegisterType<ISpanStructureManager, SpanStructureManager>()
                 .RegisterType<IMaterialManager, MaterialManager>()
                 .RegisterType<IDefectManager, DefectManager>()
                 .RegisterType<IDefectTypeManager, DefectTypeManager>()
                 .RegisterType<IDefectScrollSectionManager, DefectScrollSectionManager>()
                 .RegisterType<ITypicalProjectManager, TypicalProjectManager>()
                 .RegisterType<IInfoOfRepairsManager, InfoOfRepairsManager>()
                 .RegisterType<ITerritoryManager, TerritoryManager>()
                 .RegisterType<IDocumentationInfoManager, DocumentationInfoManager>();

            container.RegisterType<BaseView>()
                .RegisterType<IBridgeEditView, BridgeEditView>()
                .RegisterType<IBridgeSummaryView, BridgeSummaryView>()
                .RegisterType<IBridgeSupportEditView, BridgeSupportEditView>()
                .RegisterType<ISpanStructureEditView, SpanStructureEditView>()
                .RegisterType<IBridgeObstacleEditView, BridgeObstacleEditView>()
                .RegisterType<IDefectEditView, DefectEditView>()
                .RegisterType<IBridgeInfoView, BridgeInfoView>()
                .RegisterType<IInfoOfRepairsEditView, InfoOfRepairsEditView>()
                .RegisterType<IDocumentationInfoEditView, DocumentationInfoEditView>()
                .RegisterType<ITypicalProjectAddView, TypicalProjectAddView>();
            container.RegisterType<IBridgeSummaryPresenter, BridgeSummaryPresenter>();

            if (BridgeConstants.CustomRendererEnabled)
            {
                // Кастомный отрисовщик.
                container.Resolve<ILayerRendererContainer>().AddRenderer(new BridgeLayerRenderer());

                Container.MainContainer.RegisterType<ICustomLayerLoader, BridgeLayerLoader>(Resources
                    .BridgeLayerAlias);
            }

            // Формирователь отчётов
            container.RegisterType<IBridgeReportMaker, BridgeReportMaker>()
                .RegisterType<IComparerInGroups, ComparerInGroups>();

            // Пути хостов.       
            Container.MainContainer.RegisterInstance(new ClientHostConfiguration<IBridgeService>("bridges/bridge"))
                .RegisterInstance(new ClientHostConfiguration<IBridgeObstacleService>("bridges/bridge_obstacle"))
                .RegisterInstance(new ClientHostConfiguration<IBridgeSupportService>("bridges/bridge_support"))
                .RegisterInstance(new ClientHostConfiguration<ISpanStructureService>("bridges/span_structure"))
                .RegisterInstance(new ClientHostConfiguration<IMaterialService>("bridges/material"))
                .RegisterInstance(new ClientHostConfiguration<IDefectService>("bridges/defect"))
                .RegisterInstance(new ClientHostConfiguration<IDefectTypeService>("bridges/defect_type"))
                .RegisterInstance(new ClientHostConfiguration<IDefectScrollSectionService>("bridges/defect_scroll_section"))
                .RegisterInstance(new ClientHostConfiguration<ITypicalProjectService>("bridges/typical_project"))
                .RegisterInstance(new ClientHostConfiguration<IInfoOfRepairsService>("bridges/info_of_repairs"))
                .RegisterInstance(new ClientHostConfiguration<ITerritoryService>("bridges/territory"))
                .RegisterInstance(new ClientHostConfiguration<IDocumentationInfoService>("bridges/documentation_info"));

            var passCollection = Container.MainContainer.Resolve<CustomPassportizatorCollection>();
            passCollection.CustomPassportizators.Add(new BridgesPassportizator());
        }

        #endregion
    }
}