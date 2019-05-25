namespace P03_MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

            int rows = int.Parse(matrixSizes[0]);
            int cols = int.Parse(matrixSizes[1]);

            var matrix = new int[rows][];

            GetMatrix(matrix, cols);

            int maxSum = int.MinValue;
            int startingRow = 0;
            int startingCol = 0;

            FindsMaxSum(matrix, maxSum, out int maxSum1, startingRow, out int startingRow1, startingCol, out int startingCol1); //It worked!!!
            
            PrintsResult(matrix, maxSum1, startingRow1, startingCol1);

        }

        private static void PrintsResult(int[][] matrix, int maxSum, int startingRow, int startingCol)
        {
            Console.WriteLine($"Sum = {maxSum}");

            for (int row = startingRow; row <= startingRow + 2; row++)
            {
                for (int col = startingCol; col <= startingCol + 2; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void FindsMaxSum(int[][] matrix, int maxSum, out int maxSum1, int startingRow, out int startingRow1, int startingCol, out int startingCol1)
        {
            maxSum = int.MinValue;
            int currentSum = int.MinValue;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    currentSum = 0;

                    int element1 = matrix[row][col];
                    int element2 = matrix[row][col + 1];
                    int element3 = matrix[row][col + 2];
                    int element5 = matrix[row + 1][col];
                    int element6 = matrix[row + 1][col + 1];
                    int element4 = matrix[row + 1][col + 2];
                    int element7 = matrix[row + 2][col];
                    int element8 = matrix[row + 2][col + 1];
                    int element9 = matrix[row + 2][col + 2];

                    currentSum = element1 + element2 + element3
                        + element4 + element5 + element6
                        + element7 + element8 + element9;

                    if (currentSum >= maxSum)
                    {
                        maxSum = currentSum;
                        startingRow = row;
                        startingCol = col;
                    }
                }
            }

            maxSum1 = maxSum;
            startingRow1 = startingRow;
            startingCol1 = startingCol;
        }

        private static void GetMatrix(int[][] matrix, int cols)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                matrix[row] = new int[cols];

                for (int col = 0; col < matrix[row].Length; col++) //matrix[row].Lenght == matrix[col]
                {
                    matrix[row][col] = input[col];
                }
            }
        }
    }
}
