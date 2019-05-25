namespace P03_MaxSum_Main
{
    using System;
    using System.Linq;

    public class MaxSum
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine().Split();

            int rows = int.Parse(matrixSizes[0]); 
            int cols = int.Parse(matrixSizes[1]);

            var matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];

                var input = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }

            int maxSum = int.MinValue;
            int currnetRow = 0;
            int currnetCol = 0;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2]
                                   + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1] [col + 2]
                                   + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        currnetRow = row;
                        currnetCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = currnetRow; row <= currnetRow + 2; row++)
            {
                for (int col = currnetCol; col <= currnetCol + 2; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
