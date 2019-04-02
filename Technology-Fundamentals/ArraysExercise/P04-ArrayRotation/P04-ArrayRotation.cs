namespace ArrayRotation
{
    using System;
    using System.Linq;

    class ArrayRotation
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotation = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotation; i++)
            {
                int firstElement = numbers[0];

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }
                numbers[numbers.Length - 1] = firstElement;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
