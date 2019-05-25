namespace P02_SquaresInMatrix
{
    using System;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);

            int rows = int.Parse(matrixSizes[0]);
            int cols = int.Parse(matrixSizes[1]);

            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int mathchesCounter = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    string firstElement = matrix[row, col];
                    string secondElement = matrix[row, col + 1];
                    string thirdElement = matrix[row + 1, col];
                    string fourthElement = matrix[row + 1, col + 1];

                    if (firstElement == secondElement &&
                        secondElement == thirdElement &&
                        thirdElement == fourthElement)
                    {
                        mathchesCounter++;
                    }
                }
            }

            Console.WriteLine(mathchesCounter);
        }
    }
}
