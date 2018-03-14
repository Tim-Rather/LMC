using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarterProj.Models.Domain;
using StarterProj.Models.Request;
using StarterProj.Services;

namespace StarterProj.UnitTests
{
    [TestClass]
    public class PeopleTest
    {
        [TestMethod]
        public void Insert_Test()
        {
            PeopleAddRequest model = new PeopleAddRequest
            {
                FirstName = "Ronald",
                MiddleInitial = 'J',
                LastName = "McDonald",
                DOB = DateTime.Now.AddYears(-30),
                ModifiedBy = "DEM"
            };
            PeopleService svc = new PeopleService();
            int result = svc.Insert(model);

            Assert.IsTrue(result > 0, "The Insert failed!");
        }

        [TestMethod]
        public void SelectAll_Test()
        {

            PeopleService svc = new PeopleService();
            List <People> result = svc.GetAll();

            Assert.IsTrue(result.Count > 0, "Select All has failed");

        }
    }
}
