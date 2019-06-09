using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            Action<string> print = item => Console.WriteLine($"Sir {item}");
            for (int i = 0; i < input.Length; i++)
            {
                print(input[i]);
            }
        }
    }
}
