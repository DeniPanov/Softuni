namespace P08_MilitaryElite.Models
{
    using System.Text;
    using System.Collections.Generic;

    using P08_MilitaryElite.Contracts;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepairs> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            repairs = new List<IRepairs>();
        }

        public IReadOnlyCollection<IRepairs> Repairs => repairs;

        public void AddRepair(IRepairs repairs)
        {
            this.repairs.Add(repairs);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (var repair in this.repairs)
            {
                result.AppendLine($"  {repair.ToString().TrimEnd()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
