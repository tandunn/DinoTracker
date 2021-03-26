using System.Collections.Generic;
using System;
using System.Linq;

namespace DinoTracker.Core
{
    public class LoginCommand
    {
        private IPaleontologistRepository paleontologistRepository;
        private string username;
        private string password;

        public LoginCommand(IPaleontologistRepository paleontologistRepository, string username, string password)
        {
            this.paleontologistRepository = paleontologistRepository;
            this.username = username;
            this.password = password;
        }

        public void Execute()
        {
            List<Paleontologist> paleontologists = this.paleontologistRepository.FindPaleontologist(this.username).ToList();

            Paleontologist paleontologist;
            if (paleontologists.Count > 0)
                paleontologist = paleontologists[0];
            else
                throw new Exception("user not found");

            if (paleontologist.Password != password)
                throw new Exception("incorrect password");

            this.paleontologistRepository.SetLoggedIn(paleontologist.Id, true);
        }
    }
}