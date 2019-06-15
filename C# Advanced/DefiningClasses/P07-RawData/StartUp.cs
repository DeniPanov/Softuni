namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            List<Tire> tires = new List<Tire>();

            //Engine engine = new Engine();
            //Cargo cargo = new Cargo();
            //Tire tire1 = new Tire();
            //Tire tire2 = new Tire();
            //Tire tire3 = new Tire();
            //Tire tire4 = new Tire();

            for (int i = 0; i < carsCount; i++)
            {

                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);

                Tire tire1 = new Tire(tire1Pressure,tire1Age);

                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);

                Tire tire2 = new Tire(tire2Pressure, tire2Age);

                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);

                Tire tire3 = new Tire(tire3Pressure, tire3Age);

                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Tire tire4 = new Tire(tire4Pressure, tire4Age);


                Car currentCar = new Car(carModel, engineSpeed, enginePower, cargoWeight,
                                        cargoType, tire1.Pressure, tire1.Age, tire2.Pressure,
                                        tire2.Age, tire3.Pressure, tire3.Age, tire4.Pressure, tire4.Age);

                currentCar.Tires.Add(tire1);
                currentCar.Tires.Add(tire2);
                currentCar.Tires.Add(tire3);
                currentCar.Tires.Add(tire4);

                cars.Add(currentCar);
            }

            string neededCargoType = Console.ReadLine();

            var carsToPrint = new List<Car>();

            foreach (var car in cars)
            {
                if (neededCargoType == "fragile" && car.Cargo.Type == neededCargoType)
                {
                    Tire lowPressureTire = car.Tires.FirstOrDefault(t => t.Pressure < 1);

                    if (lowPressureTire != null)
                    {
                        carsToPrint.Add(car);
                    }                    
                }

                else if (neededCargoType == "flamable" && car.Cargo.Type == neededCargoType)
                {
                    if (car.Engine.Power > 250)
                    {
                        carsToPrint.Add(car);
                    }
                }
            }

            foreach (var car in carsToPrint)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
