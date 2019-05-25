namespace P03_MaxAndMinElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxAndMinElement
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string query = Console.ReadLine();
            var numbersInStack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                if (query.StartsWith(1.ToString()))
                {
                    var tokens = query.Split();
                    //1 20

                    int numberToPush = int.Parse(tokens[1]);
                    numbersInStack.Push(numberToPush);
                }
                else if (query == "2")
                {
                    if (numbersInStack.Count == 0)
                    {
                        query = Console.ReadLine();
                        continue;
                    }

                    numbersInStack.Pop();
                }
                else if (query == "3")
                {
                    if (numbersInStack.Count == 0)
                    {
                        query = Console.ReadLine();
                        continue;
                    }
                    Console.WriteLine(numbersInStack.Max());
                }
                else if (query == "4")
                {
                    if (numbersInStack.Count == 0)
                    {
                        query = Console.ReadLine();
                        continue;
                    }
                    Console.WriteLine(numbersInStack.Min());
                }

                query = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbersInStack));
        }
    }
}
