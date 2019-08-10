using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            string attackPlayerType = attackPlayer.GetType().Name;
            string enemyPlayerType = enemyPlayer.GetType().Name;

            AddsBonusHealthToBeginners(attackPlayer, attackPlayerType);
            AddsBonusHealthToBeginners(enemyPlayer, enemyPlayerType);

            AddsBonusHealthToPlayerFromHisCards(attackPlayer);
            AddsBonusHealthToPlayerFromHisCards(enemyPlayer);

            int attackPlayerDamagePoints = attackPlayer
                .CardRepository
                .Cards
                .Sum(c => c.DamagePoints);

            int enemyPlayerDamagePoints = enemyPlayer
                .CardRepository
                .Cards
                .Sum(c => c.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamagePoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }


                attackPlayer.TakeDamage(enemyPlayerDamagePoints);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private static void AddsBonusHealthToBeginners(IPlayer attackPlayer, string attackPlayerType)
        {
            if (attackPlayerType == "beginner" || attackPlayerType == "Beginner")
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private static void AddsBonusHealthToPlayerFromHisCards(IPlayer attackPlayer)
        {
            int attackPlayerBonusHealth = attackPlayer
                            .CardRepository
                            .Cards
                            .Sum(c => c.HealthPoints);

            attackPlayer.Health += attackPlayerBonusHealth;
        }
    }
}
