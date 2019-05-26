namespace P02_SumMatrixColumns
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine().Split(", ");
            //3, 6

            int rowsCount = int.Parse(matrixSizes[0]);
            int colsCount = int.Parse(matrixSizes[1]);

            var intMatrix = new int[rowsCount, colsCount];

            for (int row = 0; row < intMatrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < intMatrix.GetLength(1); col++)
                {
                    intMatrix[row, col] = input[col];
                }
            }

            for (int i = 0; i < intMatrix.GetLength(1); i++)
            {
                int colSum = 0;

                for (int j = 0; j < intMatrix.GetLength(0); j++)
                {
                    colSum += intMatrix[j, i];
                }
                Console.WriteLine(colSum);
            }
        }
    }
}
