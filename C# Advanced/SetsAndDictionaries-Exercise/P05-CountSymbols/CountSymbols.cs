namespace P05_CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class CountSymbols
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            var charsAndMatches = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (charsAndMatches.ContainsKey(input[i]) == false)
                {
                    charsAndMatches[currentChar] = 0;
                }
                charsAndMatches[currentChar]++;
            }

            foreach (var kvp in charsAndMatches)
            {
                char currentChar = kvp.Key;
                int match = kvp.Value;

                Console.WriteLine($"{currentChar}: {match} time/s");
            }
        }
    }
}
