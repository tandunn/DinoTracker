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

        public bool Login([Service]IPaleontologistRepository repo)
        {
            string userId = "user1"; // Obtained from frontend input field
            string password = "1234"; // Obtained from frontend input field

            List<Paleontologist> paleontologists = repo.FindPaleontologist(userId).ToList();

            Paleontologist paleontologist;
            if (paleontologists.Count > 0)
                paleontologist = paleontologists[0];
            else
                return false;

            if (paleontologist.Password != password)
                return false;

            repo.SetLoggedIn(paleontologist.Id, true);

            return true;
        }
    }
}
