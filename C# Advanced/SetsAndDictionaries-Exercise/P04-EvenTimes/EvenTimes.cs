namespace P04_EvenTimes
{
    using System;
    using System.Collections.Generic;

    public class EvenTimes
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (dict.ContainsKey(input) == false)
                {
                    dict[input] = 1;
                }
                else
                {
                    dict[input]++;
                }
            }

            foreach (var kvp in dict)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }
}
