using System.Collections.Generic;
using System.Linq;
using DinoTracker.Core;
using Microsoft.EntityFrameworkCore;

namespace DinoTracker.Data
{
    public class PaleontologistRepository : IPaleontologistRepository
    {
        private DinoTrackerContext context;

        public PaleontologistRepository(DinoTrackerContext context)
        {
            this.context = context;
        }

        IEnumerable<Paleontologist> IPaleontologistRepository.GetAll()
        {
            IQueryable<Paleontologist> allPaleontologists = this.context.Paleontologists;
            List<Paleontologist> loadedPaleontologists = allPaleontologists.ToList(); // Database is queried here
            return loadedPaleontologists;
        }

        IEnumerable<Paleontologist> IPaleontologistRepository.FindPaleontologist(string username)
        {
            IQueryable<Paleontologist> allPaleontologists = this.context.Paleontologists;
            allPaleontologists = allPaleontologists.Where(d => d.Username == username);
            List<Paleontologist> loadedPaleontologists = allPaleontologists.ToList(); // Database is queried here
            return loadedPaleontologists;
        }

        void IPaleontologistRepository.SetLoggedIn(int Id, bool loggedIn)
        {
            Paleontologist paleontologist = context.Paleontologists.Find(Id);
            paleontologist.LoggedIn = loggedIn;
            context.Paleontologists.Update(paleontologist);
            context.SaveChanges();
            context.Entry(paleontologist).State = EntityState.Detached;
        }

        void IPaleontologistRepository.CreatePaleontologist(string name, string username, string password)
        {
            Paleontologist paleontologist = new Paleontologist(name, username, password, false);
            context.Paleontologists.Add(paleontologist);
            context.SaveChanges();
            context.Entry(paleontologist).State = EntityState.Detached;
        }
    }
}