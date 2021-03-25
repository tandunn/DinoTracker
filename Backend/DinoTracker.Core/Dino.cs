namespace DinoTracker.Core
{
    public class Dino
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Dino(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}