namespace P01_Vehicles.Models
{
    using System;

    using P01_Vehicles.ExceptionMessages;

    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        {
            get => this.fuelQuantity;

            set
            {
                if (value > TankCapacity)
                {
                    this.fuelQuantity = 0;
                }

                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; set; }

        public double TankCapacity { get; private set; }

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

        public virtual double Refuel(double litters)
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

            return FuelQuantity += litters;
        }
    }
}
