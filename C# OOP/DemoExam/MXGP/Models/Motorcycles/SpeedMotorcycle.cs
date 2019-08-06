namespace MXGP.Models.Motorcycles
{
    using System;

    public class SpeedMotorcycle : Motorcycle
    {
        private const int MIN_HORSEPOWER_VALUE = 50;
        private const int MAX_HORSEPOWER_VALUE = 69;
        private const int CURRENT_CUBICCENTIMETERS = 125;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, CURRENT_CUBICCENTIMETERS)
        {
        }

        public override int HorsePower
        {
            get => base.HorsePower;

            protected set
            {
                if (value < MIN_HORSEPOWER_VALUE || value > MAX_HORSEPOWER_VALUE)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }
        }

        public override double CubicCentimeters => CURRENT_CUBICCENTIMETERS;
    }
}
