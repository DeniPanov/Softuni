using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class CustomMinFunction 
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> min = x => x.Min();
            Console.WriteLine(min(numbers));
        }
    }
}
