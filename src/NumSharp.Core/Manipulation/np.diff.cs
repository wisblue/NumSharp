using System;
namespace NumSharp
{
    public static partial class np
    {
        public static NDArray diff(NDArray a, int n = 1)
        {
            var ret = np.array(a, copy: true);

            for(int i = 1; i < a.shape[0]-n; i++)
            {
                ret[i] = a[i + n] - a[i];
            }

            return ret[":-1"];
        }
    }
}

