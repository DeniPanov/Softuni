namespace MakeASalad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            string[] vegetablesInput = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

            Queue<string> vegetables = new Queue<string>(vegetablesInput);

            int[] caloriesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> calories = new Stack<int>(caloriesInput);

            Queue<int> saladsMade = new Queue<int>();

            while (vegetables.Count > 0 && calories.Count > 0)
            {
                var currentCalories = calories.Peek();

                while (currentCalories > 0 && vegetables.Any())
                {
                    var currentVeg = vegetables.Dequeue();

                    if (currentVeg == "tomato")
                    {
                        currentCalories -= 80;
                    }

                    else if (currentVeg == "carrot")
                    {
                        currentCalories -= 136;
                    }

                    else if (currentVeg == "lettuce")
                    {
                        currentCalories -= 109;
                    }

                    else if (currentVeg == "potato")
                    {
                        currentCalories -= 215;
                    }
                }

                saladsMade.Enqueue(calories.Pop());
            }

            Console.WriteLine(string.Join(" ", saladsMade));

            if (vegetables.Any())
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }

            else if (calories.Any())
            {
                Console.WriteLine(string.Join(" ", calories));
            }
        }
    }
}