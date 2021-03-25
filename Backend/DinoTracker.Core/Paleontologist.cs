namespace DinoTracker.Core
{
    public class Paleontologist
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; }

        public Paleontologist(string username, string password, bool loggedIn)
        {
            Username = username;
            Password = password;
            LoggedIn = loggedIn;
        }
    }
}
