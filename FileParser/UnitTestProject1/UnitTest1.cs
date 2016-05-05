using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileParser;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyParser mp = new MyParser(new PipeParser(), "asdf");
            Assert.IsNotNull(mp);
        }
    }
}
