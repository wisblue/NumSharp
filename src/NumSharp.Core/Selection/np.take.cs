using System;
namespace NumSharp
{
    public static partial class np
    {
        public static NDArray take(NDArray a, NDArray indices, int axis = 0)
        {
            Func<NDArray, NDArray> func1d = a_1d => a_1d[indices];
            var arr = np.apply_along_axis(func1d, axis: axis, a);

            return arr;
        }

        public static NDArray take(NDArray a, NDArray indices, int axis, ref NDArray out_arr)
        {

            var arr = take(a, indices, axis);

            Shape shape_arr = new Shape(arr.shape);
            Shape shape_out_arr = new Shape(out_arr.shape);
            if (shape_out_arr != shape_arr)
            {
                throw new System.ArrayTypeMismatchException("could not broadcast input array from shape " + shape_arr.ToString() + " into shape" + shape_out_arr.ToString());
            }

            Slice[] slices = new Slice[a.ndim];
            for (int i = 0; i < a.ndim; i++)
            {
                slices[i] = Slice.All;
            }
            out_arr[slices] = arr;

            return out_arr;
        }
    }
}