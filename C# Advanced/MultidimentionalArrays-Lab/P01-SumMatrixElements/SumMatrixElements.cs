namespace SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine().Split(", ");
            //3, 6

            int rowsCount = int.Parse(matrixSizes[0]);
            int columnsCount = int.Parse(matrixSizes[1]);

            var intMatrix = new int[rowsCount,columnsCount];

            for (int r = 0; r < intMatrix.GetLength(0); r++)
            {
                var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                //7, 1, 3, 3, 2, 1

                for (int c = 0; c < intMatrix.GetLength(1); c++)
                {
                    intMatrix[r, c] = input[c];
                }
                //Console.WriteLine();
            }

            int matrixSum = 0;

            foreach (var element in intMatrix)
            {
                matrixSum += element;
            }

            Console.WriteLine(intMatrix.GetLength(0));
            Console.WriteLine(intMatrix.GetLength(1));
            Console.WriteLine(matrixSum);

        }
    }
}
