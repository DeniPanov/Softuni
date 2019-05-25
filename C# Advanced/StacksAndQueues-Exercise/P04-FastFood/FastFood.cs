namespace P04_FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FastFood
    {
        public static void Main()
        {
            int availableFood = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse);

            var ordersInQueue = new Queue<int>(orders);

            Console.WriteLine(ordersInQueue.Max());

            for (int i = 0; i < orders.Count(); i++)
            {
                int currentOrder = ordersInQueue.Peek();

                if (availableFood >= currentOrder)
                {
                    availableFood -= currentOrder;
                    ordersInQueue.Dequeue();
                }
                else
                {
                    continue;
                }
            }

            if (ordersInQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ",ordersInQueue)}");
            }
        }
    }
}
