using System.Collections.Generic;
using System.Linq;
using DinoTracker.Core;
using DinoTracker.Data;
using HotChocolate;

namespace DinoTracker
{
    public class Mutation
    {
        public bool CreateUser([Service]IPaleontologistRepository repo, string name, string username)
        {
            string password = "1234"; // Default password for new users

            CreatePaleontologistCommand createCommand = new CreatePaleontologistCommand(repo, name, username, password);
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
