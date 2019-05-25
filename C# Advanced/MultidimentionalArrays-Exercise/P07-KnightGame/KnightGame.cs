namespace P07_KnightGame
{
    using System;

    public class KnightGame
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            var matrix = new char[matrixSize][];

            FillMatrix(matrix, matrixSize);

            int maxKnightAtacks = -1;
            int maxRow = 0;
            int maxCol = 0;
            int removesKnights = 0;

            while (maxKnightAtacks != 0)
            {
                maxKnightAtacks = 0;
                maxRow = 0;
                maxCol = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        char currentPosition = matrix[row][col];
                        int counter = 0;

                        if (currentPosition == 'K')
                        {
                            bool moveTopLeft = false;
                            bool moveTopRight = false;
                            bool moveLeftTop = false;
                            bool moveLeftBottom = false;
                            bool moveBottomLeft = false;
                            bool moveBottomRight = false;
                            bool moveRightTop = false;
                            bool moveRightBottom = false;

                            moveTopLeft = MoveUpLeft(matrixSize, row, col, moveTopLeft);
                            moveTopRight = MoveUpRight(matrixSize, row, col, moveTopRight);
                            moveLeftTop = MoveLeftUp(matrixSize, row, col, moveLeftTop);
                            moveLeftBottom = MoveLeftDown(matrixSize, row, col, moveLeftBottom);
                            moveBottomLeft = MoveDownLeft(matrixSize, row, col, moveBottomLeft);
                            moveBottomRight = MoveDownRight(matrixSize, row, col, moveBottomRight);
                            moveRightTop = MoveRigtUp(matrixSize, row, col, moveRightTop);
                            moveRightBottom = MoveRightDown(matrixSize, row, col, moveRightBottom);

                            char positionToMove = '0';

                            if (MoveUpLeft(matrixSize, row, col, moveTopLeft))
                            {
                                positionToMove = matrix[row - 2][col - 1];

                                if (positionToMove == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (MoveUpRight(matrixSize, row, col, moveTopRight))
                            {
                                positionToMove = matrix[row - 2][col + 1];

                                if (positionToMove == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (MoveLeftUp(matrixSize, row, col, moveLeftTop))
                            {
                                positionToMove = matrix[row - 1][col - 2];

                                if (positionToMove == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (MoveLeftDown(matrixSize, row, col, moveLeftBottom))
                            {
                                positionToMove = matrix[row + 1][col - 2];

                                if (positionToMove == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (MoveDownLeft(matrixSize, row, col, moveBottomLeft))
                            {
                                positionToMove = matrix[row + 2][col - 1];

                                if (positionToMove == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (MoveDownRight(matrixSize, row, col, moveBottomRight))
                            {
                                positionToMove = matrix[row + 2][col + 1];

                                if (positionToMove == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (MoveRigtUp(matrixSize, row, col, moveRightTop))
                            {
                                positionToMove = matrix[row - 1][col + 2];

                                if (positionToMove == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (MoveRightDown(matrixSize, row, col, moveRightBottom))
                            {
                                positionToMove = matrix[row + 1][col + 2];

                                if (positionToMove == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (counter > maxKnightAtacks)
                            {
                                maxKnightAtacks = counter;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }

                matrix[maxRow][maxCol] = '0';

                if (maxKnightAtacks > 0)
                {
                    removesKnights++;
                }
            }

            //PrintsMatrix(matrix);
            Console.WriteLine(removesKnights);
        }

        private static bool MoveRightDown(int matrixSize, int row, int col, bool moveRightBottom)
        {
            if (row + 1 >= 0 && row + 1 < matrixSize && col + 2 >= 0 && col + 2 < matrixSize)
            {
                moveRightBottom = true;
            }
            else
            {
                moveRightBottom = false;
            }

            return moveRightBottom;
        }

        private static bool MoveRigtUp(int matrixSize, int row, int col, bool moveRightTop)
        {
            if (row - 1 >= 0 && row - 1 < matrixSize && col + 2 >= 0 && col + 2 < matrixSize)
            {
                moveRightTop = true;
            }
            else
            {
                moveRightTop = false;
            }

            return moveRightTop;
        }

        private static bool MoveDownRight(int matrixSize, int row, int col, bool moveBottomRight)
        {
            if (row + 2 >= 0 && row + 2 < matrixSize && col + 1 >= 0 && col + 1 < matrixSize)
            {
                moveBottomRight = true;
            }
            else
            {
                moveBottomRight = false;
            }

            return moveBottomRight;
        }

        private static bool MoveDownLeft(int matrixSize, int row, int col, bool moveBottomLeft)
        {
            if (row + 2 >= 0 && row + 2 < matrixSize && col - 1 >= 0 && col - 1 < matrixSize)
            {
                moveBottomLeft = true;
            }
            else
            {
                moveBottomLeft = false;
            }

            return moveBottomLeft;
        }

        private static bool MoveLeftDown(int matrixSize, int row, int col, bool moveLeftBottom)
        {
            if (row + 1 >= 0 && row + 1 < matrixSize && col - 2 >= 0 && col - 2 < matrixSize)
            {
                moveLeftBottom = true;
            }

            return moveLeftBottom;
        }

        private static bool MoveLeftUp(int matrixSize, int row, int col, bool moveLeftTop)
        {
            if (row - 1 >= 0 && row - 1 < matrixSize && col - 2 >= 0 && col - 2 < matrixSize)
            {
                moveLeftTop = true;
            }
            else
            {
                moveLeftTop = false;
            }

            return moveLeftTop;
        }

        private static bool MoveUpRight(int matrixSize, int row, int col, bool moveTopRight)
        {
            if (row - 2 >= 0 && row - 2 < matrixSize && col + 1 < matrixSize && col + 1 >= 0)
            {
                moveTopRight = true;
            }
            else
            {
                moveTopRight = false;
            }

            return moveTopRight;
        }

        private static bool MoveUpLeft(int matrixSize, int row, int col, bool moveTopLeft)
        {
            if (row - 2 >= 0 && row - 2 < matrixSize && col - 1 >= 0 && col - 1 < matrixSize)
            {
                moveTopLeft = true;
            }
            else
            {
                moveTopLeft = false;
            }

            return moveTopLeft;
        }

        private static void PrintsMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void FillMatrix(char[][] matrix, int matrixSize)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[matrixSize];
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
        }
    }
}
