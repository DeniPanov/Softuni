namespace CommonElements
{
    using System;

    class CommonElements
    {
        static void Main()
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();

            foreach (var a2 in arr2)
            {
                foreach (var a1 in arr1)
                {
                    if (a1 == a2)
                    {
                        Console.Write(a2 + " ");
                    }
                }
            }
        }
    }
}
