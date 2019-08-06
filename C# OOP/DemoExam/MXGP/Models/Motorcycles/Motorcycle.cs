namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Models.Motorcycles.Contracts;

    public abstract class Motorcycle : IMotorcycle
    {
        private const int MIN_HORSEPOWER_VALUE = 70;
        private const int MAX_HORSEPOWER_VALUE = 100;

        private string model;
        private int horsePower;
        private double cubicCentimeters;

        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)  //consider validation for model unique names
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                this.model = value;
            }
        }

        public virtual int HorsePower
        {
            get => this.horsePower;

            protected set //instead of private?
            {
                if (value < MIN_HORSEPOWER_VALUE || value > MAX_HORSEPOWER_VALUE)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }
        }

        public virtual double CubicCentimeters
        {
            get => this.cubicCentimeters;

            private set
            {
                this.cubicCentimeters = value;
            }
        }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
