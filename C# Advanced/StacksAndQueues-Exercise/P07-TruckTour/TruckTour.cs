namespace P07_TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var queue = new Queue<long[]>();

            for (int i = 0; i < n; i++)
            {
                var petrolAndDistance = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                //1 5
                queue.Enqueue(petrolAndDistance);
            }

            int smallestIndex = 0;
            long remainingPetrol = 0;

            while (true)
            {
                remainingPetrol = 0;

                foreach (var pump in queue)
                {
                    long petrolPerKm = pump[0];
                    long distance = pump[1];

                    remainingPetrol += petrolPerKm - distance;

                    if (remainingPetrol < 0)
                    {
                        smallestIndex++;

                        var currentPump = queue.Dequeue();
                        queue.Enqueue(currentPump);
                        break;
                    }
                }

                if (remainingPetrol >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(smallestIndex);
        }
    }
}
