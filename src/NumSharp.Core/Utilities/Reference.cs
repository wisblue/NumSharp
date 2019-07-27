﻿namespace NumSharp.Backends.Unmanaged {
    /// <summary>
    ///     Holds a reference to any value.
    /// </summary>
    internal class Reference<T>
    {
        public T Value;

        public Reference(T value)
        {
            Value = value;
        }

        public Reference() { }
    }
}
