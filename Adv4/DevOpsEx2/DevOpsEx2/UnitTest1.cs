using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace DevOpsEx2
{
    [TestClass]
    public class UnitTest1
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext txt)
        {
            Debug.WriteLine("AssemblyInit");
        }
        [ClassInitialize]
        public static void ClassInit1(TestContext txt)
        {
            Debug.WriteLine("ClassInit1");
        }
        [TestInitialize]
        public void TestInint1()
        {
            Debug.WriteLine("testInint1");
        }
        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine($"TestMethod1 in UnitTest1");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Debug.WriteLine($"TestMethod2 in UnitTest1");
        }
    }
}
