namespace P05_SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            var matrix = new int[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];
                }
            }

            var subMatrix = new int[2, 2];
            int maxSum = int.MinValue;
            int neededRow = -1;
            int neededCol = -1;

            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    int element1 = matrix[r, c];
                    int element2 = matrix[r, c + 1];
                    int element3 = matrix[r + 1, c];
                    int element4 = matrix[r + 1, c + 1];

                    int currentSum = element1 + element2 + element3 + element4;

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        neededRow = r;
                        neededCol = c;
                    }

                    currentSum = 0;
                }
            }

            Console.WriteLine($"{matrix[neededRow, neededCol]} {matrix[neededRow, neededCol + 1]}");
            Console.WriteLine($"{matrix[neededRow + 1, neededCol]} {matrix[neededRow + 1, neededCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
