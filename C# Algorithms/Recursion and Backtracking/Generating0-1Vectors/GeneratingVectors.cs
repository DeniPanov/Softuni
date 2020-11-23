namespace Generating0_1Vectors
{
    using System;

    public class GeneratingVectors
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var arr = new int[number];

            Generate01Combinations(0, arr);
        }

        private static void Generate01Combinations(int number, int[] arr)
        {
            if (number >= arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                arr[number] = i;
                Generate01Combinations(number + 1, arr);
            }
        }
    }
}
