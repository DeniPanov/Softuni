using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public PlayerFactory()
        {

        }
        public IPlayer CreatePlayer(string type, string username)
        {
            throw new NotImplementedException();
        }
    }
}
