using System;
using System.Collections.Generic;
using System.Linq;

public class HouseParty
{
    public static void Main()
    {
        AddOrRemoveGuestsFromTheList();
    }

    private static void AddOrRemoveGuestsFromTheList()
    {
        int n = int.Parse(Console.ReadLine());
        var guestsList = new List<string>();
        //var listOfCommands = new List<string>();
        string name = string.Empty;
        string command = string.Empty;

        for (int i = 0; i < n; i++)
        {
            command = Console.ReadLine();
            char[] symbolsToSplit = { ' ' };
            var listOfCommands = command.Split(symbolsToSplit, StringSplitOptions.RemoveEmptyEntries).ToList();
            name += listOfCommands[0];
            bool isInTheGuestList = true;
            isInTheGuestList = guestsList.Contains(name);

            if (listOfCommands[1] == "is" && listOfCommands[2] == "going!")
            {
                if (guestsList.Contains(name))
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else
                {
                    guestsList.Add(name);
                }
            }
            else if (listOfCommands[1] == "is" && listOfCommands[2] == "not" && listOfCommands[3] == "going!")
            {
                if (guestsList.Contains(name))
                {
                    guestsList.Remove(name);
                }
                else
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
            }
            else
            {
                continue;
            }
            name = string.Empty;
        }
        Console.WriteLine(string.Join(" ",guestsList));
    }
}