namespace P02_ChangeList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            CommandsManipulatingList();
        }
        public static void CommandsManipulatingList()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = string.Empty;

            while (true)
            {
                command = Console.ReadLine();
                if (command == "end")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    return;
                }

                var text = command.Split().ToList();
                int textAsNumber = 0;
                int lastElement = 0;

                if (text[0] == "Delete")
                {
                    textAsNumber = int.Parse(text[1]);
                    numbers.RemoveAll(x => x == textAsNumber);
                }
                else
                {
                    textAsNumber = int.Parse(text[1]);
                    lastElement = int.Parse(text[2]);
                    numbers.Insert(lastElement, textAsNumber);
                }
            }

        }
    }
}
