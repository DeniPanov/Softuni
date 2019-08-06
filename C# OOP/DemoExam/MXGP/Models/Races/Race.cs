namespace MXGP.Models.Races
{
    using System;
    using System.Collections.Generic;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;

    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly List<IRider> riders;
        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            this.riders = new List<IRider>();
        }
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5) //All names are unique?
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => riders;

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException("Rider cannot be null.");
            }

            if (rider.CanParticipate == false)
            {
                throw new ArgumentException($"Rider { rider.Name } could not participate in race.");
            }

            if (riders.Contains(rider))
            {
                throw new ArgumentNullException($"Rider {rider.Name} is already added in {this.Name} race.");
            }

            riders.Add(rider);
        }
    }
}
