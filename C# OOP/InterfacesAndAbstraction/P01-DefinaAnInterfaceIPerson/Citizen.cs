﻿namespace PersonInfo
{
    public class Citizen : IPerson
    {
        private int age;

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
    }
}
