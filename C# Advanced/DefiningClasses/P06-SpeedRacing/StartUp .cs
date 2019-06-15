using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var travelled = new List<Car>();
            int number = int.Parse(Console.ReadLine());
            Car car = new Car();
            for (int i = 0; i < number; i++)
            {
                car = new Car();
                var command = Console.ReadLine().Split();
                car.Model = command[0];
                car.FuelAmount = double.Parse(command[1]);
                car.FuelConsumptionPerKilometer = double.Parse(command[2]);
                travelled.Add(car);
            }
            var action = Console.ReadLine().Split();
            while (action[0] != "End")
            {
                if (action[0] == "Drive")
                {
                    var model = action[1];
                    var travelledDistance = double.Parse(action[2]);
                    car.Drive(travelled, model, travelledDistance);
                }
                action = Console.ReadLine().Split();
            }
            foreach (var item in travelled)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:F2} {item.TravelledDistance}" );
            }
        }
    }
}
