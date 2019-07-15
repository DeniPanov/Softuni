namespace P05_BombNumbers
{
    using System;
    using System.Linq;

    public class BombNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var command = Console.ReadLine().Split().Select(int.Parse).ToList();
            int bomb = command[0];
            int bombPower = command[1];
            int originalLenght = numbers.Count;
            int counter = 0;
            int newBomb = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (bomb == numbers[i])
                {
                    while (counter != (bombPower * 2) + 1)
                    {
                        if (numbers[i - bombPower] >= 0)
                        {
                             numbers.RemoveAt(i - bombPower);
                        }
                        else
                        {
                            numbers.RemoveAt(numbers[0]);
                        }
                        newBomb = 0;
                        counter++;
                    }
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
