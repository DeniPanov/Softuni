namespace P06_Wardrobe
{
    using System;
    using System.Collections.Generic;

    public class Wardrobe
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var nestedDict = new Dictionary<string, Dictionary<string, int>>();

            FillsTheDictionary(n, nestedDict);

            var neededStuff = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string neededColour = neededStuff[0];
            string neededCloth = neededStuff[1];

            PrintsResult(nestedDict, neededColour, neededCloth);

        }

        private static void PrintsResult(Dictionary<string, Dictionary<string, int>> nestedDict, string neededColour, string neededCloth)
        {
            foreach (var kvp in nestedDict)
            {
                string currentColour = kvp.Key;

                Console.WriteLine($"{currentColour} clothes:");

                foreach (var cloth in kvp.Value)
                {
                    string currentCloth = cloth.Key;
                    int clothCount = cloth.Value;

                    if (currentColour == neededColour && currentCloth == neededCloth)
                    {
                        Console.WriteLine($"* {currentCloth} - {clothCount} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {currentCloth} - {clothCount}");
                }
            }
        }

        private static void FillsTheDictionary(int n, Dictionary<string, Dictionary<string, int>> nestedDict)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string colour = input[0];
                var clothes = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (nestedDict.ContainsKey(colour) == false)
                    {
                        nestedDict[colour] = new Dictionary<string, int>();
                    }

                    if (nestedDict[colour].ContainsKey(clothes[j]) == false)
                    {
                        nestedDict[colour].Add(clothes[j], 0);
                    }
                    nestedDict[colour][clothes[j]]++;
                }
            }
        }
    }
}
