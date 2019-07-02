namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimestions[0];
            int cols = dimestions[1];

            int[,] matrix = new int[rows, cols];

            InitializeMatrix(rows, cols, matrix);

            string command = Console.ReadLine();
            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoS = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evil = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = evil[0];
                int evilCol = evil[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (IsInside(matrix, evilRow, evilCol))
                    {
                        matrix[evilRow, evilCol] = 0;
                    }

                    evilRow--;
                    evilCol--;
                }

                int ivoRow = ivoS[0];
                int ivoCol = ivoS[1];

                while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
                {
                    if (IsInside(matrix, ivoRow, ivoCol))
                    {
                        sum += matrix[ivoRow, ivoCol];
                    }

                    ivoCol++;
                    ivoRow--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static bool IsInside(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                                    && col >= 0 && col < matrix.GetLength(1);
        }

        private static void InitializeMatrix(int x, int y, int[,] matrix)
        {
            int value = 0;

            for (int row = 0; row < x; row++)
            {
                for (int col = 0; col < y; col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }
    }
}
