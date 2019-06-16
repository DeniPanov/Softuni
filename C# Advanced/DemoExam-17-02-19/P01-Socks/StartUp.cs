namespace P01_Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] leftSocksInput = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var leftSocks = new Stack<int>(leftSocksInput);

            int[] rightSocksInput = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var rightSocks = new Queue<int>(rightSocksInput);

            var setsOfSocks = new Queue<int>();

            while (leftSocks.Count > 0 && rightSocks.Count > 0)
            {
                int currentLeftSock =  leftSocks.Peek();
                int currentRightSock = rightSocks.Peek();

                if (currentLeftSock > currentRightSock)
                {
                    setsOfSocks.Enqueue(currentLeftSock + currentRightSock);

                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }

                else if (currentLeftSock == currentRightSock)
                {
                    rightSocks.Dequeue();
                    currentLeftSock += 1;

                    leftSocks.Pop();
                    leftSocks.Push(currentLeftSock);
                }

                else if (currentLeftSock < currentRightSock)
                {
                    leftSocks.Pop();
                }
            }

            Console.WriteLine(setsOfSocks.Max());
            Console.WriteLine(string.Join(' ',setsOfSocks));
        }
    }
}
