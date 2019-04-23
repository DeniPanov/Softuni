namespace P01_ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class ReverseStrings
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var reversedInput = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                reversedInput.Push(currentChar);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(reversedInput.Pop());
            }
            
        }
    }
}
