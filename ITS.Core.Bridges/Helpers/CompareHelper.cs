using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Helpers
{
    public static class CompareHelper
    {
        public static bool Compare(float[] arr1, float[] arr2)
        {
            return (arr1 != null && arr2 != null && arr1.SequenceEqual(arr2))
                || (arr1 == null && arr2 == null);
        }
    }
}
