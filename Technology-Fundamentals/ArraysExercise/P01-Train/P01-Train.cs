namespace P01_Train
{
    using System;
    using System.Linq;

    public class P01_Train
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine(numbers.Sum());
        }
    }
}
