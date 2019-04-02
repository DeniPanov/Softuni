namespace P08_MagicSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] + numbers [j] == n)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]}");
                    }
                }
            }
        }
    }
}
