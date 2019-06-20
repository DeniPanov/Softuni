namespace P02_SetsOfElements
{
    using System;
    using System.Collections.Generic;

    public class SetsOfElements
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int nSetSize = int.Parse(sizes[0]);
            int mSetSize = int.Parse(sizes[1]);

            var nNumbersHash = new HashSet<int>(nSetSize);
            var mNumbersHash = new HashSet<int>(mSetSize);
            var hashToPrint = new HashSet<int>(nSetSize + mSetSize);

            int nCounter = 0;

            nCounter = FillsHashes(nSetSize, mSetSize, nNumbersHash, mNumbersHash, nCounter);

            foreach (var element in nNumbersHash)
            {
                if (mNumbersHash.Contains(element))
                {
                    hashToPrint.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", hashToPrint));
        }

        private static int FillsHashes(int nSetSize, int mSetSize, HashSet<int> nNumbersHash, HashSet<int> mNumbersHash, int nCounter)
        {
            for (int i = 0; i < mSetSize + nSetSize; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (nCounter < nSetSize)
                {
                    nNumbersHash.Add(input);
                }
                else
                {
                    mNumbersHash.Add(input);
                }

                nCounter++;
            }

            return nCounter;
        }
    }
}
