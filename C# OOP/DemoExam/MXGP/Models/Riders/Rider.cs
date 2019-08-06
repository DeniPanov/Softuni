namespace MXGP.Models.Riders
{
    using System;
    using System.Collections.Generic;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Riders.Contracts;

    public class Rider : IRider
    {
        private string name;
        private bool canParticipate = false;
        private readonly List<IMotorcycle> motorcycles;
        public Rider(string name)
        {
            this.Name = name;
            this.motorcycles = new List<IMotorcycle>();
        }
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get => this.canParticipate;

            private set
            {
                if (this.Motorcycle != null)
                {
                    canParticipate = true;
                }

                this.canParticipate = value;
            }
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException("Motorcycle cannot be null.");
            }

            motorcycles.Add(motorcycle);
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
