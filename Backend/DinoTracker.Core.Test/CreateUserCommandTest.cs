using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using DinoTracker.Core;
using Moq;
using System.Collections.Generic;

namespace DinoTracker.Core.Test
{
    [TestClass]
    public class CreateUserCommandTest
    {
            string name = "Test User";
            string username = "user1";
            string password = "1234";
            bool loggedIn = false;

        [TestMethod]
        public void CreateUserCallsRepoTest()
        {
            Mock<IPaleontologistRepository> paleontologistRepository = new Mock<IPaleontologistRepository>();

            List<Paleontologist> paleontologists = new List<Paleontologist>();
            Paleontologist paleontologist = new Paleontologist(name, username, password, loggedIn);

            paleontologistRepository.Setup(p => p.FindPaleontologist(username))
                                    .Returns(paleontologists);
            paleontologistRepository.Setup(p => p.CreatePaleontologist(name, username, password))
                                    .Callback(() => paleontologists.Add(paleontologist));

            CreatePaleontologistCommand createPaleontologistCommand = new CreatePaleontologistCommand(paleontologistRepository.Object, name, username, password);
            createPaleontologistCommand.Execute();
            Assert.AreEqual(paleontologists.Count, 1);
        }

        [TestMethod]
        public void CreateUserWithExistingUsernameThrowsExceptionTest()
        {
            Mock<IPaleontologistRepository> paleontologistRepository = new Mock<IPaleontologistRepository>();

            List<Paleontologist> paleontologists = new List<Paleontologist>();
            Paleontologist paleontologist = new Paleontologist(name, username, password, loggedIn);
            paleontologists.Add(paleontologist);

            paleontologistRepository.Setup(p => p.FindPaleontologist(username))
                                    .Returns(paleontologists);
            paleontologistRepository.Setup(p => p.CreatePaleontologist(name, username, password))
                                    .Callback(() => paleontologists.Add(paleontologist));

            CreatePaleontologistCommand createPaleontologistCommand = new CreatePaleontologistCommand(paleontologistRepository.Object, name, username, password);
            Assert.ThrowsException<Exception>(() => createPaleontologistCommand.Execute());
        }
    }
}
