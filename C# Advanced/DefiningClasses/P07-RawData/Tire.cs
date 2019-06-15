using System.Collections.Generic;

namespace DefiningClasses
{
    public class Tire
    {
        private int age;
        private double pressure;
        private List<Tire> tires;

        public Tire(double pressure, int age)
        {
            tires = new List<Tire>();

            Pressure = pressure;
            Age = age;
        }

        public Tire()
        {
            tires = new List<Tire>();
        }
        public int Age { get => age; set => age = value; }
        public double Pressure { get => pressure; set => pressure = value; }
    }
}
