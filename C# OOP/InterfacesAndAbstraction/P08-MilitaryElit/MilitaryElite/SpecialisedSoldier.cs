using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salaary, string corps) 
            : base(id, firstName, lastName, salaary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }


        private void ParseCorps(string corpsStr)
        {
            Corps corps;
            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);
          if (!parsed)
          {
              throw new AccessViolationException("Invalid corps");
          }

            this.Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString().TrimEnd() + Environment.NewLine + $"Corps: {Corps}";
        }
    }
}
