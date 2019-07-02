namespace P01_RawData
{
    using System.Collections.Generic;
    public class Car
    {
        private List<Tire> tires;

        public string Model { get; set; }

        public Tire Tire { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
        public List<Tire> Tires { get => tires; set => tires = value; }

        public Car(string model, int engineSpeed, int enginePower,
            int cargoWeight, string cargoType,
            double tire1Pressure, int tire1Age,
            double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3Age,
            double tire4Pressure, int tire4Age)
        {
            Tires = new List<Tire>(4);

            Engine = new Engine(engineSpeed,enginePower);
            Cargo = new Cargo(cargoWeight,cargoType);

            this.Model = model;

            Tire tire1 = new Tire(tire1Pressure, tire1Age);
            Tire tire2 = new Tire(tire2Pressure, tire2Age);
            Tire tire3 = new Tire(tire3Pressure, tire3Age);
            Tire tire4 = new Tire(tire4Pressure, tire4Age);

            Tires.Add(tire1);
            Tires.Add(tire2);
            Tires.Add(tire3);
            Tires.Add(tire4);
        }
    }
}
