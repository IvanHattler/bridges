using ITS.Core.Bridges.Domain;
using ITS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public class ComparerInGroups : IComparerInGroups
    {
        /// <summary>
        /// Объединяет одинаковые объекты в списки
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <returns></returns>
        public List<List<T>> CompareInGroups<T>(IList<T> objs)
            where T : DomainObject<long>, IEquatable<T>, INumberable
        {
            var res = new List<List<T>>();
            if (objs == null || objs.Count < 1)
            {
                return res;
            }
            objs = objs.OrderBy(o => o.Number).ToList();
            Dictionary<T, bool> d = new Dictionary<T, bool>(new ReferenceComparer<T>());
            foreach (var item in objs)
            {
                d.Add(item, true);
            }
            int ind = -1;
            for (int i = 0; i < objs.Count; i++)
            {
                if (d[objs[i]])
                {
                    res.Add(new List<T>() { objs[i] });
                    d[objs[i]] = false;
                    ind++;
                }
                for (int j = i; j < objs.Count; j++)
                {
                    if (d[objs[j]] && objs[i].Equals(objs[j]))
                    {
                        res[ind].Add(objs[j]);
                        d[objs[j]] = false;
                    }
                }
            }
            return res;
        }
    }
}
