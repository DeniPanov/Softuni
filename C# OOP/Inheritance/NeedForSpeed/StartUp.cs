using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                FamilyCar car = new FamilyCar(70,50);
                RaceMotorcycle crossMotorcycle = new RaceMotorcycle(30, 20);
                SportCar sCar = new SportCar(150, 50);
                sCar.Drive(300);
                Console.WriteLine(sCar.Fuel);
            }

            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
