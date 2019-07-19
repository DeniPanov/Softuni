namespace P03_Ferrari
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string driverName = Console.ReadLine();

            ICar ferrari = new Ferrari(driverName);
            Console.WriteLine(ferrari);
        }
    }
}
