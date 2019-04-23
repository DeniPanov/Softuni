namespace P02_StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StackSum
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse);
            var numsToSum = new Stack<int>(numbers);

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                var tokens = command.Split();
                //adD 5 6 or remove 10

                string action = tokens[0];

                if (action == "add")
                {
                    //adD 5 6
                    int num1 = int.Parse(tokens[1]);
                    int num2 = int.Parse(tokens[2]);

                    numsToSum.Push(num1);
                    numsToSum.Push(num2);
                }
                else if (action == "remove")
                {
                    //remove 10
                    int numsToRemove = int.Parse(tokens[1]);

                    if (numsToRemove > numsToSum.Count)
                    {
                        command = Console.ReadLine().ToLower();
                        continue;
                    }

                    for (int i = 0; i < numsToRemove; i++)
                    {
                        numsToSum.Pop();
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {numsToSum.Sum()}");
        }
    }
}
