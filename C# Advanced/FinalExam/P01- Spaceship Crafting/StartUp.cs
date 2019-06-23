namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var liquidsInput = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var liquids = new Queue<int>(liquidsInput);

            var physicalMaterialsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var physicalMaterials = new Stack<int>(physicalMaterialsInput);

            var advancedMaterials = new Queue<string>();

            while (liquids.Count > 0 && physicalMaterials.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentMaterial = physicalMaterials.Peek();

                if (currentLiquid + currentMaterial == 25)
                {
                    advancedMaterials.Enqueue("Glass");
                    physicalMaterials.Pop();

                }

                else if (currentLiquid + currentMaterial == 50)
                {
                    advancedMaterials.Enqueue("Aluminium");
                    physicalMaterials.Pop();

                }

                else if (currentLiquid + currentMaterial == 75)
                {
                    advancedMaterials.Enqueue("Lithium");
                    physicalMaterials.Pop();

                }

                else if (currentLiquid + currentMaterial == 100)
                {
                    advancedMaterials.Enqueue("Carbon fiber");
                    physicalMaterials.Pop();

                }

                else
                {
                    currentMaterial += 3;
                    physicalMaterials.Pop();
                    physicalMaterials.Push(currentMaterial);
                }
            }

            if (advancedMaterials.Contains("Glass") && advancedMaterials.Contains("Aluminium")
                && advancedMaterials.Contains("Lithium") && advancedMaterials.Contains("Carbon fiber"))
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }

            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count <= 0)
            {
                Console.WriteLine("Liquids left: none");
            }

            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }

            if (physicalMaterials.Count <= 0)
            {
                Console.WriteLine("Physical items left: none");
            }

            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", physicalMaterials)}");
            }

            int glassCounter = 0;
            int aluminiumCounter = 0;
            int lithiumCounter = 0;
            int carbonFiberCounter = 0;

            foreach (var material in advancedMaterials)
            {
                if (material == "Glass")
                {
                    glassCounter++;
                }

                else if (material == "Aluminium")
                {
                    aluminiumCounter++;
                }

                else if (material == "Lithium")
                {
                    lithiumCounter++;
                }

                else if (material == "Carbon fiber")
                {
                    carbonFiberCounter++;
                }
            }

            Console.WriteLine($"Aluminium: {aluminiumCounter}");
            Console.WriteLine($"Carbon fiber: {carbonFiberCounter}");
            Console.WriteLine($"Glass: {glassCounter}");
            Console.WriteLine($"Lithium: {lithiumCounter}");
        }
    }
}
