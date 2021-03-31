using System.Collections.Generic;
using System;
using System.Linq;

namespace DinoTracker.Core
{
    public class CreatePaleontologistCommand
    {
        private IPaleontologistRepository paleontologistRepository;
        private string name;
        private string username;
        private string password;

        public CreatePaleontologistCommand(IPaleontologistRepository paleontologistRepository, string name, string username, string password)
        {
            this.paleontologistRepository = paleontologistRepository;
            this.name = name;
            this.username = username;
            this.password = password;
        }

        public void Execute()
        {
            List<Paleontologist> paleontologists = this.paleontologistRepository.FindPaleontologist(this.username).ToList();

            if (paleontologists.Count > 0)
                throw new Exception("username already in use");
            else
                this.paleontologistRepository.CreatePaleontologist(this.name, this.username, this.password);
        }
    }
}