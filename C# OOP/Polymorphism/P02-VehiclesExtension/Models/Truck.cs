namespace P01_Vehicles.Models
{
    using System;

    using P01_Vehicles.ExceptionMessages;

    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override double Refuel(double litters)
        {
            if (litters <= 0)
            {
                Console.WriteLine((Messages.InvalidFuelAmountException));
                return FuelQuantity;
            }

            if (FuelQuantity + litters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {litters} fuel in the tank");
                return FuelQuantity;
            }

            return FuelQuantity += litters * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantity:f2}";
        }
    }
}
