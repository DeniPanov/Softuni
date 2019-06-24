namespace P03_PeriodicTable
{
    using System;
    using System.Collections.Generic;
    public class PeriodicTable
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var chemicalCompounds = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < input.Length; j++)
                {
                    chemicalCompounds.Add(input[j]);
                }
            }

            Console.WriteLine(string.Join(" ",chemicalCompounds));
        }
    }
}
