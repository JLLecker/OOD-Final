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

        public override string ToString()
        {
            return $"{Type} - HP: {HitPoints}, ATK: {AttackPower}";
        }

        // Attack Roll 
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

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
            if (HitPoints < 0) HitPoints = 0;
        }

        public bool IsAlive()
        {
            return HitPoints > 0;
        }
    }

}
