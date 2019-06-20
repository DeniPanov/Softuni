namespace FightingArena
{
    using System.Collections.Generic;
    using System.Linq;

    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            gladiators = new List<Gladiator>();
            this.Name = name;
        }

        public string Name { get; set; }

        public int Count
            => gladiators.Count();

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public Gladiator Remove(string name) //Check the Arena; Consider void method;
        {
            Gladiator neededGladiator = gladiators.FirstOrDefault(n => n.Name == name);

            if (neededGladiator != null)
            {
                gladiators.Remove(neededGladiator);
            }

            return neededGladiator;
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator gladiator = gladiators.OrderByDescending(s => s.GetStatPower()).FirstOrDefault();
            return gladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator gladiator = gladiators.OrderByDescending(s => s.GetWeaponPower()).FirstOrDefault();
            return gladiator;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator gladiator = gladiators.OrderByDescending(s => s.GetTotalPower()).FirstOrDefault();
            return gladiator;
        }


        public override string ToString()
        {
            return $"{this.Name} - {gladiators.Count} gladiators are participating.";
        }
    }
}
