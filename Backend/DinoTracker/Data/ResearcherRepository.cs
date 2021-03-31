using System.Collections.Generic;
using System.Linq;
using DinoTracker.Core;
using Microsoft.EntityFrameworkCore;

namespace DinoTracker.Data
{
    public class ResearcherRepository : IResearcherRepository
    {
        private DinoTrackerContext context;

        public ResearcherRepository(DinoTrackerContext context)
        {
            this.context = context;
        }

        IEnumerable<Researcher> IResearcherRepository.GetAll()
        {
            IQueryable<Researcher> allResearchers = this.context.Researchers;
            List<Researcher> loadedResearchers = allResearchers.ToList(); // Database is queried here
            return loadedResearchers;
        }

        void IResearcherRepository.CreateResearcher(string name)
        {
            Researcher researcher = new Researcher(name);
            context.Researchers.Add(researcher);
            context.SaveChanges();
            context.Entry(researcher).State = EntityState.Detached;
        }
    }
}