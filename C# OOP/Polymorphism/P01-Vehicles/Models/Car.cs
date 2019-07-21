namespace P01_Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 0.9;

        public override double Refuel(double litters)
        {
            return FuelQuantity += litters;
        }

        public override string ToString()
        {
            return $"Car: {FuelQuantity:f2}";
        }
    }
}
