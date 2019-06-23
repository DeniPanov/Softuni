namespace P03
{
    using System;
    public class StartUp
    {
        static char[][] matrix;

        static int playerRow = 0;
        static int playerCol = 0;

        static int blackHole1Row = 0;
        static int blackHole1Col = 0;

        static int blackHole2Row = 0;
        static int blackHole2Col = 0;

        public static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());

            matrix = new char[rowsCount][];
            int blackHolesCounter = 0;

            FillsMatrix(blackHolesCounter);

            string direction = Console.ReadLine();
            int collectedStars = 0;

            while (true)
            {
                matrix[playerRow][playerCol] = '-';

                if (direction == "up")
                {
                    playerRow--;

                    if (IsInside(playerRow, playerCol))
                    {
                        collectedStars = PlayerLandsOnField(collectedStars);
                    }

                    else
                    {
                        break;
                    }
                }

                else if (direction == "down")
                {
                    playerRow++;

                    if (IsInside(playerRow, playerCol))
                    {
                        collectedStars = PlayerLandsOnField(collectedStars);
                    }

                    else
                    {
                        break;
                    }
                }

                else if (direction == "left")
                {
                    playerCol--;

                    if (IsInside(playerRow, playerCol))
                    {
                        collectedStars = PlayerLandsOnField(collectedStars);
                    }

                    else
                    {
                        break;
                    }
                }

                else if (direction == "right")
                {
                    playerCol++;

                    if (IsInside(playerRow, playerCol))
                    {
                        collectedStars = PlayerLandsOnField(collectedStars);
                    }

                    else
                    {
                        break;
                    }

                }

                if (collectedStars >= 50)
                {
                    break;
                }

                direction = Console.ReadLine();
            }

            if (IsInside(playerRow, playerCol) == false)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }

            else if (collectedStars >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {collectedStars}");

            PrintsMatrix();
        }

        private static int PlayerLandsOnField(int collectedStars)
        {
            if (matrix[playerRow][playerCol] == '-')
            {
                matrix[playerRow][playerCol] = 'S';
            }

            else if (matrix[playerRow][playerCol] == 'O')
            {
                matrix[blackHole1Row][blackHole1Col] = '-';

                playerRow = blackHole2Row;
                playerCol = blackHole2Col;

                matrix[playerRow][playerCol] = 'S';
            }

            else
            {
                int currentPosition = int.Parse(matrix[playerRow][playerCol].ToString());
                collectedStars += currentPosition;
                matrix[playerRow][playerCol] = 'S';
            }

            return collectedStars;
        }

        private static bool IsInside(int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < matrix.Length
               && playerCol >= 0 && playerCol < matrix[playerRow].Length;
        }

        private static void PrintsMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void FillsMatrix(int blackHolesCounter)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = new char[input.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }


                    if (matrix[row][col] == 'O')
                    {
                        if (blackHolesCounter == 0)
                        {
                            blackHole1Row = row;
                            blackHole1Col = col;
                            blackHolesCounter++;
                        }

                        else
                        {
                            blackHole2Row = row;
                            blackHole2Col = col;
                        }
                    }
                }
            }
        }
    }
}
