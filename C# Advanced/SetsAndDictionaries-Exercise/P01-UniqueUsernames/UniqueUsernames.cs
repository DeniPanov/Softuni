namespace P01_UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class UniqueUsernames
    {
        public static void Main()
        {
            int namesCount = int.Parse(Console.ReadLine());
            var uniqueNamesHash = new HashSet<string>();

            FillsHash(namesCount, uniqueNamesHash);

            PrintsUniqueNames(uniqueNamesHash);
        }

        private static void PrintsUniqueNames(HashSet<string> uniqueNamesHash)
        {
            foreach (var name in uniqueNamesHash)
            {
                Console.WriteLine(name);
            }
        }

        private static void FillsHash(int namesCount, HashSet<string> uniqueNamesHash)
        {
            for (int i = 0; i < namesCount; i++)
            {
                string currentName = Console.ReadLine();
                uniqueNamesHash.Add(currentName);
            }
        }
    }
}
