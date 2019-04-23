namespace DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            var binaryNumber = new Stack<int>();
            int remainder = 0;

            if (decimalNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;
                int result = decimalNumber / 2;
                decimalNumber = result;
                binaryNumber.Push(remainder);
            }

            foreach (var bin in binaryNumber)
            {
                Console.Write(bin);
            }
        }
    }
}
