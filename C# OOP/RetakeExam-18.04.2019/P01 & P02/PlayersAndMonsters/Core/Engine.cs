using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController managerController;
        public Engine()
        {
            managerController = new ManagerController();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Exit")
            {
                try
                {
                    string[] tokens = command
                       .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (command.StartsWith("AddPlayerCard"))
                    {
                        string playerName = tokens[1];
                        string cardName = tokens[2];

                        Console.WriteLine(managerController.AddPlayerCard(playerName, cardName));
                    }

                    else if (command.StartsWith("AddPlayer"))
                    {
                        string type = tokens[1];
                        string username = tokens[2];

                        Console.WriteLine(managerController.AddPlayer(type, username));
                    }

                    else if (command.StartsWith("AddCard"))
                    {
                        string type = tokens[1];
                        string name = tokens[2];

                        Console.WriteLine(managerController.AddCard(type, name));
                    }

                    else if (command.StartsWith("Fight"))
                    {
                        string attackerName = tokens[1];
                        string defenderName = tokens[2];

                        Console.WriteLine(managerController.Fight(attackerName, defenderName));
                    }

                    else if (command.StartsWith("Report"))
                    {
                        Console.WriteLine(managerController.Report());
                    }

                    command = Console.ReadLine();
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
