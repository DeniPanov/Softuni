namespace P03_Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }
        public string Brakes { get; private set; } = "Brakes!";

        public string GasPedal { get; private set; } = "Gas!";

        public string Model { get; private set; } = "488-Spider";

        public string DriverName { get; private set; }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes}/{this.GasPedal}/{this.DriverName}";
        }
    }
}
