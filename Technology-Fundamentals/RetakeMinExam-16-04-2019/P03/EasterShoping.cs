namespace P03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EasterShoping
    {
        public static void Main()
        {
            var shopsToVisit = Console.ReadLine().Split().ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split().ToList();
                //Include HM

                string command = tokens[0];

                if (command == "Include")
                {
                    //Include HM
                    string shop = tokens[1];
                    shopsToVisit.Add(shop);
                }
                else if (command == "Visit")
                {
                    //Visit first 2
                    string firstOrLast = tokens[1];
                    int index = int.Parse(tokens[2]);

                    if (index <= shopsToVisit.Count)
                    {
                        if (firstOrLast == "first")
                        {
                            shopsToVisit.RemoveRange(0, index);
                        }
                        else if (firstOrLast == "last")
                        {
                            shopsToVisit.RemoveRange(shopsToVisit.Count - index, index);
                        }
                    }
                }
                else if (command == "Prefer")
                {
                    //Prefer 3 1

                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);



                    if (index1 >= 0 && index1 < shopsToVisit.Count &&
                        index2 >= 0 && index2 < shopsToVisit.Count) //Consider <=
                    {
                        string shop1 = shopsToVisit[index1];
                        string shop2 = shopsToVisit[index2];

                        string temp = shop2;

                        shopsToVisit.Insert(index2, shop1);
                        shopsToVisit.RemoveAt(index2 + 1);
                        shopsToVisit.Insert(index1, temp);
                        shopsToVisit.RemoveAt(index1 + 1);
                    }
                }
                else if (command == "Place")
                {
                    //Place Library 2
                    string shop = tokens[1];
                    int index = int.Parse(tokens[2]);

                    if (index >= 0 && index < shopsToVisit.Count) // Consider <= or Count + 1?
                    {
                        shopsToVisit.Insert(index + 1, shop);
                    }
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shopsToVisit));
        }
    }
}
