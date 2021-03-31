using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using DinoTracker.Core;
using Moq;
using System.Collections.Generic;

namespace DinoTracker.Core.Test
{
    [TestClass]
    public class CreateResearcherCommandTest
    {
        string name = "Test User";

        [TestMethod]
        public void CreateResearcherCallsRepoTest()
        {
            Mock<IResearcherRepository> researcherRepository = new Mock<IResearcherRepository>();

            List<Researcher> researchers = new List<Researcher>();
            Researcher researcher = new Researcher(name);

            researcherRepository.Setup(p => p.CreateResearcher(name))
                                    .Callback(() => researchers.Add(researcher));

            CreateResearcherCommand createResearcherCommand = new CreateResearcherCommand(researcherRepository.Object, name);
            createResearcherCommand.Execute();
            Assert.AreEqual(researchers.Count, 1);
        }
    }
}
