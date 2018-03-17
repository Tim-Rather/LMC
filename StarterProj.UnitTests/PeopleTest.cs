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
        private PeopleService svc = new PeopleService();

        [TestMethod]
        public void Insert_Test()
        {
            //arrange
            PeopleAddRequest model = new PeopleAddRequest
            {
                FirstName = "Ronald",
                MiddleInitial = 'J',
                LastName = "McDonald",
                DOB = DateTime.Now.AddYears(-30),
                ModifiedBy = "DEM"
            };
            //act
            int result = svc.Insert(model);

            //assert
            Assert.IsTrue(result > 0, "The Insert failed!");
        }

        [TestMethod]
        public void SelectAll_Test()
        {
            //arrange
            List<People> result = new List<People>();
             
            //act
            result = svc.GetAll();

            //assert
            Assert.IsTrue(result.Count > 0, "Select All has failed");
        }

        [TestMethod]
        public void SelectById_Test()
        {
            //arrange
            int id = 1;
            //act
            People result = svc.GetById(id);
            //assert
            Assert.AreEqual(id, result.Id);
        }

        [TestMethod]
        public void Update_Test()
        {
            //arrange
            People initial = svc.GetById(4);

            PeopleUpdateRequest updateModel = new PeopleUpdateRequest
            {
                Id = initial.Id,
                FirstName = initial.FirstName,
                MiddleInitial = initial.MiddleInitial,
                LastName = initial.LastName,
                DOB = initial.DOB,
                ModifiedBy = initial.ModifiedBy
            };

            //act
            svc.Update(updateModel);

            People updated = svc.GetById(4);
            //assert
            Assert.IsTrue(initial.Id == updated.Id, "The Update has failed!");
            Assert.IsTrue(initial.FirstName == updated.FirstName, "The Update has failed!");
            Assert.IsTrue(initial.MiddleInitial == updated.MiddleInitial, "The Update has failed!");
            Assert.IsTrue(initial.LastName == updated.LastName, "The Update has failed!");
            Assert.IsTrue(initial.DOB == updated.DOB, "The Update has failed!");
            Assert.IsTrue(initial.CreatedDate == updated.CreatedDate, "The Update has failed!");
            Assert.IsFalse(initial.ModifiedDate == updated.ModifiedDate, "The Update has failed!");
            Assert.IsTrue(initial.ModifiedBy == updated.ModifiedBy, "The Update has failed!");
        }

        [TestMethod]
        public void Delete_Test()
        {
            //arrange
            PeopleAddRequest test = new PeopleAddRequest
            {
                FirstName = "Test",
                LastName = "Test",
                DOB = DateTime.Now,
                ModifiedBy = "Test"
            };
            int deleteTest = svc.Insert(test);

            //act
            svc.Delete(deleteTest);

            People getDeleted = svc.GetById(deleteTest);

            //assert
            Assert.IsNull(getDeleted.FirstName, "Delete has failed!");
            Assert.IsNull(getDeleted.LastName, "Delete has failed!");
            Assert.IsFalse(test.DOB == getDeleted.DOB, "Delete has failed");
            Assert.IsNull(getDeleted.ModifiedBy, "Delete has failed!");
        }
    }
}
