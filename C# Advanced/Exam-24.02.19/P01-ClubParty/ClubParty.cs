namespace P01_ClubParty
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Stack<string> hallsAndPeople = new Stack<string>(input);
            Queue<string> halls = new Queue<string>(input.Length);
            var reservation = new List<int>();
            int currentHallCapacity = 0;

            while (hallsAndPeople.Count > 0)
            {
                string currentElement = hallsAndPeople.Pop();

                bool isNumber = int.TryParse(currentElement, out int parsedNumber);

                if (isNumber)
                {
                    if (halls.Count > 0)
                    {
                        currentHallCapacity += parsedNumber;

                        if (maxCapacity >= currentHallCapacity)
                        {
                            reservation.Add(parsedNumber);
                        }

                        else if (maxCapacity < currentHallCapacity)
                        {
                            if (halls.Count > 0) //What if "reservation" is empty?
                            {
                                Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", reservation)}");
                                reservation.Clear();
                                currentHallCapacity = 0;

                                if (halls.Count > 0)
                                {
                                    reservation.Add(parsedNumber);
                                    currentHallCapacity += parsedNumber;
                                }
                            }

                            else
                            {
                                continue;
                            }
                        }
                    }                    
                }

                else
                {
                    halls.Enqueue(currentElement);
                }
            }
        }
    }
}
