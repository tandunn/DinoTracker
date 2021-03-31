using System.Collections;
using System.Collections.Generic;
using DinoTracker.Core;

namespace DinoTracker.Core
{
    public interface IPaleontologistRepository
    {
        IEnumerable<Paleontologist> GetAll();
        IEnumerable<Paleontologist> FindPaleontologist(string username);
        void SetLoggedIn(int Id, bool loggedIn);
        void CreatePaleontologist(string name, string username, string password);
    }
}