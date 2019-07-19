using P05_BorderControl.Interfaces;

namespace P05_BorderControl.Models
{
    public class Pet : Ibirthable, INameable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
