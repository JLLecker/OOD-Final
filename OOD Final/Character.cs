using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final.EnemyClass;
using OOD_Final.Interfaces;

namespace OOD_Final
{
    public class Character
    {
        private static readonly Random random = new Random(); // for random attack roll
        public string Name { get; set; }
        public string ClassType { get; set; }
        public int HitPoints { get; set; }
        public int AttackPower { get; set; }
        public ActionContext ActionContext { get; set; }
        public List<IAction> Actions { get; }


        public Character(string name, string classType, int hitPoints, int attackPower, List<IAction> actions) 
        {
            Name = name;
            ClassType = classType;
            HitPoints = hitPoints;
            AttackPower = attackPower;
            ActionContext = new ActionContext(actions);
            Actions = actions;
        }

        // tostring for character info
        public override string ToString()
        {
            return $"{Name} ({ClassType}) - HP: {HitPoints}, ATK: {AttackPower}";
        }

        // Perform the primary action (first in list)
        public string PerformPrimaryAttack()
        {
            if (Actions.Count == 0)
            {
                throw new InvalidOperationException("No actions available for this character.");
            }

            ActionContext.SetAction(Actions[0]);
            return ActionContext.PerformAction();
        }

        // Perform the secondary action (second in list)
        public string PerformSecondaryAttack()
        {
            if (Actions.Count < 2)
            {
                throw new InvalidOperationException("No secondary action available for this character.");
            }

            ActionContext.SetAction(Actions[1]); // assign secondary attack
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
                return 0; // no dmg
            }
            else if (roll > 1 && roll <= 8) // reg attack, base dmg
            {
                int baseDmg = this.AttackPower;
                Console.WriteLine($"You attack for {baseDmg} damage!");
                return baseDmg;
            }
            else // 9-10, crit, basedmg * 2
            {
                int baseDmg = this.AttackPower * 2;
                Console.WriteLine($"You land a critical hit for {baseDmg} damage!");
                return baseDmg;
            }
        }

        // method to flee ** ADD TO ACTIONS! 
        public string Flee()
        {
            string fleeNote; // return

            if (random.Next(1, 11) > 7) // 30% chance of failure
            {
                fleeNote = "You tripped! Failed to flee.";
            }
            else // flee succeeded
            {
                fleeNote = "You escape with your life, but the enemy still roams...";
            }

            return fleeNote;
        }

        // Take Damage, update HP
        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
            if (HitPoints < 0) HitPoints = 0;
        }

        // Heal ** ADD TO ACTIONSS!
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
