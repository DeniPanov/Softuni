namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private ICardRepository cardRepository;
        private IPlayerRepository playerRepository;

        private ICardFactory cardFactory;
        private IPlayerFactory playerFactory;

        private BattleField battleField;
        public ManagerController()
        {
            cardRepository = new CardRepository();
            playerRepository = new PlayerRepository();
            battleField = new BattleField();
            cardFactory = new CardFactory();
            playerFactory = new PlayerFactory();
        }

        public string AddPlayer(string type, string username)
        {
            ICardRepository currentCardRepository = new CardRepository();

            if (type == "Beginner")
            {
                Beginner beginner = new Beginner(currentCardRepository, username);

                playerRepository.Add(beginner);
            }

            else if (type == "Advanced")
            {
                Player player = new Advanced(currentCardRepository, username);

                playerRepository.Add(player);
            }

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            if (type == "Trap")
            {
                ICard card = new TrapCard(name);

                cardRepository.Add(card);
            }

            else if (type == "Magic")
            {
                ICard card = new MagicCard(name);

                cardRepository.Add(card);
            }

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer neededPlayer = playerRepository.Find(username);
            ICard neededCard = cardRepository.Find(cardName);

            neededPlayer.CardRepository.Add(neededCard);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = playerRepository.Find(attackUser);
            var defender = playerRepository.Find(enemyUser);

            battleField.Fight(attacker, defender);

            return $"Attack user health {attacker.Health} - Enemy user health {defender.Health}";
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                result.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    result.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                result.AppendLine("###");
            }

            return result.ToString().TrimEnd();
        }
    }
}
