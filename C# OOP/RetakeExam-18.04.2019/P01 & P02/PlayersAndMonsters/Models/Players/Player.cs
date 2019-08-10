using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private ICardRepository cardRepository;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.Username = username;
            this.Health = health;

            this.cardRepository = cardRepository;
        }

        public ICardRepository CardRepository => this.cardRepository;

        public string Username
        {
            get => this.username;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");//Add space after the point?
                }

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }

                this.health = value;
            }
        }

        public bool IsDead => Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            int currentHealth = this.Health - damagePoints;

            if (currentHealth < 0) //consider <
            {
                this.Health = 0;
            }

            else
            {
                this.Health = currentHealth;
            }
        }
    }
}
