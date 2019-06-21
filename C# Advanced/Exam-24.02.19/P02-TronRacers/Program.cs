namespace P02_TronRacers
{
    using System;

    public class Program
    {
        static char[][] matrix;

        static int firstPlayerRow = 0;
        static int firstPlayerCol = 0;

        static int secondPlayerRow = 0;
        static int secondPlayerCol = 0;

        public static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            matrix = new char[rowsCount][];

            FillsMatrix(rowsCount);

            while (true)
            {
                string[] directions = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstPlayerDirection = directions[0];
                string secondPlayerDirection = directions[1];

                FirstPlayerMoves(firstPlayerDirection);

                bool won = false;

                won = FirstPlayerLandsOnField(won);

                if (won)
                {
                    break;
                }

                SecondPlayerMoves(secondPlayerDirection);

                won = SecondPlayerLandsOnField(won);

                if (won)
                {
                    break;
                }
            }

            PrintsMatrix();
        }

        private static bool SecondPlayerLandsOnField(bool won)
        {
            if (matrix[secondPlayerRow][secondPlayerCol] == '*')
            {
                matrix[secondPlayerRow][secondPlayerCol] = 's';
            }

            else if (matrix[secondPlayerRow][secondPlayerCol] == 'f')
            {
                matrix[secondPlayerRow][secondPlayerCol] = 'x';
                won = true;
            }

            return won;
        }

        private static bool FirstPlayerLandsOnField(bool won)
        {
            if (matrix[firstPlayerRow][firstPlayerCol] == '*')
            {
                matrix[firstPlayerRow][firstPlayerCol] = 'f';
            }

            else if (matrix[firstPlayerRow][firstPlayerCol] == 's')
            {
                matrix[firstPlayerRow][firstPlayerCol] = 'x';
                won = true;
            }

            return won;
        }

        private static void SecondPlayerMoves(string secondPlayerDirection)
        {
            if (secondPlayerDirection == "up")
            {
                secondPlayerRow--;

                if (secondPlayerRow < 0)
                {
                    secondPlayerRow = matrix.Length - 1;
                }
            }

            else if (secondPlayerDirection == "down")
            {
                secondPlayerRow++;

                if (secondPlayerRow >= matrix.Length)
                {
                    secondPlayerRow = 0;
                }
            }

            else if (secondPlayerDirection == "left")
            {
                secondPlayerCol--;

                if (secondPlayerCol < 0)
                {
                    secondPlayerCol = matrix.Length - 1;
                }
            }

            else if (secondPlayerDirection == "right")
            {
                secondPlayerCol++;

                if (secondPlayerCol >= matrix[firstPlayerRow].Length)
                {
                    secondPlayerCol = 0;
                }
            }
        }

        private static void FirstPlayerMoves(string firstPlayerDirection)
        {
            if (firstPlayerDirection == "up")
            {
                firstPlayerRow--;

                if (firstPlayerRow < 0)
                {
                    firstPlayerRow = matrix.Length - 1;
                }
            }

            else if (firstPlayerDirection == "down")
            {
                firstPlayerRow++;

                if (firstPlayerRow >= matrix.Length)
                {
                    firstPlayerRow = 0;
                }
            }

            else if (firstPlayerDirection == "left")
            {
                firstPlayerCol--;

                if (firstPlayerCol < 0)
                {
                    firstPlayerCol = matrix.Length - 1;
                }
            }

            else if (firstPlayerDirection == "right")
            {
                firstPlayerCol++;

                if (firstPlayerCol >= matrix[firstPlayerRow].Length)
                {
                    firstPlayerCol = 0;
                }
            }
        }

        private static void PrintsMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void FillsMatrix(int rowsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = new char[input.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col]== 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }

                    else if (matrix[row][col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }
        }
    }
}
