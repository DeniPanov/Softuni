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
            Bus bus = CreateBus();

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

                    else if (vehicle == "Bus")
                    {
                        bus.FuelConsumption += 1.4;
                        Console.WriteLine(bus.Drive(distance));
                        bus.FuelConsumption -= 1.4;
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

                    else if (vehicle == "Bus")
                    {
                        bus.Refuel(litters);
                    }
                }

                else if (action == "DriveEmpty")
                {
                    double distance = double.Parse(tokens[2]);
                    Console.WriteLine(bus.DriveEmpty(distance));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static Bus CreateBus()
        {
            string[] busInput = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double busFuelQuantity = double.Parse(busInput[1]);
            double busFuelConsumption = double.Parse(busInput[2]);
            int busTankCapacity = int.Parse(busInput[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);
            return bus;
        }

        private static Truck CreateTruck()
        {
            string[] truckInput = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double truckFuelQuantity = double.Parse(truckInput[1]);
            double truckFuelConsumption = double.Parse(truckInput[2]);
            int truckTankCapacity = int.Parse(truckInput[3]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
            return truck;
        }

        private static Car CreateCar()
        {
            string[] carInput = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carInput[1]);
            double carFuelConsumption = double.Parse(carInput[2]);
            int carTankCapacity = int.Parse(carInput[3]);


            Car car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
            return car;
        }
    }
}
