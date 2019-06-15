namespace DefiningClasses
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int familySize = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < familySize; i++)
            {
                string[] currentMemmberInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string memberName = currentMemmberInfo[0];
                int memberAge = int.Parse(currentMemmberInfo[1]);

                Person currentMember = new Person(memberName, memberAge);

                family.AddMember(currentMember);
            }

            Person oldestPerson = family.OldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
