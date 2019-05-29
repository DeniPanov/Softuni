namespace P10_RadioactiveMutantVampireBunnies
{
    using System;

    public class RadioactiveMutantVampireBunnies
    {
        public static void Main()
        {
            var sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);

            var matrix = new char[rows][];

            int playerRow = 0;
            int playerCol = 0;

            FillsMatrix(cols, matrix, ref playerRow, ref playerCol);

            string commands = Console.ReadLine()?.ToUpper();
            bool playerDies = false;
            bool playerWins = false;

            for (int i = 0; i < commands.Length; i++)
            {
                char currentCommand = commands[i];

                bool isInside = false;
                isInside = IsItInside(matrix, isInside, playerRow, playerCol);

                if (currentCommand == 'U')
                {
                    matrix[playerRow][playerCol] = '.';

                    if (IsItInside(matrix, isInside, playerRow - 1, playerCol))
                    {
                        if (matrix[playerRow - 1][playerCol] == '.')
                        {
                            matrix[playerRow - 1][playerCol] = 'P';
                            playerRow--;
                        }
                        else if (matrix[playerRow - 1][playerCol] == 'B')
                        {
                            playerRow--;
                            playerDies = true;
                        }
                    }

                    else
                    {
                        playerWins = true;
                    }
                }

                else if (currentCommand == 'D')
                {
                    matrix[playerRow][playerCol] = '.';

                    if (IsItInside(matrix, isInside, playerRow + 1, playerCol))
                    {
                        if (matrix[playerRow + 1][playerCol] == '.')
                        {
                            matrix[playerRow + 1][playerCol] = 'P';
                            playerRow++;
                        }
                        else if (matrix[playerRow + 1][playerCol] == 'B')
                        {
                            playerRow++;
                            playerDies = true;
                        }
                    }

                    else
                    {
                        playerWins = true;
                    }
                }

                else if (currentCommand == 'L')
                {
                    matrix[playerRow][playerCol] = '.';

                    if (IsItInside(matrix, isInside, playerRow, playerCol - 1))
                    {
                        if (matrix[playerRow][playerCol - 1] == '.')
                        {
                            matrix[playerRow][playerCol - 1] = 'P';
                            playerCol--;
                        }
                        else if (matrix[playerRow][playerCol - 1] == 'B')
                        {
                            playerCol--;
                            playerDies = true;
                        }
                    }

                    else
                    {
                        playerWins = true;
                    }
                }

                else if (currentCommand == 'R')
                {
                    matrix[playerRow][playerCol] = '.';

                    if (IsItInside(matrix, isInside, playerRow, playerCol + 1))
                    {
                        if (matrix[playerRow][playerCol + 1] == '.')
                        {
                            matrix[playerRow][playerCol + 1] = 'P';
                            playerCol++;
                        }
                        else if (matrix[playerRow][playerCol + 1] == 'B')
                        {
                            playerCol++;
                            playerDies = true;
                        }
                    }
                    else
                    {
                        playerWins = true;
                    }
                }

                int bunnieRow = 0;
                int bunnieCol = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'B')
                        {
                            bunnieRow = row;
                            bunnieCol = col;

                            if (IsItInside(matrix, isInside, bunnieRow - 1, bunnieCol)) //up
                            {
                                if (matrix[bunnieRow - 1][bunnieCol] == '.')
                                {
                                    matrix[bunnieRow - 1][bunnieCol] = 'b';
                                }

                                else if (matrix[bunnieRow - 1][bunnieCol] == 'P')
                                {
                                    playerDies = true;
                                    matrix[bunnieRow - 1][bunnieCol] = 'b';
                                }
                            }

                            if (IsItInside(matrix, isInside, bunnieRow + 1, bunnieCol)) //down
                            {
                                if (matrix[bunnieRow + 1][bunnieCol] == '.')
                                {
                                    matrix[bunnieRow + 1][bunnieCol] = 'b';
                                }

                                else if (matrix[bunnieRow + 1][bunnieCol] == 'P')
                                {
                                    playerDies = true;
                                    matrix[bunnieRow + 1][bunnieCol] = 'b';
                                }
                            }

                            if (IsItInside(matrix, isInside, bunnieRow, bunnieCol - 1)) //left
                            {
                                if (matrix[bunnieRow][bunnieCol - 1] == '.')
                                {
                                    matrix[bunnieRow][bunnieCol - 1] = 'b';
                                }

                                else if (matrix[bunnieRow][bunnieCol - 1] == 'P')
                                {
                                    playerDies = true;
                                    matrix[bunnieRow][bunnieCol - 1] = 'b';
                                }
                            }

                            if (IsItInside(matrix, isInside, bunnieRow, bunnieCol + 1)) //right
                            {
                                if (matrix[bunnieRow][bunnieCol + 1] == '.')
                                {
                                    matrix[bunnieRow][bunnieCol + 1] = 'b';
                                }

                                else if (matrix[bunnieRow][bunnieCol + 1] == 'P')
                                {
                                    playerDies = true;
                                    matrix[bunnieRow][bunnieCol + 1] = 'b';
                                }
                            }
                        }
                    }
                }

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'b')
                        {
                            matrix[row][col] = 'B';
                        }
                    }
                }

                if (playerWins || playerDies)
                {
                    break;
                }
            }

            PrintsMatrix(matrix);

            if (playerWins)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }

            else if (playerDies)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }


        private static bool IsItInside(char[][] matrix, bool isItInside, int playerRow, int playerCol)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (playerRow < matrix.Length && playerRow >= 0
                 && playerCol < matrix[row].Length && playerCol >= 0)
                {
                    isItInside = true;
                }
                else
                {
                    isItInside = false;
                }
                // break;
            }

            return isItInside;
        }

        private static void PrintsMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
        private static void FillsMatrix(int cols, char[][] matrix, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
