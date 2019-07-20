using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMissions> missions;

        public Commando(string id, string firstName, string lastName, decimal salaary, string corps) 
            : base(id, firstName, lastName, salaary, corps)
        {
            this.missions = new List<IMissions>();
        }

        public IReadOnlyCollection<IMissions> Missions
            => this.missions;

        public void AddMissions(IMissions missions)
        {
            this.missions.Add(missions);
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Missions:");
            foreach (var mis in missions)
            {
                sb.AppendLine($"  {mis.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
