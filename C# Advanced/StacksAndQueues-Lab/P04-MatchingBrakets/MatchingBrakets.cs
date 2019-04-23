namespace P04_MatchingBrakets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrakets
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            //1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5

            var bracketMatcher = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar == '(')
                {
                    bracketMatcher.Push(i);
                }
                else if (currentChar == ')')
                {
                    int openingIndex = bracketMatcher.Pop();
                    int closingIndex = i;

                    string subExpressionToPrint = input.Substring(openingIndex, closingIndex - openingIndex + 1);
                    Console.WriteLine(subExpressionToPrint);
                }
            }
        }
    }
}
