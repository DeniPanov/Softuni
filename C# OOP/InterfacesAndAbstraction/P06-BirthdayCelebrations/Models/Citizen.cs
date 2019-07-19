namespace P05_BorderControl.Models
{
    using P05_BorderControl.Interfaces;

    public class Citizen : Ids, Ibirthable, INameable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public string Id { get; private set; }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
