namespace P08_MilitaryElite.Models
{
    using System.Text;
    using P08_MilitaryElite.Contracts;

    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine($"Code Number: {this.CodeNumber}");

            return result.ToString().TrimEnd();
        }
    }
}
