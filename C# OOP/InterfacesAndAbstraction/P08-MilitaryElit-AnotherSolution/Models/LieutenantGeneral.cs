namespace P08_MilitaryElite.Models
{
    using System.Text;
    using System.Collections.Generic;

    using P08_MilitaryElite.Contracts;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<ISoldier> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => this.privates;

        public void AddPrivate(ISoldier soldier)
        {
            this.privates.Add(soldier);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var @private in privates)
            {
                result.AppendLine($"  {@private.ToString().TrimEnd()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
