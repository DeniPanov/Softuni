using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class FindEvensorOdds
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var first = input[0];
            var last = input[1];
            var command = Console.ReadLine();
            if (command=="odd")
            {
                for (int i = first; i <= last; i++)
                {
                    if (i%2!=0)
                    {
                        Console.Write(i+" ");
                    }
                }
                    Console.WriteLine();
            }
            else
            {
                for (int i = first; i <= last; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(i + " ");
                    }
                }
                    Console.WriteLine();
            }
        }
    }
}
