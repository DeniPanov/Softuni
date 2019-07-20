using System;
using System.Linq;
using PersonInfo.FoodShortage;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var foodShortage = new PersonInfo.FoodShortage.FoodShortage();

            int inpytLeine = int.Parse(Console.ReadLine());
            for (int i = 0; i < inpytLeine; i++)
            {
                var command = Console.ReadLine().Split().ToArray();
                if (command.Length == 4)
                {
                    foodShortage.Implement(command[0], command[1], command[2], command[3]);
                }
                else if (command.Length == 3)
                {
                    foodShortage.Implement(command[0], command[1], command[2]);
                }
            }
            string commandd = Console.ReadLine();
            while (commandd != "End")
            {
                foodShortage.BuyFood(commandd);
                commandd = Console.ReadLine();
            }
            Console.WriteLine(foodShortage.result);
        }
    }
}
