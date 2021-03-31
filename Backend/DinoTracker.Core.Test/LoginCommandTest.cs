using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using DinoTracker.Core;
using Moq;
using System.Collections.Generic;

namespace DinoTracker.Core.Test
{
    [TestClass]
    public class LoginCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            string name = "Test User";
            string username = "user1";
            string password = "1234";

            Mock<IPaleontologistRepository> paleontologistRepository = new Mock<IPaleontologistRepository>();

            List<Paleontologist> paleontologists = new List<Paleontologist>();
            Paleontologist paleontologist = new Paleontologist(name, username, password, false);
            paleontologist.Id = 123;
            paleontologists.Add(paleontologist);

            paleontologistRepository.Setup(p => p.FindPaleontologist(username))
                                    .Returns(paleontologists);
            paleontologistRepository.Setup(p => p.FindPaleontologist("Wrong user"))
                                    .Throws(new Exception("user not found"));

            Assert.AreEqual(paleontologist.LoggedIn, false);

            paleontologistRepository.Setup(p => p.SetLoggedIn(paleontologist.Id, true))
                                    .Callback((int id, bool loggedIn) => paleontologist.LoggedIn = loggedIn);

            LoginCommand loginCommand = new LoginCommand(paleontologistRepository.Object, username, "Wrong password");
            Assert.ThrowsException<Exception>(() => loginCommand.Execute());

            loginCommand = new LoginCommand(paleontologistRepository.Object, "Wrong user", password);
            Assert.ThrowsException<Exception>(() => loginCommand.Execute());

            loginCommand = new LoginCommand(paleontologistRepository.Object, username, password);
            loginCommand.Execute();
            Assert.AreEqual(paleontologist.LoggedIn, true);
        }
    }
}
