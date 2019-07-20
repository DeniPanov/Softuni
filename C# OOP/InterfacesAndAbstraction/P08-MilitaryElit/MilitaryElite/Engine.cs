using System;
using System.Collections.Generic;
using System.Linq;
namespace PersonInfo.MilitaryElite
{
    public class Engine
    {
        private List<ISoldier> army;

        public Engine()
        {
            army = new List<ISoldier>();
        }
        public void Run()
        {
            string command = Console.ReadLine();
            while (command!="End")
            {
                string[] commandArgs = command.Split().ToArray();
                string type = commandArgs[0];
                string id = commandArgs[1];
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];
                decimal salary = decimal.Parse(commandArgs[4]);

                if (type =="Private")
                {
                   Private soldier = new Private(id, firstName, lastName, salary);
                    army.Add(soldier);
                }
                else if (type == "LieutenantGeneral")
                {
                   LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);
                    string[] privatesToAddArgs = commandArgs.Skip(5).ToArray();
                    foreach (var pid in privatesToAddArgs)
                    {
                        ISoldier soldierToAdd = army.FirstOrDefault(s => s.Id == pid);

                        general.AddPrivate(soldierToAdd);
                    }
                    army.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        string[] repairsArgs = commandArgs.Skip(6).ToArray();

                        for (int i = 0; i < repairsArgs.Length; i += 2)
                        {
                            string repairName = repairsArgs[i];
                            int hours = int.Parse(repairsArgs[i + 1]);
                            IRepairs repair = new Repairs(repairName, hours);

                            engineer.AddRepairs(repair);
                        }
                        army.Add(engineer);
                    }
                    catch (Exception)
                    {

                    }
                   
                }
                else if (type == "Commando")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        Commando commando = new Commando(id, firstName, lastName, salary, corps);

                        string[] missionsArgs = commandArgs.Skip(6).ToArray();

                        for (int i = 0; i < missionsArgs.Length; i += 2)
                        {
                            try
                            {
                                string codeName = missionsArgs[i];
                                string state = missionsArgs[i+1];
                                IMissions missions = new Mission(codeName, state);

                                commando.AddMissions(missions);
                            }
                            catch (Exception)
                            {

                                continue;
                            }
                            
                        }
                        army.Add(commando);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                   
                }
                else if (type == "Spy")
                {
                    int codeNumber = (int)salary;

                    Spy spy = new Spy(id, firstName, lastName, codeNumber);

                    army.Add(spy);
                }

                    command = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var soldier in army)
            {
                Type type = soldier.GetType();

                Object actual = Convert.ChangeType(soldier, type);

                Console.WriteLine(actual.ToString());
            }
        }
    }
}
