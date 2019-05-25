namespace P06_BombTheBasement
{
    using System;
    using System.Linq;

    public class BombTheBasement
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int rows = int.Parse(matrixSizes[0]);
            int cols = int.Parse(matrixSizes[1]);

            var matrix = new int[rows, cols];

            FillsMatrix(matrix);

            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetRow = input[0];
            int targetCol = input[1];
            int radius = input[2];

            FiresTheBomb(matrix, targetRow, targetCol, radius);

            ReaarangeTheMatrix(matrix);

            PrintsMatrix(matrix);
        }

        private static void FiresTheBomb(int[,] matrix, int targetRow, int targetCol, int radius)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool isInRadius = Math.Pow(targetRow - row, 2) + Math.Pow(targetCol - col, 2) <= Math.Pow(radius, 2);

                    if (isInRadius)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }
        }

        private static void ReaarangeTheMatrix(int[,] matrix)
        {

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int counter = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int currentElement = matrix[row, col];

                    if (currentElement == 1)
                    {
                        counter++;
                        matrix[row, col] = 0;
                    }
                }

                int rowCounter = 0;

                for (int i = 0; i < counter; i++)
                {
                    matrix[rowCounter++, col] = 1;
                }
            }
        }

        private static void PrintsMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + "");
                }
                Console.WriteLine();
            }
        }

        private static void FillsMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                }
            }
        }
    }
}
