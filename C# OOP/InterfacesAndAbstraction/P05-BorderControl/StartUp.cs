namespace P05_BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P05_BorderControl.Interfaces;
    using P05_BorderControl.Models;

    public class StartUp
    {
        public static void Main()
        {
            List<Ids> population = new List<Ids>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    Robot robot = AddRobot(tokens);
                    population.Add(robot);
                }

                else if (tokens.Length == 3)
                {
                    Citizen citizen = AddCitizen(tokens);
                    population.Add(citizen);
                }

                command = Console.ReadLine();
            }

            string populationToDetain = Console.ReadLine();

            foreach (var member in population)
            {
                if (member.Id.EndsWith(populationToDetain))
                {
                    Console.WriteLine(member.Id);
                }
            }
        }

        private static Citizen AddCitizen(string[] tokens)
        {
            string citizenName = tokens[0];
            int citizenAge = int.Parse(tokens[1]);
            string citizenId = tokens[2];

            Citizen citizen = new Citizen(citizenName, citizenAge, citizenId);
            return citizen;
        }

        private static Robot AddRobot(string[] tokens)
        {
            string robotName = tokens[0];
            string robotId = tokens[1];

            Robot robot = new Robot(robotName, robotId);
            return robot;
        }
    }
}
