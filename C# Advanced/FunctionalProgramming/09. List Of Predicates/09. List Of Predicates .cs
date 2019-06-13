using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class ListOfPredicates
    {

        static void Main(string[] args)
        {
            int endRange = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split()
                .Distinct()
                .Select(int.Parse)
                .ToList();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            dividers.ForEach(d => predicates.Add(x => x % d == 0));
            List<int> result = new List<int>();

            for (int i = 1; i <= endRange; i++)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }


        //static void Main(string[] args)
        //{
        //    int number = int.Parse(Console.ReadLine());
        //    var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        //    var corectNumbers = new HashSet<int>();
        //    for (int i = 0; i < numbers.Count; i++)
        //    {
        //        for (int j = 1; j <= number; j++)
        //        {
        //            if (j%numbers[i]==0)
        //            {
        //                corectNumbers.Add(j);
        //            }
        //            else
        //            {
        //                if (corectNumbers.Contains(j))
        //                {
        //                    corectNumbers.Remove(j);
        //                }
        //            }
        //        }
        //    }
        //    foreach (var item in corectNumbers)
        //    {
        //        Console.Write(item+" ");
        //    }
        //}
    }
}
