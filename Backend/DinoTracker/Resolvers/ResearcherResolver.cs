using DinoTracker.Core;
using HotChocolate;

namespace DinoTracker.Resolvers
{
    public class ResearcherResolver
    {
        public string GetName([Parent]Paleontologist paleontologist)
        {
            return paleontologist.Name;
        }
    }
}