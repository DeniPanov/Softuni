namespace P06_Supermarket
{
    using System;
    using System.Collections.Generic;

    public class Supermarket
    {
        public static void Main()
        {
            var customerNames = new Queue<string>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command != "Paid")
                {
                    customerNames.Enqueue(command);
                }
                else
                {
                    foreach (var customer in customerNames)
                    {
                        Console.WriteLine(customer);
                    }
                    customerNames.Clear();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{customerNames.Count} people remaining.");
        }
    }
}
