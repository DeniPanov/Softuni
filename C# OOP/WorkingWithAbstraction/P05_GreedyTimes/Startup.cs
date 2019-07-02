namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            long input = long.Parse(Console.ReadLine());

            string[] safe = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];

                long count = long.Parse(safe[i + 1]);

                string item = string.Empty;

                if (name.Length == 3)
                {
                    item = "Cash";
                }

                else if (name.ToLower().EndsWith("gem"))
                {
                    item = "Gem";
                }

                else if (name.ToLower() == "gold")
                {
                    item = "Gold";
                }

                if (item == "" || input < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                switch (item)
                {
                    case "Gem":

                        if (!bag.ContainsKey(item))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (count > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }

                            else 
                            {
                                continue;
                            }
                        }
                        else if (bag[item].Values.Sum() + count > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }

                        break;

                    case "Cash":

                        if (!bag.ContainsKey(item))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (count > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else 
                            {
                                continue;
                            }
                        }

                        else if (bag[item].Values.Sum() + count > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }

                        break;
                }

                if (!bag.ContainsKey(item))
                {
                    bag[item] = new Dictionary<string, long>();
                }

                if (!bag[item].ContainsKey(name))
                {
                    bag[item][name] = 0;
                }

                bag[item][name] += count;

                if (item == "Gold")
                {
                    gold += count;
                }

                else if (item == "Gem")
                {
                    gems += count;
                }

                else if (item == "Cash")
                {
                    cash += count;
                }
            }

            foreach (var item in bag)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");

                foreach (var currentItem in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{currentItem.Key} - {currentItem.Value}");
                }
            }
        }
    }
}