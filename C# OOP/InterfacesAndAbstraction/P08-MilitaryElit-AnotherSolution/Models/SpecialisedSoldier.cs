namespace P08_MilitaryElite.Models
{
    using System;
    using System.Text;
    using P08_MilitaryElite.Contracts;
    using P08_MilitaryElite.Exceptions;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => this.corps;

            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidCorpsException);
                }

                this.corps = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}");

            return result.ToString().TrimEnd();
        }
    }
}
