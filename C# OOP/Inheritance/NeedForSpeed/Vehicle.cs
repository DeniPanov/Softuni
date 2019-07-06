namespace NeedForSpeed
{
    using System;

    public abstract class Vehicle
    {
        private double fuelConsumption;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public double DefaultFuelConsumption { get; set; } = 1.25;

        public virtual double FuelConsumption
        {
            get => fuelConsumption = DefaultFuelConsumption;
            set => fuelConsumption = value;
        }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            double neededFuel = kilometers * FuelConsumption;

            if (neededFuel <= Fuel)
            {
                Fuel -= neededFuel;
            }

            else //commenting this doesn't change anything
            {
                throw new ArgumentException("Not engough fuel!");
            }
        }
    }
}
