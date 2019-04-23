namespace P05_PrintEvenNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PrintEvenNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse);
            var numbersFormInput = new Queue<int>(input);
            var numbersToPrint = new Queue<int>();

            while (numbersFormInput.Count > 0)
            {
                int num = numbersFormInput.Peek();

                if (num % 2 != 0)
                {
                    numbersFormInput.Dequeue();
                }
                else
                {
                    numbersToPrint.Enqueue(num);
                    numbersFormInput.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", numbersToPrint));
        }
    }
}
