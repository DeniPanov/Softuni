namespace P08_MilitaryElite.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using P08_MilitaryElite.Models;
    using P08_MilitaryElite.Contracts;

    public class Engine
    {
        private readonly List<ISoldier> army;
        public Engine()
        {
            army = new List<ISoldier>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];

                if (type == "Private")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    IPrivate @private = new Private(id, firstName, lastName, salary);
                    army.Add(@private);
                }

                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(tokens[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    army.Add(spy);
                }

                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    LieutenantGeneral ltg = new LieutenantGeneral(id, firstName, lastName, salary);

                    var ltgPrivatesIds = tokens
                        .Skip(5)
                        .Select(int.Parse)
                        .ToArray();

                    foreach (var privateId in ltgPrivatesIds)
                    {
                        ISoldier currentPrivate = army
                            .FirstOrDefault(p => p.Id == privateId);

                        ltg.AddPrivate(currentPrivate);
                    }

                    army.Add(ltg);
                }

                else if (type == "Engineer")
                {
                    try
                    {
                        decimal salary = decimal.Parse(tokens[4]);
                        string corps = tokens[5];

                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        var engineerRepairs = tokens
                            .Skip(6)
                            .ToArray();

                        for (int i = 0; i < engineerRepairs.Length; i += 2)
                        {
                            string partName = engineerRepairs[i];
                            int hoursWorked = int.Parse(engineerRepairs[i + 1]);

                            Repairs repairs = new Repairs(partName, hoursWorked);
                            engineer.AddRepair(repairs);
                        }

                        army.Add(engineer);
                    }

                    catch (InvalidOperationException )
                    {
                       
                    }
                }

                else if (type == "Commando")
                {
                    try
                    {
                        decimal salary = decimal.Parse(tokens[4]);
                        string corps = tokens[5];

                        Commando commando = new Commando(id, firstName, lastName, salary, corps);

                        var commandoMissions = tokens
                            .Skip(6)
                            .ToArray();

                        for (int i = 0; i < commandoMissions.Length; i += 2)
                        {
                            try
                            {
                                string codeName = commandoMissions[i];
                                string state = commandoMissions[i + 1];

                                Mission mission = new Mission(codeName, state);

                                commando.AddMission(mission);
                            }
                            catch (ArgumentException)
                            {
                                continue;
                            }
                        }

                        army.Add(commando);
                    }

                    catch (InvalidOperationException)
                    {
                        continue;
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var soldier in army)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
