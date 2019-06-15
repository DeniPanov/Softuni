using System.Collections.Generic;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private List<Tire> tires;

        public string Model { get => model; set => model = value; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire Tire { get; set; }
        public List<Tire> Tires { get => tires; set => tires = value; }

        public Car(
            string model,
            int engineSpeed,
            int enginePower,
            int cargoWeight,
            string cargoType,
            double tire1Pressure,
            int tire1Age,
            double tire2Pressure,
            int tire2Age,
            double tire3Pressure,
            int tire3Age,
            double tire4Pressure,
            int tire4Age)
        {
            Engine = new Engine();
            Cargo = new Cargo();
            Tire = new Tire();
            Tires = new List<Tire>();

            Model = model;
            Engine.Speed = engineSpeed;
            Engine.Power = enginePower;
            Cargo.Weight = cargoWeight;
            Cargo.Type = cargoType;
            Tire.Pressure = tire1Pressure;
            Tire.Age = tire1Age;
            Tire.Pressure = tire2Pressure;
            Tire.Age = tire2Age;
            Tire.Pressure = tire3Pressure;
            Tire.Age = tire3Age;
            Tire.Pressure = tire4Pressure;
            Tire.Age = tire4Age;
        }
    }
}
