using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
