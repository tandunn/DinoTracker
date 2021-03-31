using System.Collections.Generic;
using System;
using System.Linq;

namespace DinoTracker.Core
{
    public class CreateResearcherCommand
    {
        private IResearcherRepository researcherRepository;
        private string name;

        public CreateResearcherCommand(IResearcherRepository researcherRepository, string name)
        {
            this.researcherRepository = researcherRepository;
            this.name = name;
        }

        public void Execute()
        {
            this.researcherRepository.CreateResearcher(this.name);
        }
    }
}