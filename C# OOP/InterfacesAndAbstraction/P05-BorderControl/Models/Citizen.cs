namespace P05_BorderControl.Models
{
    using P05_BorderControl.Interfaces;

    public class Citizen : Ids
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Id { get; private set; }

        public int Age { get; private set; }

        public string Name { get; private set; }
    }
}
