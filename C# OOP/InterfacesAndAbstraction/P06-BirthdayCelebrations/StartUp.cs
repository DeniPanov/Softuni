namespace P05_BorderControl
{
    using System;
    using System.Collections.Generic;

    using P05_BorderControl.Interfaces;
    using P05_BorderControl.Models;

    public class StartUp
    {
        public static void Main()
        {
            List<Ibirthable> citizensAndPets = new List<Ibirthable>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Citizen")
                {
                    Citizen citizen = AddCitizen(tokens);

                    citizensAndPets.Add(citizen);                    
                }

                else if (tokens[0] == "Pet")
                {
                    Pet pet = AddPet(tokens);

                    citizensAndPets.Add(pet);
                }

                else if (tokens[0] == "Robot")
                {
                    Robot robot = AddRobot(tokens);
                }

                command = Console.ReadLine();
            }

            string birhtYear = Console.ReadLine();

            foreach (var member in citizensAndPets)
            {
                if (member.Birthdate.EndsWith(birhtYear))
                {
                    Console.WriteLine(member.Birthdate);
                }
            }
        }

        private static Pet AddPet(string[] tokens)
        {
            string petName = tokens[1];
            string petBirthdate = tokens[2];

            Pet pet = new Pet(petName, petBirthdate);
            return pet;
        }

        private static Citizen AddCitizen(string[] tokens)
        {
            string citizenName = tokens[1];
            int citizenAge = int.Parse(tokens[2]);
            string citizenId = tokens[3];
            string birthdate = tokens[4];

            Citizen citizen = new Citizen(citizenName, citizenAge, citizenId, birthdate);
            return citizen;
        }

        private static Robot AddRobot(string[] tokens)
        {
            string robotName = tokens[1];
            string robotId = tokens[2];

            Robot robot = new Robot(robotName, robotId);
            return robot;
        }
    }
}
