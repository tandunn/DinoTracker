using System.Collections.Generic;
using DinoTracker.Core;
using DinoTracker.Data;
using HotChocolate;

namespace DinoTracker
{
    public class Query
    {
        public IEnumerable<Dino> GetDinos([Service]IDinoRepository repo)
        {
            return repo.GetAll();
        }

        public IEnumerable<Paleontologist> GetPaleontologists([Service]IPaleontologistRepository repo)
        {
            return repo.GetAll();
        }
    }
}
