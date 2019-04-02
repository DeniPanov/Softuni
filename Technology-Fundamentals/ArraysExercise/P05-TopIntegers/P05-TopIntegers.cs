using System;
using System.Linq;

namespace TopIntegers
{
    class TopIntegers
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int max = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers.Length - 1)
                {
                    Console.WriteLine(numbers[i]);
                    return;
                }

                for (int j = i + 1; j < numbers.Length; j++)
                {

                    if (numbers[i] > numbers[j])
                    {
                        max = numbers[i];
                    }
                    else
                    {
                        max = 0;
                        break;
                    }
                    if (j == numbers.Length - 1)
                    {
                        Console.Write($"{max} ");
                        max = 0;
                    }
                }
            }
        }
    }
}
