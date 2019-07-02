namespace P06_Sneaking
{
    using System;
    public class Startup
    {
        public static char[][] room;

        public static int samRow = 0;
        public static int samCol = 0;

        static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());

            room = new char[rowsCount][];

            FillsMatrix(rowsCount);

            char[] moves = Console.ReadLine().ToCharArray(); 

            for (int i = 0; i < moves.Length; i++)
            {
                EnemyMoves();

                int enemyRow = 0;
                int enemyCol = 0;

                CheckIfEnemyGetsSam(ref enemyRow, ref enemyCol);

                ChecksIfSamDies(enemyRow, enemyCol);

                room[samRow][samCol] = '.';

                SamMoves(moves, i);

                room[samRow][samCol] = 'S';

                CheckIfEnemyGetsSam(ref enemyRow, ref enemyCol);

                CheckIfSamWins(enemyRow, enemyCol);
            }
        }

        private static void EnemyMoves()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    col = EnemyGoesLeftOrRight(row, col);
                }
            }
        }

        private static void CheckIfEnemyGetsSam(ref int enemyRow, ref int enemyCol)
        {
            for (int col = 0; col < room[samRow].Length; col++)
            {
                if (room[samRow][col] != '.' && room[samRow][col] != 'S')
                {
                    enemyRow = samRow;
                    enemyCol = col;
                }
            }
        }

        private static void CheckIfSamWins(int enemyRow, int enemyCol)
        {
            if (room[enemyRow][enemyCol] == 'N' && samRow == enemyRow)
            {
                room[enemyRow][enemyCol] = 'X';
                Console.WriteLine("Nikoladze killed!");

                PrintMatrix();

                Environment.Exit(0);
            }
        }

        private static void SamMoves(char[] moves, int i)
        {
            switch (moves[i])
            {
                case 'U':
                    samRow--;
                    break;
                case 'D':
                    samRow++;
                    break;
                case 'L':
                    samCol--;
                    break;
                case 'R':
                    samCol++;
                    break;
                default:
                    break;
            }
        }

        private static void ChecksIfSamDies(int enemyRow, int enemyCol)
        {
            if (samCol < enemyCol && room[enemyRow][enemyCol] == 'd' && enemyRow == samRow)
            {
                SamDied();

                PrintMatrix();

                Environment.Exit(0);
            }

            else if (enemyCol < samCol && room[enemyRow][enemyCol] == 'b' && enemyRow == samRow)
            {
                SamDied();

                PrintMatrix();

                Environment.Exit(0);
            }
        }

        private static void SamDied()
        {
            room[samRow][samCol] = 'X';
            Console.WriteLine($"Sam died at {samRow}, {samCol}");
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static int EnemyGoesLeftOrRight(int row, int col)
        {
            if (room[row][col] == 'b')
            {
                if (IsInside(row, col + 1))
                {
                    room[row][col] = '.';
                    room[row][col + 1] = 'b';
                    col++;
                }

                else
                {
                    room[row][col] = 'd';
                }
            }

            else if (room[row][col] == 'd')
            {
                if (IsInside(row, col - 1))
                {
                    room[row][col] = '.';
                    room[row][col - 1] = 'd';
                }

                else
                {
                    room[row][col] = 'b';
                }
            }

            return col;
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < room.Length && col >= 0 && col < room[row].Length;
        }

        private static void FillsMatrix(int rowsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();

                room[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];

                    if (room[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                }
            }
        }
    }
}
