namespace P06_EqualSums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
             List <int> numbers= Console.ReadLine().Split().Select(int.Parse).ToList();
            int leftSum = 0;
            int rightSum = numbers.Sum();
            int counter = 0;

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                rightSum -= numbers[i];

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    counter++;
                }

                leftSum += numbers[i];
            }
            if (counter == 0)
            {
                Console.WriteLine("no");
            }
        }
    }
}
