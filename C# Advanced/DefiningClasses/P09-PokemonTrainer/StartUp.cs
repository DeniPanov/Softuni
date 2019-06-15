namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var trainers = new List<Trainer>();
            Trainer trainer = new Trainer();

            while (input != "Tournament")
            {
                var tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainer currentTrainer = trainers.FirstOrDefault(x => x.Name == trainerName);

                if (currentTrainer != null)
                {
                    currentTrainer.PokemonCollection.Add(pokemon);
                    input = Console.ReadLine();
                    continue;
                }

                trainer = new Trainer();
                trainer.Name = trainerName;
                trainer.PokemonCollection.Add(pokemon);
                trainers.Add(trainer);

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Fire")
                {
                    CheckForMatch(trainers, command);
                }

                else if (command == "Water")
                {
                    CheckForMatch(trainers, command);
                }

                else if (command == "Electricity")
                {
                    CheckForMatch(trainers, command);
                }

                command = Console.ReadLine();
            }

            foreach (var pokemonTrainer in trainers.OrderByDescending(p => p.Badges))
            {
                Console.WriteLine($"{pokemonTrainer.Name} {pokemonTrainer.Badges} {pokemonTrainer.PokemonCollection.Count}");
            }

        }

        private static void CheckForMatch(List<Trainer> trainers, string command)
        {
            foreach (var pokemonTrainer in trainers)
            {
                bool match = pokemonTrainer.PokemonCollection.Any(e => e.Element == command);

                if (match)
                {
                    pokemonTrainer.Badges++;
                }

                else
                {
                    foreach (var pokemon in pokemonTrainer.PokemonCollection)
                    {
                        pokemon.Health -= 10;
                    }
                }
            }

            foreach (var pokemonTrainer in trainers)
            {
                pokemonTrainer.PokemonCollection.RemoveAll(x => x.Health <= 0);
            }
        }
    }
}
