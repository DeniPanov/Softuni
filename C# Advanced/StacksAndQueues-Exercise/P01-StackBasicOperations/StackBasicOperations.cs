namespace P01_BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            var initialInput = Console.ReadLine().Split();
            //5 2 13

            int numbersToPop = int.Parse(initialInput[1]);
            int elementToFind = int.Parse(initialInput[2]);

            var currentInput = Console.ReadLine().Split().Select(int.Parse);
            //1 13 45 32 4

            var stack = new Stack<int>(currentInput);
            //1 13 45 32 4

            for (int i = 0; i < numbersToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (stack.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
