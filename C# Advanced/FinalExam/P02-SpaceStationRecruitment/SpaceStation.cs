using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            data = new List<Astronaut>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count();

        public void Add(Astronaut astronaut)
        {
            if (Capacity > data.Count)
            {
                data.Add(astronaut);
            }
        }

        public bool Remove(string name) //Return true or false?
        {
            bool astronautToRemove = data.Any(n => n.Name == name);

            if (astronautToRemove)
            {
                Astronaut astronaut = data.First(n => n.Name == name);
                data.Remove(astronaut);
            }

            return astronautToRemove;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut oldestAstraunaft = data.OrderByDescending(a => a.Age).FirstOrDefault();
            return oldestAstraunaft;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut currentAstraunaft = data.FirstOrDefault(n => n.Name == name);
            return currentAstraunaft;
        }

        public string Report()
        {
            var textToPrint = new StringBuilder();

            textToPrint.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in data)
            {
                textToPrint.AppendLine(astronaut.ToString());
            }

            return textToPrint.ToString().TrimEnd();
        }
    }
}
