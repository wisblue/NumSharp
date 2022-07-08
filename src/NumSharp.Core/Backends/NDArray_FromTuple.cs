using System;
using System.Runtime.CompilerServices;
using NumSharp.Backends;
using NumSharp.Backends.Unmanaged;
using NumSharp.Utilities;

// ReSharper disable once CheckNamespace
namespace NumSharp
{
    public partial class NDArray
    {
        public static implicit operator NDArray((double, double, double) tuple) =>
            new NDArray(new double[,] { { tuple.Item1, tuple.Item2, tuple.Item3 } }, new Shape(new int[] {1,3}));


        public static implicit operator NDArray((NDArray, NDArray) tuple) =>
            np.concatenate((tuple.Item1, tuple.Item2), axis:0);


        public static implicit operator NDArray((NDArray, NDArray, NDArray) tuple) =>
            np.concatenate((tuple.Item1, tuple.Item2, tuple.Item3), axis: 0);

        public static implicit operator NDArray((NDArray, NDArray, NDArray, NDArray) tuple) =>
            np.concatenate((tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4), axis: 0);


        public static implicit operator NDArray((NDArray, NDArray, NDArray, NDArray, NDArray) tuple) =>
            np.concatenate((tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5), axis: 0);

        public static implicit operator NDArray((NDArray, NDArray, NDArray, NDArray, NDArray,
                                                 NDArray) tuple) =>
            np.concatenate((tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5,
                            tuple.Item6), axis: 0);

        public static implicit operator NDArray((NDArray, NDArray, NDArray, NDArray, NDArray,
                                                 NDArray, NDArray) tuple) =>
            np.concatenate((tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5,
                            tuple.Item6, tuple.Item7), axis: 0);

        public static implicit operator NDArray((NDArray, NDArray, NDArray, NDArray, NDArray,
                                                 NDArray, NDArray, NDArray) tuple) =>
            np.concatenate((tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5,
                            tuple.Item6, tuple.Item7, tuple.Item8), axis: 0);

        public static implicit operator NDArray((NDArray, NDArray, NDArray, NDArray, NDArray,
                                                 NDArray, NDArray, NDArray, NDArray) tuple) =>
            np.concatenate((tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5,
                            tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9), axis: 0);

        public static implicit operator NDArray((NDArray, NDArray, NDArray, NDArray, NDArray,
                                                 NDArray, NDArray, NDArray, NDArray, NDArray) tuple) =>
            np.concatenate(new NDArray[] {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5,
                            tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10 }, axis: 0);

        public static implicit operator NDArray((NDArray, NDArray, NDArray, NDArray, NDArray,
                                                 NDArray, NDArray, NDArray, NDArray, NDArray,
                                                 NDArray) tuple) =>
            np.concatenate(new NDArray[] {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5,
                            tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10,
                            tuple.Item11}, axis: 0);

        public static implicit operator NDArray((NDArray, NDArray, NDArray, NDArray, NDArray,
                                                 NDArray, NDArray, NDArray, NDArray, NDArray,
                                                 NDArray, NDArray) tuple) =>
            np.concatenate(new NDArray[] {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5,
                            tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10,
                            tuple.Item11, tuple.Item12}, axis: 0);

        public static implicit operator NDArray((NDArray, NDArray, NDArray, NDArray, NDArray,
                                                 NDArray, NDArray, NDArray, NDArray, NDArray,
                                                 NDArray, NDArray, NDArray) tuple) =>
            np.concatenate(new NDArray[] {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5,
                            tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10,
                            tuple.Item11, tuple.Item12, tuple.Item13}, axis: 0);

    }
}