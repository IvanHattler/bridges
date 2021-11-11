using System;
using System.Collections.Generic;
using System.Linq;
using GeoAPI.Geometries;
using ITS.Core;
using ITS.Core.DataInterfaces;
using ITS.Core.Domain.FeatureObjects;
using ITS.Core.Domain.Organizations;
using ITS.Core.Enums;
using ITS.Core.Bridges.DataInterfaces;
using ITS.Core.Bridges.Domain;
using ITS.ProjectBase.Data;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Spatial.Criterion;
using ITS.Core.Domain.Photos;

namespace ITS.Data.Bridges.DAO
{
    public class BridgeDAO : AbstractNHibernateDAO<Bridge, long>, IBridgeDAO
    {
        private IPhotoDAO _photoDAO;
        /// <summary>
        /// Создает слой доступа к данным по объектам типа.
        /// </summary>
        /// <param name="sessionFactoryConfigPath">Путь к фабрике NHibernate.</param>
        public BridgeDAO(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
               _photoDAO = ApplicationService.GetDaoService().GetDao<IPhotoDAO>();
        }

        public override Bridge Save(Bridge entity)
        {
            entity = base.Save(entity);
            using (var session = NHibernateSession)
            {
                using (var t = session.BeginTransaction())
                {
                    var envelope = entity.FeatureObject.Geometry.EnvelopeInternal;
                    session.SaveOrUpdate(entity);
                    envelope.ExpandToInclude(entity.FeatureObject.Geometry.EnvelopeInternal);
                    UpdateMapGrid(entity, envelope, session);

                    t.Commit();
                }
            }
            _photoDAO.SavePhotoForPhotoable(entity);
            return entity;
        }

        public override void Delete(Bridge entity)
        {
            using (var session = NHibernateSession)
            {
                using (var t = session.BeginTransaction())
                {
                    session.Delete(entity);
                    var envelope = entity.FeatureObject.Geometry.EnvelopeInternal;
                    var q = session.CreateCriteria<MapGrid>("mg")
                        .Add(Restrictions.Eq("mg.Map.ID", entity.FeatureObject.Layer.Map.ID))
                        .Add(SpatialRestrictions.Filter("mg.Bounds", envelope, 4326));
                    var mapGridList = q.List<MapGrid>();
                    foreach (var mapGrid in mapGridList)
                    {
                        session.Lock(mapGrid, LockMode.Force);
                    }
                    t.Commit();
                }
                _photoDAO.DeletePhotoByPhotoable(entity);
            }
        }

        private void UpdateMapGrid(Bridge entity, Envelope envelope, ISession session)
        {
            var q = session.CreateCriteria<MapGrid>("mg")
                .Add(Restrictions.Eq("mg.Map.ID", entity.FeatureObject.Layer.Map.ID))
                .Add(SpatialRestrictions.Filter("mg.Bounds", envelope, 4326));
            var mapGridList = q.List<MapGrid>();
            foreach (var mapGrid in mapGridList)
            {
                session.Lock(mapGrid, LockMode.Force);
            }
        }

        public Bridge GetByFeature(long featureId)
        {
            using (var session = NHibernateSession)
            {
                var list = session.QueryOver<Bridge>()
                        .Where(b => b.FeatureObject != null && b.FeatureObject.ID == featureId).List().ToList();
                return list.FirstOrDefault();
            }
        }

        public List<Bridge> GetBridgesByFeatureObjectIDs(List<long> ids)
        {
            using (ISession session = NHibernateSession)
            {
                var q = session.QueryOver<Bridge>().Where(s => s.FeatureObject.ID.IsIn(ids));
                return q.List<Bridge>().ToList();
            }
        }

        public IEnumerable<Bridge> FilterBridges(ICollection<Core.Domain.Filters.Filter> bridgeFilters)
        {
            if (bridgeFilters == null)
            {
                throw new ArgumentNullException("bridgeFilters", "фильтр не должен быть пустым");
            }

            using (var session = NHibernateSession)
            {
                var criteria = session.CreateCriteria<Bridge>("Bridge")
                    .CreateAlias("Bridge.FeatureObject", "f");

                var aliases = new Dictionary<string, string>
                {
                    {"Bridge.FeatureObject", "f"},
                };

                Filtrate(criteria, bridgeFilters, aliases, "Bridge");
                var result = criteria.List<Bridge>();
                return result;
            }
        }

        public IEnumerable<Photo> GetPhotosByBridge(Bridge bridge)
        {
            return _photoDAO.GetPhotoByPhotoable(bridge);
        }

        public int GetFeatureVersion(long objectId)
        {
            using (var session = NHibernateSession)
            {
                return
                    session.QueryOver<Bridge>()
                        .Where(p => p.ID == objectId)
                        .Select(p => p.FeatureObject)
                        .SingleOrDefault<FeatureObject>()
                        .Version;
            }
        }

        public Dictionary<long, Dictionary<long, string>> GetBridgesInfoByFeatureObjectIDs(IEnumerable<long> featureIds)
        {
            using (var session = NHibernateSession)
            {
                var q = session.QueryOver<Bridge>()
                    .WhereRestrictionOn(x => x.FeatureObject.ID)
                    .IsIn(featureIds.ToArray());
                return q.List<Bridge>()
                    // Вариант типа Distinct по FeatureObjectID, чтобы не было ошибки с дублированием 
                    // ключа в словаре
                    .GroupBy(x => x.FeatureObject.ID)
                    .Select(x => x.First()) 
                    .ToDictionary(sp => sp.FeatureObject.ID, 
                        bridge => new Dictionary<long, string>(1)
                            { { bridge.ID, bridge.GetShortDescription() } });
            }
        }

        public Dictionary<long, string> GetBridgeInfoByFeatureObjectID(long featureId)
        {
            using (var session = NHibernateSession)
            {
                var q = session.QueryOver<Bridge>()
                    .Where(b => b.FeatureObject.ID == featureId);
                return q.List<Bridge>()
                    .ToDictionary(bridge => bridge.ID,
                        bridge => bridge.GetShortDescription());
            }
        }

        #region Private Methods

        private void Filtrate(ICriteria criteria, IEnumerable<Core.Domain.Filters.Filter> filters, Dictionary<string, string> aliases, string rootAlias)
        {
            var i = 0;
            foreach (var filter in filters)
            {
                if (!filter.Values.Any()) continue;

                criteria.Add(GetExpression(filter,
                    GetPropertyAlias(filter, aliases, rootAlias, ref i, (s, s1) => criteria.CreateAlias(s, s1))));
            }
        }

        private string GetPropertyAlias(Core.Domain.Filters.Filter filter, Dictionary<string, string> aliases, string rootAlias, ref int i, Action<string, string> action)
        {
            var pathNodes = new List<string>(filter.PropertyPath.Split('.'));
            var aliasName = rootAlias;
            var currentPath = aliasName;
            while (pathNodes.Count > 1)
            {
                var prop = pathNodes.First();
                currentPath += "." + prop;
                if (!aliases.Keys.Contains(currentPath))
                {
                    action(aliasName + "." + prop, aliasName = "a" + i++);
                    aliases.Add(currentPath, aliasName);
                }
                else
                {
                    aliasName = aliases[currentPath];
                }
                pathNodes.RemoveAt(0);
            }
            var propName = pathNodes[0];
            return aliasName + "." + propName;
        }

        private AbstractCriterion GetExpression(Core.Domain.Filters.Filter filter, string propName)
        {
            switch (filter.Function)
            {
                case FilterFunc.Eq:
                    if (filter.Values.Length > 1)
                    {
                        var expression = Restrictions.Or(Restrictions.Eq(propName, filter.Values[0]),
                            Restrictions.Eq(propName, filter.Values[1]));
                        for (var j = 2; j < filter.Values.Length; j++)
                        {
                            expression = Restrictions.Or(expression, Restrictions.Eq(propName, filter.Values[j]));
                        }
                        return expression;
                    }
                    return Restrictions.Eq(propName, filter.Values.First());
                case FilterFunc.Le:
                    return Restrictions.Le(propName, filter.Values.First());
                case FilterFunc.Lt:
                    return Restrictions.Lt(propName, filter.Values.First());
                case FilterFunc.Ge:
                    return Restrictions.Ge(propName, filter.Values.First());
                case FilterFunc.Gt:
                    return Restrictions.Gt(propName, filter.Values.First());
                case FilterFunc.In:
                    return Restrictions.In(propName, filter.Values);
                case FilterFunc.Between:
                    return Restrictions.Between(propName, filter.Values[0], filter.Values[1]);
                case FilterFunc.Like:
                    if (filter.FilterType != FilterType.String) break;
                    if (filter.Values.Length > 1)
                    {
                        var expression =
                            Restrictions.Or(Restrictions.Like(propName, (string)filter.Values[0], MatchMode.Anywhere),
                                Restrictions.Like(propName, (string)filter.Values[1], MatchMode.Anywhere));
                        for (var j = 2; j < filter.Values.Length; j++)
                        {
                            expression = Restrictions.Or(expression,
                                Restrictions.Like(propName, (string)filter.Values[j], MatchMode.Anywhere));
                        }
                        return expression;
                    }
                    return Restrictions.Like(propName, (string)filter.Values.First(), MatchMode.Anywhere);
                case FilterFunc.InsensitiveLike:
                    if (filter.FilterType != FilterType.String) break;
                    if (filter.Values.Length > 1)
                    {
                        var expression =
                            Restrictions.Or(
                                Restrictions.InsensitiveLike(propName, (string)filter.Values[0], MatchMode.Anywhere),
                                Restrictions.InsensitiveLike(propName, (string)filter.Values[1], MatchMode.Anywhere));
                        for (var j = 2; j < filter.Values.Length; j++)
                        {
                            expression = Restrictions.Or(expression,
                                Restrictions.InsensitiveLike(propName, (string)filter.Values[j], MatchMode.Anywhere));
                        }
                        return expression;
                    }
                    return Restrictions.InsensitiveLike(propName, (string)filter.Values.First(), MatchMode.Anywhere);
                case FilterFunc.Nullable:
                    return Restrictions.IsNull(propName);
                case FilterFunc.Id:
                    if (filter.Values.Length > 1)
                    {
                        var expression = Restrictions.Or(Restrictions.Eq(propName, long.Parse(filter.Values[0].ToString())),
                            Restrictions.Eq(propName, long.Parse(filter.Values[1].ToString())));
                        for (var j = 2; j < filter.Values.Length; j++)
                        {
                            expression = Restrictions.Or(expression, Restrictions.Eq(propName, long.Parse(filter.Values[j].ToString())));
                        }
                        return expression;
                    }
                    return Restrictions.Eq(propName, long.Parse(filter.Values.First().ToString()));
            }
            throw new ArgumentOutOfRangeException();
        }

        #endregion
    }
}