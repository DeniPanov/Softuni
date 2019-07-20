using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.FoodShortage
{
    public class FoodShortage : IRebel, IBuyer, IRobots, ICitizens
    {
        List<string> namesRebel = new List<string>();
        List<string> namesCitizens = new List<string>();

        public int result { get; set; } = 0;

        public void BuyFood(string name)
        {
            if (namesRebel.Contains(name))
            {
                result += 5 ;
            }
            else if (namesCitizens.Contains(name))
            {
                result += 10 ;
            }
        }

        public void Implement(string name, string age, string grup)
        {
            namesRebel.Add(name);
        }

        public void Implement(string model, int id)
        {

        }

        public void Implement(string name, string age, string id, string birthday)
        {
            namesCitizens.Add(name);
        }
    }
}
