using System;
using NumSharp.Backends;

namespace NumSharp
{
    public static partial class np
    {
        public static NDArray append(NDArray a1, NDArray a2, int axis = 0)
        {
            return concatenate(new NDArray[] { a1, a2 }, axis);
        }
    }
}