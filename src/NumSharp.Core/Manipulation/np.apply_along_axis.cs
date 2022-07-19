using System;
using System.Linq;

namespace NumSharp
{
    public static partial class np
    {
        /// <summary>
        /// Apply a function to 1-D slices along the given axis.
        /// Execute `func1d(a, * args, ** kwargs)` where `func1d` operates on 1-D arrays
        /// and `a` is a 1-D slice of `arr` along `axis`.
        /// This is equivalent to (but faster than) the following use of `ndindex` and
        ///    `s_`, which sets each of ``ii``, ``jj``, and ``kk`` to a tuple of indices::
        ///        Ni, Nk = a.shape[:axis], a.shape[axis + 1:]
        ///        for ii in ndindex(Ni) :
        ///            for kk in ndindex(Nk) :
        ///                f = func1d(arr[ii + s_[:,] + kk])
        ///                Nj = f.shape
        ///                for jj in ndindex(Nj) :
        ///                    out[ii + jj + kk] = f[jj]
        /// Equivalently, eliminating the inner loop, this can be expressed as::
        ///        Ni, Nk = a.shape[:axis], a.shape[axis + 1:]
        ///        for ii in ndindex(Ni) :
        ///            for kk in ndindex(Nk) :
        ///                out[ii + s_[...,] + kk] = func1d(arr[ii + s_[:,] + kk])
        /// </summary>
        /// <param name="func1d">function(M,) -> (Nj...)
        ///       This function should accept 1-D arrays.It is applied to 1-D
        ///       slices of `arr` along the specified axis.</param>
        /// <param name="axis">integer
        ///       Axis along which `arr` is sliced.</param>
        /// <param name="a">ndarray (Ni..., M, Nk...)
        ///       Input array.</param>
        /// <returns>ndarray  (Ni..., Nj..., Nk...)
        ///       The output array. The shape of `out` is identical to the shape of
        ///        `arr`, except along the `axis` dimension.This axis is removed, and
        ///       replaced with new dimensions equal to the shape of the return value
        ///       of `func1d`. So if `func1d` returns a scalar `out` will have one
        ///       fewer dimensions than `arr`.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <remarks>
        ///    See Also
        ///    --------
        ///    apply_over_axes : Apply a function repeatedly over multiple axes.
        ///    Examples
        ///    --------
        ///    >>> def my_func(a):
        ///    ...     \"\"\"Average first and last element of a 1-D array\"\"\"
        ///    ...     return (a[0] + a[-1]) * 0.5
        ///    >>> b = np.array([[1, 2, 3], [4, 5, 6], [7, 8, 9]])
        ///    >>> np.apply_along_axis(my_func, 0, b)
        ///    array([4., 5., 6.])
        ///    >>> np.apply_along_axis(my_func, 1, b)
        ///    array([2.,  5.,  8.])
        ///    For a function that returns a 1D array, the number of dimensions in
        ///    `outarr` is the same as `arr`.
        ///    >>> b = np.array([[8, 1, 7], [4, 3, 9], [5, 2, 6]])
        ///    >>> np.apply_along_axis(sorted, 1, b)
        ///    array([[1, 7, 8],
        ///           [3, 4, 9],
        ///           [2, 5, 6]])
        ///    For a function that returns a higher dimensional array, those dimensions
        ///    are inserted in place of the `axis` dimension.
        ///    >>> b = np.array([[1, 2, 3], [4, 5, 6], [7, 8, 9]])
        ///    >>> np.apply_along_axis(np.diag, -1, b)
        ///    array([[[1, 0, 0],
        ///            [0, 2, 0],
        ///            [0, 0, 3]],
        ///           [[4, 0, 0],
        ///            [0, 5, 0],
        ///            [0, 0, 6]],
        ///           [[7, 0, 0],
        ///            [0, 8, 0],
        ///            [0, 0, 9]]])
        ///  </remarks>
        public static NDArray apply_along_axis(Func<NDArray, NDArray> func1d, int axis, NDArray a)
        {
            var arr = np.asanyarray(a);
            var nd = arr.ndim;
            // handle negative axes
            axis = NumSharp.Backends.DefaultEngine.normalize_axis_index(axis, nd);

            // arr, with the iteration axis at the end
            var in_dims = np.arange(nd);
            var p1 = in_dims[new Slice(stop: axis)];
            var p2 = in_dims[new Slice(start: axis + 1)];
            var p3 = np.array(new int[] { axis });
            var premute1 = np.concatenate((p1, p2, p3));
            var inarr_view = np.transpose(arr, (int[])premute1);

            // compute indices for the iteration axes, and append a trailing ellipsis to
            // prevent 0d arrays decaying to scalars, which fixes gh-8642
            var inds_ = np.ndindex((int[])np.array(inarr_view.shape)[new Slice(stop: -1)]);
            (Slice, Slice)[] inds = new (Slice, Slice)[inds_.Count()];
            int ii = 0;
            foreach (var i in inds_)
            {
                var t = (Slice.Index(i[0]), Slice.Ellipsis);
                inds[ii] = t;
                ii++;
            }

            // invoke the function on the first item
            var iter = inds.GetEnumerator();
            var ok = iter.MoveNext();
            if (!ok)
            {
                throw new IndexOutOfRangeException(
                    "Cannot apply_along_axis when any iteration dimensions are 0"
                );
            }
            (Slice, Slice) ind0 = ((Slice, Slice))iter.Current;

            var res = np.asanyarray(func1d(inarr_view[ind0.Item1, ind0.Item2]));

            // build a buffer for storing evaluations of func1d.
            // remove the requested axis, and add the new ones on the end.
            // laid out so that each write is contiguous.
            // for a tuple index inds, buff[inds] = func1d(inarr_view[inds])
            var shp1 = np.concatenate((np.array(inarr_view.shape)[":-1"], np.array(res.shape)));
            var buff = np.zeros(shape: (int[])shp1, dtype: res.dtype);

            // permutation of axes such that out = buff.transpose(buff_permute)
            var buff_dims = np.arange(buff.ndim);
            var buff_permute = np.concatenate(
                (buff_dims[new Slice(start: 0, stop: axis)],
                 buff_dims[new Slice(start: buff.ndim - res.ndim, stop: buff.ndim)],
                 buff_dims[new Slice(start: axis, stop: buff.ndim - res.ndim)])
            );

            //  save the first result, then compute and save all remaining results
            buff[ind0.Item1, ind0.Item2] = res;

            foreach (var ind in inds)
                buff[ind.Item1, ind.Item2] = np.asanyarray(func1d(inarr_view[ind.Item1, ind.Item2]));

            return np.transpose(buff, (int[])buff_permute);
        }
    }
}
