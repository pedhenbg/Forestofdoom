    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace Gameconsole
{
    public class Player
    {
        // Atributos Base
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AttackDamage { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int XPUntilNextLevel { get; set; }

        // Inventário
        public int Potions { get; set; }
        public Equipment? EquippedItem { get; set; } // '?' permite que o item seja nulo (nada equipado)

        // Atributos Calculados (levam em conta os bônus dos equipamentos)
        public int TotalAttackDamage => AttackDamage + (EquippedItem?.AttackBonus ?? 0);
        public int TotalMaxHealth => MaxHealth + (EquippedItem?.HealthBonus ?? 0);
    }
}