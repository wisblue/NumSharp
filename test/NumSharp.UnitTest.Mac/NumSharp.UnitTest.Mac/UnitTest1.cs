using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumSharp;
using System.Diagnostics;

namespace NumSharp.UnitTest.Mac;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var a = np.array(new int[] { 1, 2, 3 });
        Trace.WriteLine("Hello World");
        Trace.WriteLine(a);
    }
}

