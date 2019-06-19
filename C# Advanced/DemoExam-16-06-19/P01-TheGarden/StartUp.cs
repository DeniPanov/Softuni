namespace P03
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());

            var matrix = new char[rowsCount][];

            FillMatrix(rowsCount, matrix);

            string command = Console.ReadLine();

            int harmedVegetables = 0;
            int cCounter = 0;
            int lCounter = 0;
            int pCounter = 0;

            while (command != "End of Harvest")
            {
                var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];

                if (action == "Harvest")
                {
                    int targetRow = int.Parse(tokens[1]);
                    int targetCol = int.Parse(tokens[2]);

                    if (IsValid(matrix, targetRow, targetCol))
                    {
                        if (matrix[targetRow][targetCol] == ' ')
                        {
                            command = Console.ReadLine();
                            continue;
                        }

                        else if (matrix[targetRow][targetCol] == 'C')
                        {
                            matrix[targetRow][targetCol] = ' ';
                            cCounter++;
                        }

                        else if (matrix[targetRow][targetCol] == 'L')
                        {
                            matrix[targetRow][targetCol] = ' ';
                            lCounter++;
                        }

                        else if (matrix[targetRow][targetCol] == 'P')
                        {
                            matrix[targetRow][targetCol] = ' ';
                            pCounter++;
                        }
                    }
                }

                else if (action == "Mole")
                {
                    int targetRow = int.Parse(tokens[1]);
                    int targetCol = int.Parse(tokens[2]);
                    string direction = tokens[3].ToLower();

                    if (IsValid(matrix, targetRow, targetCol))
                    {
                        if (direction == "up")
                        {
                            if (matrix[targetRow][targetCol] == 'C' ||
                                matrix[targetRow][targetCol] == 'P' ||
                                matrix[targetRow][targetCol] == 'L')
                            {
                                matrix[targetRow][targetCol] = ' ';
                                harmedVegetables++;
                            }

                            while (IsValid(matrix, targetRow -= 2, targetCol))
                            {
                                harmedVegetables = MoleHarmsVegetable(matrix, harmedVegetables, targetRow, targetCol);
                            }
                        }

                        else if (direction == "down")
                        {
                            if (matrix[targetRow][targetCol] == 'C' ||
                                matrix[targetRow][targetCol] == 'P' ||
                                matrix[targetRow][targetCol] == 'L')
                            {
                                matrix[targetRow][targetCol] = ' ';
                                harmedVegetables++;
                            }

                            while (IsValid(matrix, targetRow += 2, targetCol))
                            {
                                harmedVegetables = MoleHarmsVegetable(matrix, harmedVegetables, targetRow, targetCol);
                            }
                        }

                        else if (direction == "left")
                        {
                            if (matrix[targetRow][targetCol] == 'C' ||
                                matrix[targetRow][targetCol] == 'P' ||
                                matrix[targetRow][targetCol] == 'L')
                            {
                                matrix[targetRow][targetCol] = ' ';
                                harmedVegetables++;
                            }

                            while (IsValid(matrix, targetRow, targetCol -= 2))
                            {
                                harmedVegetables = MoleHarmsVegetable(matrix, harmedVegetables, targetRow, targetCol);
                            }
                        }

                        else if (direction == "right")
                        {
                            if (matrix[targetRow][targetCol] == 'C' ||
                                matrix[targetRow][targetCol] == 'P' ||
                                matrix[targetRow][targetCol] == 'L')
                            {
                                matrix[targetRow][targetCol] = ' ';
                                harmedVegetables++;
                            }

                            while (IsValid(matrix, targetRow, targetCol += 2))
                            {
                                harmedVegetables = MoleHarmsVegetable(matrix, harmedVegetables, targetRow, targetCol);
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }

            Console.WriteLine($" Carrots: {cCounter}");
            Console.WriteLine($" Potatoes: {pCounter}");
            Console.WriteLine($" Lettuce: {lCounter}");
            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }

        private static int MoleHarmsVegetable(char[][] matrix, int harmedVegetables, int targetRow, int targetCol)
        {
            if (matrix[targetRow][targetCol] == 'C'
             || matrix[targetRow][targetCol] == 'L'
             || matrix[targetRow][targetCol] == 'P')
            {
                matrix[targetRow][targetCol] = ' ';
                harmedVegetables++;
            }

            return harmedVegetables;
        }

        private static bool IsValid(char[][] matrix, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < matrix.Length
                && targetCol >= 0 && targetCol < matrix[targetRow].Length;
        }

        private static void FillMatrix(int rowsCount, char[][] matrix)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                matrix[row] = new char[input.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
        }
    }
}