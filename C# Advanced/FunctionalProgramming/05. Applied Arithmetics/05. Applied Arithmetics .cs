using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                string command = Console.ReadLine().ToLower();
                if (command== "end")
                {
                    return;
                }
                else if (command=="print")
                {
                    foreach (var item in numbers)
                    {
                        Console.Write(item+" ");
                    }
                    Console.WriteLine();
                }
                else if (command == "add")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i]++;
                    }
                }
                else if (command == "multiply")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] *= 2;
                    }
                }
                else if (command == "subtract")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] --;
                    }
                }
            }
        }
    }
}
