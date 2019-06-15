using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private List<Car> cars; 
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car()
        {
            cars = new List<Car>();
        }
        public void AddCar(Car car)
        {
            cars.Add(car);
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; } = 0;

        public void Drive(List<Car> cars ,string model, Double distance)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Model == model)
                {
                    if (cars[i].FuelAmount>=distance*cars[i].FuelConsumptionPerKilometer)
                    {
                        cars[i].FuelAmount -= (distance * cars[i].FuelConsumptionPerKilometer);
                        cars[i].TravelledDistance += distance;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                        break;
                    }
                }
            }

        }
    }
}
