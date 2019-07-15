using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Anonymous_Threat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintAnonymousThreat();
        }

        private static void PrintAnonymousThreat()
        {
            var threat = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "3: 1")
                {
                    Console.WriteLine(string.Join(" ", threat));
                    return;
                }
                var comandSplit = comand.Split().ToList();
                if (comandSplit[0] == "merge")
                {
                    int start = int.Parse(comandSplit[1]);
                    int final = int.Parse(comandSplit[2]);
                    while (start < final)
                    {
                        threat[int.Parse(comandSplit[1])] += threat[start + 1];
                        start++;
                    }
                    start = int.Parse(comandSplit[1]);

                    for (int i = final; i >= start + 1; i--)
                    {
                        threat.RemoveAt(i);
                    }
                }
            }
        }
    }
}