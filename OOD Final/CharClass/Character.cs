using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final.EnemyClass;
using OOD_Final.Interfaces;

namespace OOD_Final
{
    public abstract class Character
    {
        private static readonly Random random = new Random();
        public string Name { get; set; }
        public string ClassType { get; set; }
        public int HitPoints { get; set; }
        public int AttackPower { get; set; }
        public ActionContext ActionContext { get; set; }
        public IAction SecondaryAttack { get; set; }

        protected Character(string name, string classType, int hitPoints, int attackPower, IAction primaryAttack, IAction secondaryAttack) 
        {
            Name = name;
            ClassType = classType;
            HitPoints = hitPoints;
            AttackPower = attackPower;
            ActionContext = new ActionContext(primaryAttack);
            SecondaryAttack = secondaryAttack;
        }

        public override string ToString()
        {
            return $"{Name} ({ClassType}) - HP: {HitPoints}, ATK: {AttackPower}";
        }

        public string PerformPrimaryAttack() => ActionContext.PerformAction();
        public string PerformSecondaryAttack()
        {
            ActionContext.SetAction(SecondaryAttack);
            return ActionContext.PerformAction();
        }

        // Attack Roll 
        public int AttackRoll(Character character)
        {
            int roll = random.Next(1,11); // random roll between 1-10

            // 1 = miss, 2-8 = attack, 9-10 = crit
            if (roll == 1)
            {
                Console.WriteLine("You missed!");
                return 0;
            }
            else if (roll > 1 && roll <= 8)
            {
                int baseDmg = this.AttackPower;
                Console.WriteLine($"You attack for {baseDmg} damage!");
                return baseDmg;
            }
            else // 9-10
            {
                int baseDmg = this.AttackPower * 2;
                Console.WriteLine($"You land a critical hit for {baseDmg} damage!");
                return baseDmg;
            }
        }

        public string Flee()
        {
            string fleeNote;

            if (random.Next(1, 11) > 7) // 30% chance of failure
            {
                fleeNote = "You tripped! Failed to flee.";
            }
            else
            {
                fleeNote = "You escape with your life, but the enemy still roams...";
            }

            return fleeNote;
        }

        // Take Damage
        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
            if (HitPoints < 0) HitPoints = 0;
        }

        // Heal
        public string Heal()
        {
            string healNote = "You used a health potion and healed for 75 HP.";
            int healAmount = 75;
            this.HitPoints += healAmount;
            return healNote;
        }

        // Still Alive?
        public bool IsAlive()
        {
            return HitPoints > 0;
        }
    }
}
