namespace FightingArena
{
    using System.Text;

    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            int totalPower = GetWeaponPower() + GetStatPower();
            return totalPower;
        }

        public int GetWeaponPower()
        {
            int weaponPower = Weapon.Size + Weapon.Solidity + Weapon.Sharpness;
            return weaponPower;
        }

        public int GetStatPower()
        {
            int statSum = Stat.Strength + Stat.Flexibility + Stat.Agility + Stat.Skills + Stat.Intelligence;
            return statSum;
        }

        public override string ToString()
        {
            var textToPrint = new StringBuilder();

            textToPrint.AppendLine("[Gladiator name] - [Gladiator total power]");
            textToPrint.AppendLine("  Weapon Power: [Gladiator weapon power]");
            textToPrint.AppendLine("  Stat Power: [Gladiator stat power]");

            return textToPrint.ToString().TrimEnd();
        }
    }
}
