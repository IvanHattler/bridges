using System;
using System.Collections.Generic;
using ITS.Core.Bridges.Domain;
using ITS.Core.Domain;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public interface IComparerInGroups
    {
        List<List<T>> CompareInGroups<T>(IList<T> objs) where T : DomainObject<long>, IEquatable<T>, INumberable;
    }
}