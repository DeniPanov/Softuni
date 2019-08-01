namespace P08_MilitaryElite.Models
{
    using System.Text;
    using System.Collections.Generic;

    using P08_MilitaryElite.Contracts;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<Mission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<Mission>();
        }

        public IReadOnlyCollection<Contracts.IMission> Missions => this.missions;

        public void AddMission(Mission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mission in this.missions)
            {
                result.AppendLine($"  {mission.ToString().TrimEnd()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
