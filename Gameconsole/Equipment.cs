namespace Gameconsole
{
    public class Equipment
    {
        public string Name { get; set; }
        public int AttackBonus { get; set; }
        public int HealthBonus { get; set; }

        public Equipment(string name, int attackBonus, int healthBonus)
        {
            Name = name;
            AttackBonus = attackBonus;
            HealthBonus = healthBonus;
        }
    }
}