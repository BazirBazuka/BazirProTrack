using Microsoft.VisualStudio.TestTools.UnitTesting;
using BazirProTrack.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BazirProTrack.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange 
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "Man";
            var controller = new UserController(userName);

            //Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller2.CurentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurentUser.Weight);
            Assert.AreEqual(height, controller2.CurentUser.Height);
            Assert.AreEqual(gender, controller2.CurentUser.Gender.Name);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange 
            var userName = Guid.NewGuid().ToString(); //Guid.NewGuid() - Создает 128ми битный псевдо уникальный идентификатор

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurentUser.Name);

        }
    }
}