using System.Collections;
using System.Collections.Generic;
using DinoTracker.Core;

namespace DinoTracker.Core
{
    public interface IResearcherRepository
    {
        IEnumerable<Researcher> GetAll();
        void CreateResearcher(string name);
    }
}