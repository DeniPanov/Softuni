namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int enginesCount = int.Parse(Console.ReadLine());

            Engine engine = new Engine();
            var listOfEngines = new List<Engine>();

            for (int i = 0; i < enginesCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                engine = CreatesNewEngine(engine, input);

                listOfEngines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            Car car = new Car();
            var cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                car = CreatesNewCar(listOfEngines, car, input);

                cars.Add(car);
            }

            foreach (var vehicle in cars)
            {
                Console.WriteLine($"{vehicle.Model}:");

                Console.WriteLine($"{vehicle.Engine.Model}:");
                Console.WriteLine($"Power: { vehicle.Engine.Power}");

                if (vehicle.Engine.Displacement != null)
                {
                    Console.WriteLine($"Displacement: { vehicle.Engine.Displacement}");
                }

                else
                {
                    Console.WriteLine($"Displacement: n/a");
                }

                Console.WriteLine($"Efficiency: { vehicle.Engine.Efficiency}");

                if (vehicle.Weight != null)
                {
                    Console.WriteLine($"Weight: { vehicle.Weight}");
                }

                else
                {
                    Console.WriteLine($"Weight: n/a");
                }

                Console.WriteLine($"Color: { vehicle.Color}");
            }
        }

        private static Car CreatesNewCar(List<Engine> listOfEngines, Car car, string[] input)
        {
            string carModel = input[0];
            string carEngineModel = input[1];

            Engine carEngine = listOfEngines.FirstOrDefault(e => e.Model == carEngineModel);

            if (input.Length == 2)
            {
                car = new Car(carModel, carEngine);
            }

            else if (input.Length == 3)
            {
                string weightOrColor = input[2];
                double numToParse;

                bool parsedNumber = double.TryParse(weightOrColor, out numToParse);

                if (parsedNumber)
                {
                    double carWeight = numToParse;

                    car = new Car(carModel, carEngine, carWeight);
                }

                else
                {
                    string carColor = weightOrColor;

                    car = new Car(carModel, carEngine, carColor);
                }
            }

            else if (input.Length == 4)
            {
                double carWeight = double.Parse(input[2]);
                string carColor = input[3];

                car = new Car(carModel, carEngine, carWeight, carColor);
            }

            return car;
        }

        private static Engine CreatesNewEngine(Engine engine, string[] input)
        {
            string engineModel = input[0];
            int enginePower = int.Parse(input[1]);

            if (input.Length == 4)
            {
                int engineDisplacement = int.Parse(input[2]);
                string engineEfficiency = input[3];

                engine = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);
            }

            else if (input.Length == 3)
            {
                string displacementOrEfficiency = input[2];
                int numToParse;

                bool parseSuccessfull = int.TryParse(displacementOrEfficiency,out numToParse);

                if (parseSuccessfull)
                {
                    int engineDisplacement = numToParse;
                    engine = new Engine(engineModel, enginePower, engineDisplacement);
                }

                else
                {
                    string engineEfficiency = displacementOrEfficiency;
                    engine = new Engine(engineModel, enginePower, engineEfficiency);
                }
            }

            else if (input.Length == 2)
            {
                engine = new Engine(engineModel, enginePower);
            }

            return engine;
        }
    }
}
