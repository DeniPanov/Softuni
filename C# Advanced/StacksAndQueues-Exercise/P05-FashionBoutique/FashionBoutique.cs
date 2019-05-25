namespace P05_FashionBoutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FashionBoutique
    {
        public static void Main()
        {
            var clothes = Console.ReadLine().Split().Select(int.Parse);
            int rackCapacity = int.Parse(Console.ReadLine());

            var stackOfClothes = new Stack<int>(clothes);
            int racksNeeded = 0;
            int currentSum = 0;

            while (stackOfClothes.Count > 0) 
            {
                int currentCloth = stackOfClothes.Pop();
                currentSum += currentCloth;

                if (rackCapacity > currentSum)
                {
                    if (stackOfClothes.Count == 1)
                    {
                        racksNeeded++;
                    }
                    continue;
                }
                else if (rackCapacity == currentSum)
                {
                    if (stackOfClothes.Count > 0)
                    {
                        currentSum = 0;
                        racksNeeded++;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    currentSum = 0;
                    stackOfClothes.Push(currentCloth); //the last line you added.
                    racksNeeded++;
                }
            }

            Console.WriteLine(racksNeeded);
        }
    }
}
