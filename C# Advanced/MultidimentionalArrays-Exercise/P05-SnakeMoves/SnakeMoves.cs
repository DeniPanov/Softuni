namespace P05_SnakeMoves
{
    using System;
    using System.Collections.Generic;

    public class SnakeMoves
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine().Split();

            int rows = int.Parse(matrixSizes[0]);
            int cols = int.Parse(matrixSizes[1]);

            var matrix = new string[rows][];

            var input = Console.ReadLine().ToCharArray();
            var queueOfChars = new Queue<char>(input);


            FillsMatrix(matrix, cols, queueOfChars);

            PrintsMatrix(matrix);
        }

        private static void PrintsMatrix(string[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void FillsMatrix(string[][] matrix, int cols, Queue<char> queueOfChars)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[cols];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = queueOfChars.Peek().ToString();
                    queueOfChars.Enqueue(queueOfChars.Dequeue());
                }
            }
        }
    }
}
