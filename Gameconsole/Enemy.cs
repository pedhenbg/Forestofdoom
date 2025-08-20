using System;
using System.Collections.Generic;

namespace Gameconsole
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }
        public int XPReward { get; set; }

        public Enemy(string name, int health, int attackDamage, int xpReward)
        {
            Name = name;
            Health = health;
            AttackDamage = attackDamage;
            XPReward = xpReward;
        }

        public static Enemy CreateRandomEnemy(Random rand)
        {
            List<Enemy> enemyPrototypes = new List<Enemy>
            {
                new Enemy("Goblin", 50, 5, 25),
                new Enemy("Skeleton", 60, 7, 35),
                new Enemy("Giant Rat", 30, 8, 15),
                new Enemy("Slime", 40, 4, 20),
                new Enemy("Wendigo", 70, 6, 50)
            };

            int index = rand.Next(0, enemyPrototypes.Count);
            Enemy p = enemyPrototypes[index];

            return new Enemy(p.Name, p.Health, p.AttackDamage, p.XPReward);
        }

        public static Enemy CreateBoss()
        {
            return new Enemy("The Corrupted Treant", 150, 12, 200);
        }
    }
}