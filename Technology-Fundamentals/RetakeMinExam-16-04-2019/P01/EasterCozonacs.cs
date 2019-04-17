namespace P01
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            double floorPricePerKg = double.Parse(Console.ReadLine());

            double eggsPrice = floorPricePerKg * 0.75;
            double milkPerLiterPrice = floorPricePerKg * 1.25;
            double milkPerCozonac = milkPerLiterPrice * 0.25;

            double totalProductsNeeded = floorPricePerKg + eggsPrice + milkPerCozonac;

            //int index = 0;
            int cozonacsCount = 0;
            int coloredEggs = 0;

            while (budget >= 0)
            {
                if (budget >= totalProductsNeeded)
                {
                    budget -= totalProductsNeeded;
                    cozonacsCount++;
                    coloredEggs += 3;

                    if (cozonacsCount % 3 == 0)
                    {
                        int colorEggsLoss = cozonacsCount - 2;
                        coloredEggs -= colorEggsLoss;
                    }
                }
                else
                {
                    break;
                }

                //index++;
            }

            Console.WriteLine($"You made {cozonacsCount} cozonacs!" +
                $" Now you have {coloredEggs} eggs and {budget:f2}BGN left.");
        }
    }
}
