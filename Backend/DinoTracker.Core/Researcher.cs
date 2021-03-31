namespace DinoTracker.Core
{
    public class Researcher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Researcher(string name)
        {
            Name = name;
        }
    }
}
