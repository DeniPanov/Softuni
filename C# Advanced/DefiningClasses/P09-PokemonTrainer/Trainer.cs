namespace PokemonTrainer
{
    using System.Collections.Generic;

    public class Trainer
    {
        private List<Pokemon> pokemonCollection;

        public Trainer()
        {
            pokemonCollection = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int Badges { get; set; } = 0;

        public List<Pokemon> PokemonCollection { get => pokemonCollection; set => pokemonCollection = value; }
    }
}
