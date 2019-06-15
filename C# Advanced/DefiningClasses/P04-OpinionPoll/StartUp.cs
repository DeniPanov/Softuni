namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());
            var thirtyPlus = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] currentPerson = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string personName = currentPerson[0];
                int personAge = int.Parse(currentPerson[1]);

                Person currentMember = new Person(personName, personAge);

                if (currentMember.Age > 30)
                {
                    thirtyPlus.Add(currentMember);
                }
            }

            if (thirtyPlus.Count > 0)
            {
                foreach (var person in thirtyPlus.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
        }
    }
}
