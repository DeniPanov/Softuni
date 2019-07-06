namespace PlayersAndMonsters
{
    using System;

    public class Hero
    {
        private int level;

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username { get; set; }

        public int Level
        {
            get => level;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Hero level can not lesser than 1");
                }

                this.level = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
