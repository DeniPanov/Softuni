
namespace P03_PrimaryDiagonal
{
    using System;
    using System.Linq;

    public class PrimaryDiagonal
    {
        public static void Main()
        {
            int squareSize = int.Parse(Console.ReadLine());

            var matrix = new int[squareSize, squareSize];
            int diagonalSum = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];
                }
            }

            int counter = 0;

            while (counter < squareSize)
            {
                diagonalSum += matrix[counter, counter];
                counter++;
            }

            Console.WriteLine(diagonalSum);
        }
    }
}
