using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameconsole
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }

        public Enemy(string name, int health, int attackDamage)
        {
            Name = name;
            Health = health;
            AttackDamage = attackDamage;
        }
        public static Enemy CreateRandomEnemy(Random rand)
        {
            List<Enemy> enemyPrototypes = new List<Enemy>
            {
                new Enemy("Goblin", 50, 7),
                new Enemy("Skeleton", 60, 7),
                new Enemy("Giant Rat", 30, 8),
                new Enemy("Slime", 40, 4),
                new Enemy("Wendigo", 70, 6)
            };
            int index = rand.Next(0, enemyPrototypes.Count);
            Enemy prototype = enemyPrototypes[index];
            return new Enemy(prototype.Name, prototype.Health, prototype.AttackDamage);
        }
    }   
    
}
