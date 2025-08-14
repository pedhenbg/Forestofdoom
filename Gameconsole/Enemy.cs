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
    }
}
