namespace P01_Vehicles.Models
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; set; }

        public virtual double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;

            if (FuelQuantity >= neededFuel)
            {
                FuelQuantity -= neededFuel;

                return $"{GetType().Name} travelled {distance} km";
            }

            return $"{GetType().Name} needs refueling";
        }

        public abstract double Refuel(double litters);
    }
}
