namespace P02_BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main()
        {
            var initialInput = Console.ReadLine().Split();
            //5 2 32

            int elementsToRemove = int.Parse(initialInput[1]);
            int elementToFind = int.Parse(initialInput[2]);

            var currentInput = Console.ReadLine().Split().Select(int.Parse);
            var numbers = new Queue<int>(currentInput);

            for (int i = 0; i < elementsToRemove; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (numbers.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}
