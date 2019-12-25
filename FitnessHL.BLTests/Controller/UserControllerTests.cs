using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessHL.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessHL.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var gender = "M/W";
            var birthDate = DateTime.Now.AddYears(-10);
            var weight = 60;
            var height = 175;
            var controller = new UserController(userName);

            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controller.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller.CurrentUser.Weight);
            Assert.AreEqual(height, controller.CurrentUser.Height);

        }

        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();

            var controller = new UserController(userName);

            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}