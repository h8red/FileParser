using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.Controllers;

using System.Collections.Generic;

using FileParser;
using System;
using Newtonsoft.Json;

using System.Linq;
namespace Services.Tests.Controllers
{
    [TestClass]
    public class RecordsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            RecordsController controller = new RecordsController();

            Assert.AreEqual(controller.GetName(), "[]");
            Assert.AreEqual(controller.GetGender(), "[]");
            Assert.AreEqual(controller.GetName(), "[]");


            controller.Post("a,a,Female,blue,1-27-1995");
            controller.Post("d|d|Male|orange|2-27-1976");
            controller.Post("c c Female black 3-27-1950");
            controller.Post("b,b,Male,purple,4-27-1980");

            controller.Post(null);


            List<User> lUsers = new List<User>();
            lUsers.Add(new User() { LastName = "a", FirstName = "a",  Gender = "Female", FavoriteColor = "blue", DOB = Convert.ToDateTime("1-27-1995") });
            lUsers.Add(new User() { LastName = "d", FirstName = "d", Gender = "Male", FavoriteColor = "orange", DOB = Convert.ToDateTime("2-27-1976") });
            lUsers.Add(new User() { LastName = "c", FirstName = "c", Gender = "Female", FavoriteColor = "black", DOB = Convert.ToDateTime("3-27-1950") });
            lUsers.Add(new User() { LastName = "b", FirstName = "b", Gender = "Male", FavoriteColor = "purple", DOB = Convert.ToDateTime("4-27-1980") });

            string rvStock = JsonConvert.SerializeObject(lUsers);
            string rvGender = JsonConvert.SerializeObject((from rows in lUsers orderby rows.Gender ascending, rows.LastName ascending select rows).ToList());
            string rvDob = JsonConvert.SerializeObject((from rows in lUsers orderby rows.DOB ascending select rows).ToList());
            string rvName = JsonConvert.SerializeObject((from rows in lUsers orderby rows.LastName descending select rows).ToList());


            Assert.AreEqual(controller.GetDob(), rvDob);
            Assert.AreEqual(controller.GetGender(), rvGender);
            Assert.AreEqual(controller.GetName(), rvName);

            
            
        }
    }
}
