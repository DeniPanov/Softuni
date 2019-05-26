namespace Helen_sAbduction
{
    using System;

    public class Helen_sAbduction
    {
        static int helenRow = 0;
        static int helenCol = 0;
        static int parisRow = 0;
        static int parisCol = 0;
        public static void Main()
        {
            int energy = int.Parse(Console.ReadLine());
            int matrixRows = int.Parse(Console.ReadLine());

            var matrix = new char[matrixRows][];

            FillsMatrix(matrix, matrixRows);

            while (true)
            {
                var command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var direction = command[0];
                int spartanRow = int.Parse(command[1]);
                int spartanCol = int.Parse(command[2]);
                bool isInside = false;

                isInside = IsInside(matrixRows, matrix, spartanRow, spartanCol, isInside);

                energy--;
                matrix[spartanRow][spartanCol] = 'S';

                if (direction == "up"?.ToLower() && IsInside(matrixRows, matrix, parisRow - 1, parisCol, isInside))
                {
                    if (matrix[parisRow - 1][parisCol] == '-')
                    {
                        ParisMovesUp(energy, matrix);

                        if (energy <= 0)
                        {
                            ParisDies(matrix);
                            PrintsMatrix(matrix);
                            return;
                        }
                    }

                    else if (matrix[parisRow - 1][parisCol] == 'S')
                    {
                        energy -= 2;
                        ParisMovesUp(energy, matrix);

                        if (energy <= 0)
                        {
                            ParisDies(matrix);
                            PrintsMatrix(matrix);
                            return;
                        }
                    }
                    else if (matrix[parisRow - 1][parisCol] == 'H')
                    {
                        HelenIsAbducted(energy, matrix);
                        return;
                    }
                }
                else if (direction == "down"?.ToLower() && IsInside(matrixRows, matrix, parisRow + 1, parisCol, isInside))
                {
                    if (matrix[parisRow + 1][parisCol] == '-')
                    {
                        ParisMovesDown(energy, matrix);

                        if (energy <= 0)
                        {
                            ParisDies(matrix);
                            PrintsMatrix(matrix);
                            return;
                        }
                    }

                    else if (matrix[parisRow + 1][parisCol] == 'S')
                    {
                        energy -= 2;
                        ParisMovesDown(energy, matrix);

                        if (energy <= 0)
                        {
                            ParisDies(matrix);
                            PrintsMatrix(matrix);
                            return;
                        }
                    }
                    else if (matrix[parisRow + 1][parisCol] == 'H')
                    {
                        HelenIsAbducted(energy, matrix);
                        return;
                    }
                }

                else if (direction == "left"?.ToLower() && IsInside(matrixRows, matrix, parisRow, parisCol - 1, isInside))
                {
                    if (matrix[parisRow][parisCol - 1] == '-')
                    {
                        ParisMovesLeft(energy, matrix);

                        if (energy <= 0)
                        {
                            ParisDies(matrix);
                            PrintsMatrix(matrix);
                            return;
                        }
                    }

                    else if (matrix[parisRow][parisCol - 1] == 'S')
                    {
                        energy -= 2;
                        ParisMovesLeft(energy, matrix);

                        if (energy <= 0)
                        {
                            ParisDies(matrix);
                            PrintsMatrix(matrix);
                            return;
                        }
                    }
                    else if (matrix[parisRow][parisCol - 1] == 'H')
                    {
                        HelenIsAbducted(energy, matrix);
                        return;
                    }
                }
                else if (direction == "right"?.ToLower() && IsInside(matrixRows, matrix, parisRow, parisCol + 1, isInside))
                {
                    if (matrix[parisRow][parisCol + 1] == '-')
                    {
                        ParisMovesRight(energy, matrix);

                        if (energy <= 0)
                        {
                            ParisDies(matrix);
                            PrintsMatrix(matrix);
                            return;
                        }
                    }

                    else if (matrix[parisRow][parisCol + 1] == 'S')
                    {
                        energy -= 2;
                        ParisMovesRight(energy, matrix);

                        if (energy <= 0)
                        {
                            ParisDies(matrix);
                            PrintsMatrix(matrix);
                            return;
                        }
                    }
                    else if (matrix[parisRow][parisCol + 1] == 'H')
                    {
                        HelenIsAbducted(energy, matrix);
                        return;
                    }
                }
            }
        }

        private static void HelenIsAbducted(int energy, char[][] matrix)
        {
            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
            matrix[parisRow][parisCol] = '-';
            matrix[helenRow][helenCol] = '-';
            PrintsMatrix(matrix);
        }

        private static void ParisMovesUp(int energy, char[][] matrix)
        {
            matrix[parisRow][parisCol] = '-';
            matrix[parisRow - 1][parisCol] = 'P';
            parisRow--;
        }
        private static void ParisMovesDown(int energy, char[][] matrix)
        {
            matrix[parisRow][parisCol] = '-';
            matrix[parisRow + 1][parisCol] = 'P';
            parisRow++;
        }

        private static void ParisMovesLeft(int energy, char[][] matrix)
        {
            matrix[parisRow][parisCol] = '-';
            matrix[parisRow][parisCol - 1] = 'P';
            parisCol--;
        }

        private static void ParisMovesRight(int energy, char[][] matrix)
        {
            matrix[parisRow][parisCol] = '-';
            matrix[parisRow][parisCol + 1] = 'P';
            parisCol++;
        }
        private static void ParisDies(char[][] matrix)
        {
            matrix[parisRow][parisCol] = 'X';
            Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
        }

        private static bool IsInside(int matrixRows, char[][] matrix, int spartanRow, int spartanCol, bool isInside)
        {
            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    isInside = spartanRow < matrixRows && spartanRow >= 0
                       && spartanCol < matrix[row].Length && spartanCol >= 0;
                    break;
                }
            }

            return isInside;
        }

        private static void PrintsMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void FillsMatrix(char[][] matrix, int matrixSize)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                var input = Console.ReadLine();
                matrix[row] = new char[input.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col] == 'H')
                    {
                        helenRow = row;
                        helenCol = col;
                    }

                    if (matrix[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }
        }
    }
}