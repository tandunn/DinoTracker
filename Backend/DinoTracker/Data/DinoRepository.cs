using System.Collections.Generic;
using System.Linq;
using DinoTracker.Core;

namespace DinoTracker.Data
{
    public class DinoRepository : IDinoRepository
    {
        private DinoTrackerContext context;

        public DinoRepository(DinoTrackerContext context)
        {
            this.context = context;
        }

        public IEnumerable<Dino> GetAll()
        {
            IQueryable<Dino> allDinos = this.context.Dinos;
            //allDinos = allDinos.Where(d => d.Name.Contains("rex"));
            List<Dino> loadedDinos = allDinos.ToList(); // Database is queried here
            return loadedDinos;
        }
    }
}