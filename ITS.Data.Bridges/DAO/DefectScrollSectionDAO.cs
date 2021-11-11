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
    public class DefectScrollSectionDAO : AbstractNHibernateDAO<DefectScrollSection, long>, IDefectScrollSectionDAO
    {
        /// <summary>
        /// Создает слой доступа к данным по объектам типа.
        /// </summary>
        /// <param name="sessionFactoryConfigPath">Путь к фабрике NHibernate.</param>
        public DefectScrollSectionDAO(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
        }
    }
}