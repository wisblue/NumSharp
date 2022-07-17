using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using NumSharp.Backends;
using NumSharp.Generic;
using NumSharp.Utilities;

namespace NumSharp
{
    public static partial class np
    {
        private static int[]? incr(int[] a, int[] shape, int idim)
        {
            if (a[idim] + 1 < shape[idim])
            {
                a[idim]++;
                return a;
            }

            if (idim == 0)
                return null;

            a[idim] = 0;
            return incr(a, shape, idim - 1);
        }

        public static IEnumerable<int[]> ndindex(params int[] shp)
        {
            var n = 1;
            foreach (var i in shp)
                n *= i;

            var ndim = shp.Length;

            int[]? index = new int[ndim];
            for (int k = 0; k < ndim; k++)
                index[k] = 0;

            for (int i = 0; i < n; i++)
            {
                int[] ret = new int[ndim];
                yield return index;
                index = incr(index, shp, ndim - 1);
                //if (index is null)
                //    break;
            }
        }

    }
}
