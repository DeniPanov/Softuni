namespace P02_SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var numbersAndOperands = new Stack<string>(input.Reverse());
            //2, +, 5, +, 10, -, 2, -, 1

            while (numbersAndOperands.Count > 1)
            {
                int firstNumber = int.Parse(numbersAndOperands.Pop());
                char operand = char.Parse(numbersAndOperands.Pop());
                int secondNumber = int.Parse(numbersAndOperands.Pop());
                int result = 0;

                if (operand == '+')
                {
                    result = firstNumber + secondNumber;
                    numbersAndOperands.Push(result.ToString());
                }
                else if (operand == '-')
                {
                    result = firstNumber - secondNumber;
                    numbersAndOperands.Push(result.ToString());
                }
            }

            Console.WriteLine(numbersAndOperands.Pop());
        }
    }
}
