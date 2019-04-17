namespace P02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EasterGifts
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().ToList();
            string commandLine = Console.ReadLine();

            var presentsList = new List<string>();

            while (commandLine != "No Money")
            {
                var tokens = commandLine.Split();
                //OutOfStock Eggs

                string command = tokens[0];

                if (command== "OutOfStock")
                {
                    //OutOfStock Eggs
                    string gift = tokens[1];

                    while (input.Contains(gift))
                    {
                        int index = input.IndexOf(gift);
                        input.Insert(index, "None");
                        input.RemoveAt(index + 1);
                    }
                }
                else if (command == "Required")
                {
                    //Required Spoon 2
                    string gift = tokens[1];
                    int index = int.Parse(tokens[2]);

                    if (index >= 0 && index < input.Count)
                    {
                        input.Insert(index, gift);
                        input.RemoveAt(index + 1);
                    }
                }
                else if (command == "JustInCase")
                {
                    //JustInCase ChocolateEgg
                    string gift = tokens[1];

                    input.Add(gift);
                    input.RemoveAt(input.Count - 2);
                }

                commandLine = Console.ReadLine();
            }

            while (input.Contains("None"))
            {
                input.Remove("None");
            }

            Console.WriteLine(string.Join(" ",input));
        }
    }
}
