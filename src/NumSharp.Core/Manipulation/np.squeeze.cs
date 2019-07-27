﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using NumSharp.Utilities;

namespace NumSharp
{
    public static partial class np
    {
        /// <summary>
        ///     Remove single-dimensional entries from the shape of an array.
        /// </summary>
        /// <param name="a">Input data.</param>
        /// <returns>The input array, but with all or a subset of the dimensions of length 1 removed. This is always a itself or a view into a.</returns>
        /// <remarks>https://docs.scipy.org/doc/numpy/reference/generated/numpy.squeeze.html</remarks>
        public static NDArray squeeze(NDArray a)
        {
            return a.reshape(a.shape.Where(x => x != 1).ToArray());
        }

        /// <summary>
        ///     Remove single-dimensional entries from the shape of an array.
        /// </summary>
        /// <param name="a">Input data.</param>
        /// <param name="axis">Selects a subset of the single-dimensional entries in the shape. If an axis is selected with shape entry greater than one, an error is raised.</param>
        /// <returns>The input array, but with all or a subset of the dimensions of length 1 removed. This is always a itself or a view into a.</returns>
        /// <remarks>https://docs.scipy.org/doc/numpy/reference/generated/numpy.squeeze.html</remarks>
        /// <exception cref="IncorrectShapeException">If axis is not None, and an axis being squeezed is not of length 1</exception>
        public static NDArray squeeze(NDArray a, int axis)
        {
            if (axis < 0)
                axis = a.ndim + axis;

            if (axis >= a.ndim)
                throw new ArgumentOutOfRangeException(nameof(axis));

            var shape = a.shape;
            if (shape[axis] != 1)
                throw new IncorrectShapeException($"Unable to squeeze axis {axis} because it is of length {shape[axis]} and not 1.");

            return a.reshape(shape.RemoveAt(axis));
        }

        /// <summary>
        ///     Remove single-dimensional entries from a shape.
        /// </summary>
        /// <param name="shape">Input shape.</param>
        /// <returns>The input array, but with all or a subset of the dimensions of length 1 removed. This is always a itself or a view into a.</returns>
        /// <remarks>https://docs.scipy.org/doc/numpy/reference/generated/numpy.squeeze.html</remarks>
        public static Shape squeeze(Shape shape)
        {
            //TODO! what will happen if its a slice?
            return new Shape(shape.dimensions.Where(d=>d!=1).ToArray());
        }
    }
}
