namespace PersonInfo.MilitaryElite
{
    public class Repairs : IRepairs
    {
        public Repairs (string partName, int horrsWorked)
        {
            PartName = partName;
            HoursWorked = horrsWorked;
        }

        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
