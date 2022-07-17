using System.Collections;

namespace NumSharp
{
    public partial class NDArray
    {
        public bool any()
        {
            return np.any(this);
        }
    }
}