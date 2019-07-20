using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepairs> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salaary, string corps) 
            : base(id, firstName, lastName, salaary, corps)
        {
            repairs = new List<IRepairs>();
        }

        public IReadOnlyCollection<IRepairs> Repairs 
            => throw new NotImplementedException();

        public void AddRepairs(IRepairs repairs)
        {
            this.repairs.Add(repairs);
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Repairs:");
            foreach (var rp in repairs)
            {
                sb.AppendLine($"  {rp.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
