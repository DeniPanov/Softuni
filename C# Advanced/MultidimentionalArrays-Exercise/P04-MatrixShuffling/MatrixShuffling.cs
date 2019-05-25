namespace P04_MatrixShuffling
{
    using System;

    public class MatrixShuffling
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine().Split();

            int rows = int.Parse(matrixSizes[0]);
            int cols = int.Parse(matrixSizes[1]);

            var matrix = new string[rows][];

            FillsMatrix(matrix, cols);

            var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "end"?.ToUpper())
            {
                if (IsValid(command))
                {
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);

                    if (row1 >= 0 && row1 < rows && col1 >= 0 && col1 < cols
                     && row2 >= 0 && row2 < rows && col2 >= 0 && col2 < cols)
                    {
                        string element1 = matrix[row1][col1];
                        string element2 = matrix[row2][col2];

                        matrix[row1][col1] = element2;
                        matrix[row2][col2] = element1;

                        PrintsMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static bool IsValid(string[] command)
        {
            return command.Length == 5 && command[0] == "swap";
        }

        private static void PrintsMatrix(string[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void FillsMatrix(string[][] matrix, int cols)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[cols];
                var input = Console.ReadLine().Split();

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
        }
    }
}
