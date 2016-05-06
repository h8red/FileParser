using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileParser;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Visual Studio 2015 PRO doesn't provide code coverage stats, you need ENT for that
        /// </summary>

        [TestMethod]
        public void NullChecks()
        {
            MyParser mpPipe = new MyParser(new PipeParser(), "pipe.txt");
            Assert.IsNotNull(mpPipe);

            MyParser mpCsv = new MyParser(new CSVParser(), "csv.txt");
            Assert.IsNotNull(mpCsv);

            MyParser mpSpace = new MyParser(new SpaceParser(), "space.txt");
            Assert.IsNotNull(mpSpace);


        }
    }
}
