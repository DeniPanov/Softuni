namespace P01_ActionPoint
{
    using System;
    using System.Linq;

    public class ActionPoint
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            Action<string[]> printNames = n => Console.WriteLine(string.Join(Environment.NewLine, n));

            printNames(input);
        }
    }
}
