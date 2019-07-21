namespace P01_Vehicles.Core
{
    using System;

    using P01_Vehicles.Models;

    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            Car car = CreateCar();
            Truck truck = CreateTruck();

            string command;
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                command = Console.ReadLine();

                string[] tokens = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string vehicle = tokens[1];

                if (action == "Drive")
                {
                    double distance = double.Parse(tokens[2]);

                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }

                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));                        
                    }
                }

                else if (action == "Refuel")
                {
                    double litters = double.Parse(tokens[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(litters);
                    }

                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(litters);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static Truck CreateTruck()
        {
            string[] truckInput = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double truckFuelQuantity = double.Parse(truckInput[1]);
            double truckFuelConsumption = double.Parse(truckInput[2]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);
            return truck;
        }

        private static Car CreateCar()
        {
            string[] carInput = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carInput[1]);
            double carFuelConsumption = double.Parse(carInput[2]);

            Car car = new Car(carFuelQuantity, carFuelConsumption);
            return car;
        }
    }
}
