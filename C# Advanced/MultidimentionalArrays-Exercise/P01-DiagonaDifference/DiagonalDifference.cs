namespace P01_DiagonaDifference
{
    using System;

    public class DiagonaDifference
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            var matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(input[col]);
                }
            }

            int firstDiagonalSum = 0;
            int firstDiagonalStartingRow = 0;
            int firstDiagonalStartingCol = 0;

            while (firstDiagonalStartingCol < matrix.GetLength(1)
                || firstDiagonalStartingRow < matrix.GetLength(0))
            {
                firstDiagonalSum += matrix[firstDiagonalStartingRow, firstDiagonalStartingCol];

                firstDiagonalStartingRow++;
                firstDiagonalStartingCol++;
            }

            int secondDiagonalSum = 0;
            int secondDiagonalStartingRow = matrix.GetLength(0) - 1;
            int secondDiagonalStartingCol = 0;

            while (secondDiagonalStartingCol < matrix.GetLength(1)
                || secondDiagonalStartingRow >= 0)
            {
                secondDiagonalSum += matrix[secondDiagonalStartingRow, secondDiagonalStartingCol];

                secondDiagonalStartingRow--;
                secondDiagonalStartingCol++;
            }

            int diagonalDifference = Math.Abs(firstDiagonalSum - secondDiagonalSum);
            Console.WriteLine(diagonalDifference);
        }
    }
}
