using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Security;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.Core.Bridges.ServiceInterfaces;
using ITS.Core.Domain.Photos;
using ITS.Managers.BaseManagers;
using ITS.ProjectBase.Utils.ExceptionHandling;
using ITS.ProjectBase.Utils.WCF.FaultContracts;

namespace ITS.Managers.BridgesManagers.Managers
{
    public sealed class BridgeManager : AbstractManager<Bridge, long, IBridgeService>,
        IBridgeManager
    {
        #region Члены IBridgeManager

        public Bridge GetByFeature(long featureId)
        {
            Bridge res = null;
            IBridgeService channel = GetChannel();
            using (channel as IDisposable)
            {
                try
                {
                    res = channel.GetByFeature(featureId);
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
            }
            return res;
        }

        public List<Bridge> GetBridgesByFeatureObjectIDs(List<long> ids)
        {
            {
                IBridgeService channel = GetChannel();
                try
                {
                    using (channel as IDisposable)
                    {
                        return channel.GetBridgesByFeatureObjectIDs(ids);
                    }
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
                throw new Exception("Не удалось выполнить запрос к серверу.");
            }
        }

        public IEnumerable<Bridge> FilterBridges(ICollection<ITS.Core.Domain.Filters.Filter> bridgeFilters)
        {
            IEnumerable<Bridge> res = null;
            IBridgeService channel = GetChannel();
            using ((IDisposable)channel)
            {
                try
                {
                    res = channel.FilterBridges(bridgeFilters);
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
            }

            return res;
        }
        public IEnumerable<Photo> GetPhotosByBridge(Bridge bridge)
        {
            IEnumerable<Photo> result = null;
            var channel = GetChannel();

            try
            {
                using (channel as IDisposable)
                {
                    result = channel.GetPhotosByBridge(bridge);
                }
            }
            catch (FaultException<BaseFault> ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
            }
            catch (MessageSecurityException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
            }
            catch (SecurityAccessDeniedException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
            }
            catch (Exception e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
            }
            return result;
        }

        public int GetFeatureVersion(long objectId)
        {
            var result = 0;
            var channel = GetChannel();
            if (channel == null) return 0;
            try
            {
                using ((IDisposable)channel)
                {
                    result = channel.GetFeatureVersion(objectId);
                }
            }
            catch (FaultException<BaseFault> ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
            }
            catch (MessageSecurityException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
            }
            catch (SecurityAccessDeniedException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
            }
            catch (Exception e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
            }
            return result;
        }

        public Dictionary<long, Dictionary<long, string>> GetBridgesInfoByFeatureObjectIDs(IEnumerable<long> featureIds)
        {
            var channel = GetChannel();
            try
            {
                using ((IDisposable)channel)
                {
                    return channel.GetBridgesInfoByFeatureObjectIDs(featureIds);
                }
            }
            catch (FaultException<BaseFault> ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
            }
            catch (MessageSecurityException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
            }
            catch (SecurityAccessDeniedException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
            }
            catch (Exception e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
            }
            throw new Exception("Не удалось выполнить запрос к серверу.");
        }

        public Dictionary<long, string> GetBridgeInfoByFeatureObjectID(long featureId)
        {
            var channel = GetChannel();
            try
            {
                using ((IDisposable)channel)
                {
                    return channel.GetBridgeInfoByFeatureObjectID(featureId);
                }
            }
            catch (FaultException<BaseFault> ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
            }
            catch (MessageSecurityException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
            }
            catch (SecurityAccessDeniedException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
            }
            catch (Exception e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
            }
            throw new Exception("Не удалось выполнить запрос к серверу.");
        }
        #endregion
    }
}
