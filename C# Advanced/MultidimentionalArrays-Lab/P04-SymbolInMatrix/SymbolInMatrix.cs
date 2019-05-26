namespace P04_SymbolInMatrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int squareSize = int.Parse(Console.ReadLine());
            var charMatrix = new char[squareSize, squareSize];

            for (int r = 0; r < charMatrix.GetLength(0); r++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int c = 0; c < charMatrix.GetLength(1); c++)
                {
                    charMatrix[r, c] = input[c];
                }
            }

            char neededChar = char.Parse(Console.ReadLine());

            for (int r = 0; r < charMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < charMatrix.GetLength(1); c++)
                {
                    char currentChar = charMatrix[r, c];

                    if (currentChar == neededChar)
                    {
                        int currentRow = r;
                        int currentCol = c;

                        Console.WriteLine($"({currentRow}, {currentCol})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{neededChar} does not occur in the matrix");
        }
    }
}
