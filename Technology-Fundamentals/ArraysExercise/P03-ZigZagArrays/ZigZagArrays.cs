using System;
using System.Linq;

namespace ZigZagArray
{
    class ZigZagArray
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    arr1[i] = numbers[0];
                    arr2[i] = numbers[1];
                }
                else
                {
                    arr2[i] = numbers[0];
                    arr1[i] = numbers[1];
                }
            }
            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
