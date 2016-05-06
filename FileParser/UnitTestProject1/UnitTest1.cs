using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileParser;
using System.Collections.Generic;

using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Visual Studio 2015 PRO doesn't provide code coverage stats, you need ENT for that
        /// </summary>

        [TestMethod]
        public void Creation()
        {
            // use mocking to make up some data in here...

            List<User> rv = new List<User>();

            MyParser mpPipe = new MyParser(new PipeParser(), Util.ReadStringFromFile(@"c:\temp\pipe.txt"));
            Assert.IsNotNull(mpPipe);
            rv = mpPipe.myUsers;
            Assert.IsTrue(rv.Count > 0);


            MyParser mpCsv = new MyParser(new CSVParser(), Util.ReadStringFromFile(@"c:\temp\csv.txt"));
            Assert.IsNotNull(mpCsv);
            rv = mpCsv.myUsers;
            Assert.IsTrue(rv.Count > 0);


            MyParser mpSpace = new MyParser(new SpaceParser(), Util.ReadStringFromFile(@"c:\temp\space.txt"));
            Assert.IsNotNull(mpSpace);
            rv = mpSpace.myUsers;
            Assert.IsTrue(rv.Count > 0);            
        }

        [TestMethod]
        public void OutputCheck()
        {
            List<User> rv = new List<User>();

            MyParser mpPipe = new MyParser(new PipeParser(), Util.ReadStringFromFile(@"c:\temp\pipe.txt"));            
            rv = mpPipe.myUsers;

            MyParser mpCsv = new MyParser(new CSVParser(), Util.ReadStringFromFile(@"c:\temp\csv.txt"));            
            rv = mpCsv.myUsers;            

            MyParser mpSpace = new MyParser(new SpaceParser(), Util.ReadStringFromFile(@"c:\temp\space.txt"));            
            rv = mpSpace.myUsers;


            
            var rvGender = (from rows in rv orderby rows.Gender ascending, rows.LastName ascending select rows).ToList();
            Assert.AreEqual(Util.OutputByGender(rv).Count(), rvGender.Count());

            var rvDob = (from rows in rv orderby rows.DOB ascending select rows).ToList();
            Assert.AreEqual(Util.OutputByDob(rv).Count(), rvDob.Count());

            var rvName = (from rows in rv orderby rows.LastName descending select rows).ToList();
            Assert.AreEqual(Util.OutputByLastName(rv).Count(), rvName.Count());

            Assert.AreEqual(rv.First().getFormattedDob(), "11/14/1974");


            Util.OutputUsers(rv);//void, any way to make sure this test goes through since it's writing to the console?  Refactor make a factory/DI
        }
    }
}
