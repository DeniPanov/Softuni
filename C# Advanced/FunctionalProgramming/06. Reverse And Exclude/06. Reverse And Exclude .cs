using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class ReverseAndExclude 

    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray()
                .Reverse()
                .ToList();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i]%number!=0)
                {
                    Console.Write(numbers[i]+" ");
                }
            }
        }
    }
}
