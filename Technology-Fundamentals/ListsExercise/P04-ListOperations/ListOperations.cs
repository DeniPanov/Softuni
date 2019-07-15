namespace P04_ListOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static List <int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        public static string command = string.Empty;

        public static void Main()
        {
            
            while (true)
            {
                command = Console.ReadLine();
                var listOfCommands = command.Split().ToList();
                int textAsNumber = 0;
                AddOrRemoveNumbers(string command, int value);

                if (listOfCommands[0] == "End")
                {
                    Console.WriteLine(string.Join(" ",numbers));
                    return;
                }
                 
                else if (listOfCommands[0] == "Add")
                {
                    textAsNumber = int.Parse(listOfCommands[1]);
                    numbers.Add(textAsNumber);
                }
            }
        }

        private static void AddOrRemoveNumbers(string command, int value)
        {
            var listOfCommands = command.Split().ToList();
            int textAsNumber = 0;

           
            if (listOfCommands[0] == "Add")
            {
                textAsNumber = int.Parse(listOfCommands[1]);
                numbers.Add(textAsNumber);
            }


        }
    }
}
