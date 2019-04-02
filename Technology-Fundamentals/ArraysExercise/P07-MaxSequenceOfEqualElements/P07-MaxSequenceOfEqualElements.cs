namespace P07_MaxSequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxLenght = 0;
            int currentMaxNumber = 0;
            int temporaryMaxLenght = 1;
            int temporaryCounter = 0;


            for (int i = 0; i < numbers.Count - 1; i++)
            {

                if (numbers[i] == numbers[i + 1])
                {
                    temporaryMaxLenght++;
                    temporaryCounter = numbers[i];
                }
                else
                {
                    temporaryMaxLenght = 1;
                }

                if (temporaryMaxLenght > maxLenght)
                {
                    maxLenght = temporaryMaxLenght;
                    currentMaxNumber = temporaryCounter;
                }

            }
            for (int i = 0; i < maxLenght; i++)
            {
                Console.Write(currentMaxNumber + " ");
            }
            Console.WriteLine();
        }
    }
}
