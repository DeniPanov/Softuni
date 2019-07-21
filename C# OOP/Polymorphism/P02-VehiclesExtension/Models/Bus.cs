namespace P01_Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITIONER = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            //get => base.FuelConsumption + AIR_CONDITIONER;
            set => base.FuelConsumption = value;
        }
        
        public string DriveEmpty(double distance)
        {
            //this.FuelConsumption -= AIR_CONDITIONER;
            return base.Drive(distance);
        }
        public override string ToString()
        {
            return $"Bus: {FuelQuantity:f2}";
        }
    }
}
