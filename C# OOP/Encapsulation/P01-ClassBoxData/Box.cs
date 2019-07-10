namespace P01_ClassBoxData
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => length;

            private set
            {
                ValidatePropValue(value, nameof(this.Length));

                this.length = value;
            }
        }

        public double Width
        {
            get => width;

            private set
            {
                ValidatePropValue(value, nameof(this.Width));

                this.width = value;
            }
        }

        public double Height
        {
            get => height;

            private set
            {
                ValidatePropValue(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;
            return surfaceArea;
        }

        public double CalculateLateralSurface()
        {
            double lateralSurface = 2 * length * height + 2 * width * height;
            return lateralSurface;
        }

        public double CalculateVolume()
        {
            double volume = length * width * height;
            return volume;
        }
        private static void ValidatePropValue(double value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{parameterName} cannot be zero or negative.");
            }
        }
    }
}
