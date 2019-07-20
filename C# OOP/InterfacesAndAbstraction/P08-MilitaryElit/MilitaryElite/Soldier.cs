using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Soldier(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} ";
        }
    }
}
