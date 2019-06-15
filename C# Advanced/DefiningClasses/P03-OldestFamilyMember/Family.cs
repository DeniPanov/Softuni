namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;
    public class Family
    {
        public List<Person> family;

        public Family()
        {
            family = new List<Person>();
        }
        public void AddMember(Person member)
        {
            family.Add(member);
        }

        public Person OldestMember()
        {
            Person oldestFamilyMember = family.OrderByDescending(p => p.Age).FirstOrDefault();
            return oldestFamilyMember;
        }
    }
}
