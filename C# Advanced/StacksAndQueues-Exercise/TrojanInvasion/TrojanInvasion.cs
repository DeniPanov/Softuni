namespace TrojanInvasion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TrojanInvasion
    {
        public static void Main()
        {
            int wavesCount = int.Parse(Console.ReadLine());
            var spartanInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var spartanDefeses = new Queue<int>(spartanInput);
            var trojanWarriors = new Stack<int>();

            for (int i = 1; i <= wavesCount; i++)
            {
                var trojanInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < trojanInput.Length; j++)
                {
                    trojanWarriors.Push(trojanInput[j]);
                }

                if (i % 3 == 0)
                {
                    int additionalSpartanDeffense = int.Parse(Console.ReadLine());
                    spartanDefeses.Enqueue(additionalSpartanDeffense);
                }

                while (spartanDefeses.Count != 0 && trojanWarriors.Count != 0)
                {
                    int currentWarrior = trojanWarriors.Peek();
                    int currentDeffense = spartanDefeses.Peek();

                    if (currentWarrior > currentDeffense)
                    {
                        currentWarrior -= currentDeffense;
                        spartanDefeses.Dequeue();
                        trojanWarriors.Pop();
                        trojanWarriors.Push(currentWarrior);
                    }

                    else if (currentWarrior < currentDeffense)
                    {
                        currentDeffense -= currentWarrior;
                        trojanWarriors.Pop();
                        spartanDefeses.Dequeue();
                        spartanDefeses.Enqueue(currentDeffense);

                        for (int j = 0; j < spartanDefeses.Count - 1; j++)
                        {
                            spartanDefeses.Enqueue(spartanDefeses.Dequeue());
                        }
                    }

                    else if (currentWarrior == currentDeffense)
                    {
                        trojanWarriors.Pop();
                        spartanDefeses.Dequeue();
                    }
                }

                if (spartanDefeses.Count == 0)
                {
                    break;
                }
            }

            if (spartanDefeses.Count == 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", trojanWarriors)}");
            }

            else if (trojanWarriors.Count == 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", spartanDefeses)}");
            }
        }
    }
}
