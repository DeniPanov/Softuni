namespace P06_AutoRepairAndService
{
    using System;
    using System.Collections.Generic;

    public class AutoRepairAndService
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = Console.ReadLine();

            var carsToServe = new Queue<string>(input);
            var servedCars = new Stack<string>();

            while (command != "End")
            {
                if (command == "Service")
                {
                    if (carsToServe.Count != 0)
                    {
                        string vehicleName = carsToServe.Peek();
                        Console.WriteLine($"Vehicle {carsToServe.Dequeue()} got served.");
                        servedCars.Push(vehicleName);
                    }
                }
                else if (command.StartsWith("CarInfo"))
                {
                    //CarInfo-MERCEDESClk

                    var tokens = command.Split('-');
                    string modelName = tokens[1];

                    if (carsToServe.Contains(modelName))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }

                }
                else if (command == "History")
                {
                    Console.WriteLine(string.Join(", ", servedCars));
                }

                command = Console.ReadLine();
            }

            if (carsToServe.Count != 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", carsToServe)}");
            }

            Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");
        }
    }
}
