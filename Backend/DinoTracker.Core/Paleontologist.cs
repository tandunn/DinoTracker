namespace DinoTracker.Core
{
    public class Paleontologist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; }

        public Paleontologist(string name, string username, string password, bool loggedIn)
        {
            Name = name;
            Username = username;
            Password = password;
            LoggedIn = loggedIn;
        }
    }
}
