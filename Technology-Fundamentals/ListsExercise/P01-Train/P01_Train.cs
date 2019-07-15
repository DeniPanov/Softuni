namespace P01_Train
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxPassengers = int.Parse(Console.ReadLine());
            string command = string.Empty;

            while (true)
            {
                command = Console.ReadLine();
                var text = new List<string>();
                if (command == "end")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    return;
                }

                text = command.Split().ToList();
                int textAsNumber = 0;
                string firstElementOfList = string.Empty;

                for (int i = 0; i < text.Count; i++)
                {
                    if (text[0] == "Add")
                    {
                        textAsNumber = int.Parse(text[1]);
                        numbers.Add(textAsNumber);
                        break;
                    }
                    else if (text[0] != "Add")
                    {
                        textAsNumber = int.Parse(text[0]);
                        for (int j = 0; j < numbers.Count; j++)
                        {
                            if (textAsNumber + numbers[j] <= maxPassengers)
                            {
                                numbers[j] += textAsNumber;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
