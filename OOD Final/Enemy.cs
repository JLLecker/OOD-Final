using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.EnemyClass
{
    public abstract class Enemy
    {
        private static readonly Random random = new Random();
        public string Name { get; set; }
        public string Type { get; set; }
        public int HitPoints { get; set; }
        public int AttackPower { get; set; }

        protected Enemy(string type, int hitPoints, int attackPower)
        {
            Name = type;
            Type = type;
            HitPoints = hitPoints;
            AttackPower = attackPower;
        }

        // tostring for enemy info
        public override string ToString()
        {
            return $"{Type} - HP: {HitPoints}, ATK: {AttackPower}";
        }

        // Attack Roll - hit, miss, crit
        public int AttackRoll(Enemy enemy)
        {
            int roll = random.Next(1, 11); // random roll between 1-10

            // 1-3 = miss, 4-9 = attack, 10 = crit
            if (roll <= 3)
            {
                Console.WriteLine($"{this.Name} missed! 0 damage done!");
                return 0;
            }
            else if (roll > 3 && roll <= 9)
            {
                int baseDmg = this.AttackPower;
                Console.WriteLine($"{this.Name} attacks for {baseDmg} damage!");
                return baseDmg;
            }
            else // 10
            {
                int baseDmg = this.AttackPower * 2;
                Console.WriteLine($"{this.Name} landed a critical hit for {baseDmg} damage!");
                return baseDmg;
            }
        }

        // method for taking damage, calcultes HP change
        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
            if (HitPoints < 0) HitPoints = 0;
        }

        // whether enemy is alive
        public bool IsAlive()
        {
            return HitPoints > 0;
        }
    }

}
