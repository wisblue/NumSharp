using System.Collections;

namespace NumSharp
{
    public partial class NDArray
    {
        public bool all()
        {
            return np.all(this);
        }
    }
}