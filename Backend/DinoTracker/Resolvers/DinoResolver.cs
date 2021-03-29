using DinoTracker.Core;
using HotChocolate;

namespace DinoTracker.Resolvers
{
    public class DinoResolver
    {
        public string GetName([Parent]Dino dino)
        {
            return dino.Name;
        }

        public int GetAge([Parent]Dino dino)
        {
            return dino.Age;
        }
    }
}