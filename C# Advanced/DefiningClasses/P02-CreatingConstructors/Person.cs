﻿namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                age = value;
            }
        }

        public Person()
        {
            name = "No name";
            age = 1;
        }

        public Person(int age)
            : this ()
        {
            this.age = age;
        }

        public Person(string name, int age)
            : this(age)
        {
            this.name = name;
        }
    }
}
