using System.Collections.Generic;
using System.Linq;
using DinoTracker.Core;
using DinoTracker.Data;
using HotChocolate;

namespace DinoTracker
{
    public class Mutation
    {
        public bool CreatePaleontologist([Service]IPaleontologistRepository repo, string name, string username)
        {
            string password = "1234"; // Default password for new users

            CreatePaleontologistCommand createCommand = new CreatePaleontologistCommand(repo, name, username, password);
            createCommand.Execute();
            
            return true;
        }

        public bool CreateResearcher([Service]IResearcherRepository repo, string name)
        {
            CreateResearcherCommand createCommand = new CreateResearcherCommand(repo, name);
            createCommand.Execute();
            
            return true;
        }

        public bool Login([Service]IPaleontologistRepository repo, string username, string password)
        {
            LoginCommand loginCommand = new LoginCommand(repo, username, password);
            loginCommand.Execute();

            return true;
        }
    }
}
