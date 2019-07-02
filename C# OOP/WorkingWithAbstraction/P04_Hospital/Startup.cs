namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>(); //Consider replacing the dicts with classes!
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] tokens = command
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                var departament = tokens[0];
                var firstName = tokens[1];
                var lastName = tokens[2];
                var patient = tokens[3];
                var fullName = firstName + lastName;

                if (!doctors.ContainsKey(firstName + lastName))
                {
                    doctors[fullName] = new List<string>();
                }

                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();

                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool hasRoom = departments[departament].SelectMany(x => x).Count() < 60;

                if (hasRoom)
                {
                    int room = 0;

                    doctors[fullName].Add(patient);

                    for (int i = 0; i < departments[departament].Count; i++)
                    {
                        if (departments[departament][i].Count < 3)
                        {
                            room = i;
                            break;
                        }
                    }

                    departments[departament][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandParts = command
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                if (commandParts.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[commandParts[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }

                else if (commandParts.Length == 2 && int.TryParse(commandParts[1], out int staq))
                {
                    Console.WriteLine(string.Join("\n", departments[commandParts[0]][staq - 1].OrderBy(x => x)));
                }

                else
                {
                    Console.WriteLine(string.Join("\n", doctors[commandParts[0] + commandParts[1]].OrderBy(x => x)));
                }

                command = Console.ReadLine();
            }
        }
    }
}
