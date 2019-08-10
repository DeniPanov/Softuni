using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public CardFactory()
        {

        }
        public ICard CreateCard(string type, string name)
        {
            throw new NotImplementedException();
        }
    }
}
