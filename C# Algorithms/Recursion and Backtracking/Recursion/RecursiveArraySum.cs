namespace Recursion
{
    using System;
    using System.Linq;

    public class RecursiveArraySum
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                    .Split().Select(int.Parse).ToArray();
            
            var result = SumElements(input, 0);

            Console.WriteLine(result);
        }

        private static int SumElements(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                return 0;
            }

            return arr[index] + SumElements(arr, ++index);
        }
    }
}
