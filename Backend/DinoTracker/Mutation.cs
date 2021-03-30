using System.Collections.Generic;
using System.Linq;
using DinoTracker.Core;
using DinoTracker.Data;
using HotChocolate;

namespace DinoTracker
{
    public class Mutation
    {
        public bool CreatePaleontologist([Service]IPaleontologistRepository repo)
        {
            string userId = "user1"; // Obtained from frontend input field
            string password = "1234"; // Obtained from frontend input field

            // Call repo function to add paleontologist to dinoTrackerContext here
            
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
