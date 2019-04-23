namespace P07_HotPotato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            int tossesCount = int.Parse(Console.ReadLine());

            var kids = new Queue<string>(input);

            while (kids.Count > 1)
            {
                for (int i = 1; i < tossesCount; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }
                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
