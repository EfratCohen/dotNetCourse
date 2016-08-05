using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsEx2
{
    [TestClass]
    public class UnitTest2
    {
        [ClassInitialize]
        public static void ClassInit2(TestContext txt)
        {
            Debug.WriteLine("ClassInit2");
        }
        [TestInitialize]
        public void TestInint2()
        {
            Debug.WriteLine("testInint2");
        }
        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine($"TestMethod1 in UnitTest2");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Debug.WriteLine($"TestMethod2 in UnitTest2");
        }
    }

}
