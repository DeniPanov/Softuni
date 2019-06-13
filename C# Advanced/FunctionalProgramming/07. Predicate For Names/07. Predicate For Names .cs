using System;

namespace _07._Predicate_For_Names
{
    class PredicateForNames 

    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].Length<=number)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }
    }
}
