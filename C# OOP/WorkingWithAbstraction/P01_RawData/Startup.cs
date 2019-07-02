namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                Tire tire1 = new Tire(double.Parse(parameters[5]), int.Parse(parameters[6]));
                Tire tire2 = new Tire(double.Parse(parameters[7]), int.Parse(parameters[8]));
                Tire tire3 = new Tire(double.Parse(parameters[9]), int.Parse(parameters[10]));
                Tire tire4 = new Tire(double.Parse(parameters[11]), int.Parse(parameters[12]));

                Car car = new Car(model,
                    engineSpeed, enginePower,
                    cargoWeight, cargoType,
                    tire1.Pressure, tire1.Age,
                    tire2.Pressure, tire2.Age,
                    tire3.Pressure, tire3.Age,
                    tire4.Pressure, tire4.Age);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }

            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
