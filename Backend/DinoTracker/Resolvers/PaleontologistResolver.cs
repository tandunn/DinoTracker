using DinoTracker.Core;
using HotChocolate;

namespace DinoTracker.Resolvers
{
    public class PaleontologistResolver
    {
        public string GetName([Parent]Paleontologist paleontologist)
        {
            return paleontologist.Name;
        }

        public string GetUsername([Parent]Paleontologist paleontologist)
        {
            return paleontologist.Username;
        }

        public string GetPassword([Parent]Paleontologist paleontologist)
        {
            return paleontologist.Password;
        }

        public bool LoggedIn([Parent]Paleontologist paleontologist)
        {
            return paleontologist.LoggedIn;
        }
    }
}