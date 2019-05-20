namespace P08_BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParentheses
    {
        public static void Main()
        {
            var stackOfParentheses = new Stack<char>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar == '(' || currentChar == '[' || currentChar == '{')
                {
                    stackOfParentheses.Push(currentChar);
                }

                if (currentChar == ')' || currentChar == ']' || currentChar == '}')
                {
                    if (stackOfParentheses.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    char matchingChar = stackOfParentheses.Peek();

                    if (currentChar == ')' && matchingChar== '(')
                    {
                        stackOfParentheses.Pop();
                    }
                    else if (currentChar == ']' && matchingChar == '[')
                    {
                        stackOfParentheses.Pop();
                    }
                    else if (currentChar == '}' && matchingChar == '{')
                    {
                        stackOfParentheses.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
