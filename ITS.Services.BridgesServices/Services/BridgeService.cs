using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;
using ITS.Core;
using ITS.Core.Security;
using ITS.Core.Bridges.DataInterfaces;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.ServiceInterfaces;
using ITS.ProjectBase.Data;
using ITS.ProjectBase.Service;
using ITS.ProjectBase.Utils.ExceptionHandling;
using ITS.ProjectBase.Utils.WCF.Compressor;
using ITS.ProjectBase.Utils.WCF.FaultContracts;
using ITS.Core.Domain.Photos;

namespace ITS.Services.BridgesServices.Services
{
    [MessageCompression(Compress.Reply | Compress.Request)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
        InstanceContextMode = InstanceContextMode.PerSession,
        UseSynchronizationContext = false,
        AutomaticSessionShutdown = true)]
    public class BridgeService : AbstractService<Bridge, long>, IBridgeService
    {
        protected override IDAO<Bridge, long> GetDAO()
        {
            try
            {
                return ApplicationService.GetDaoService().GetDao<IBridgeDAO>();
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                throw;
            }
        }

        #region Члены IBridgeService

        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public Bridge GetByFeature(long featureId)
        {
            try
            {
                return ((IBridgeDAO)GetDAO()).GetByFeature(featureId);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        public override Bridge SaveOrUpdate(Bridge entity)
        {
            try
            {
                var transient = entity.IsTransient();
                entity = GetDAO().Save(entity);
                HistoryManager.CreateOrUpdate(entity, entity.FeatureObject.Layer.Map.Alias, transient);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
            return entity;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        public override void DeleteAndCommit(Bridge entity)
        {
            try
            {
                GetDAO().Delete(entity);
                HistoryManager.Delete(entity, entity.FeatureObject.Layer.Map.Alias);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
        }

        /// <summary>
        /// Возвращает список объектов Дорожный ремонт по списку ИД геометрий
        /// Испольхуется в LayerLoader
        /// </summary>
        /// <param name="ids">Список ИД геометрий</param>
        /// <returns>Список объектов Дорожный ремонт</returns>
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public List<Bridge> GetBridgesByFeatureObjectIDs(List<long> ids)
        {

            try
            {
                return ((IBridgeDAO)GetDAO()).GetBridgesByFeatureObjectIDs(ids);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex);
                throw new FaultException<BaseFault>(fault);
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public IEnumerable<Bridge> FilterBridges(ICollection<ITS.Core.Domain.Filters.Filter> bridgeFilters)
        {
            try
            {
                return ((IBridgeDAO)GetDAO()).FilterBridges(bridgeFilters);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public IEnumerable<Photo> GetPhotosByBridge(Bridge bridge)
        {
            try
            {
                return ((IBridgeDAO)GetDAO()).GetPhotosByBridge(bridge);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(fault);
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public int GetFeatureVersion(long objectId)
        {
            int result;
            try
            {
                result = ((IBridgeDAO)GetDAO()).GetFeatureVersion(objectId);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(fault);
            }
            return result;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public Dictionary<long, Dictionary<long, string>> GetBridgesInfoByFeatureObjectIDs(IEnumerable<long> featureIds)
        {
            try
            {
                return ((IBridgeDAO)GetDAO()).GetBridgesInfoByFeatureObjectIDs(featureIds);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex);
                throw new FaultException<BaseFault>(fault);
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public Dictionary<long, string> GetBridgeInfoByFeatureObjectID(long featureId)
        {
            try
            {
                return ((IBridgeDAO)GetDAO()).GetBridgeInfoByFeatureObjectID(featureId);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex);
                throw new FaultException<BaseFault>(fault);
            }
        }
        #endregion
    }
    
}
