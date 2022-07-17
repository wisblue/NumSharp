using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace NumSharp.UnitTest.Backends.NDArray_FromTuples
{
    [TestClass]
    public class NDArray_FromTuplesTest
    {
        [TestMethod]
        public void CastTupleToNDArray()
        {
            NDArray a = ((0.0, 1.0, 1.0), (1.0, 0.0, 0.0));
            Debug.WriteLine(a);
        }
    }
}