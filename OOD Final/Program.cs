using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final;
using OOD_Final.Actions;
using OOD_Final.EnemyClass;
using OOD_Final.Factories;
using OOD_Final.Notifications;

namespace OOD_Final
{
    internal class Program
    {
        static void Main()
        {
            // Observer Setup
            EventNotifier notifier = new EventNotifier();
            HUD hud = new HUD();
            Sound soundSystem = new Sound();
            notifier.AddSub(hud);
            notifier.AddSub(soundSystem);

            // Prompt user to select a character class
            Console.WriteLine("Choose your character class: Mage, Warrior, Archer, Thief, Knight");
            string type = Console.ReadLine()?.Trim();

            Console.WriteLine("Enter your chacter's name:");
            string name = Console.ReadLine()?.Trim();

            Character character;

            try
            {
                character = CharacterFactory.CreateCharacter(type, name);
                Console.WriteLine($"Created character: {character.Name}");
                character.Display();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("");

            // Encounter Setup: Random Enemy
            var random = new Random();
            Enemy enemy = EnemyFactory.CreateRandomEnemy(random);
            Console.WriteLine($"You have encountered a {enemy.Name} ({enemy.GetDescription()}) with {enemy.HP} HP!");


            // Assign default attack strategy
            ActionContext actionContext = new ActionContext(new SpellAttack());
            if (character.Name == "Warrior")
                actionContext.SetAction(new MeleeAttack());
            else if (character.Name == "Archer")
                actionContext.SetAction(new RangedAttack());
            else if (character.Name == "Knight")
                actionContext.SetAction(new ShieldAttack());
            else if (character.Name == "Thief")
                actionContext.SetAction(new SneakAttack());

            // Combat Loop
            while (enemy.IsAlive())
            {
                Console.WriteLine("Choose an action: Attack or Flee");
                string action = Console.ReadLine()?.Trim()?.ToLower();

                if (action == "flee")
                {
                    notifier.Notify("You fled the battle!");
                    break;
                }
                else if (action == "attack")
                {
                    int damage = random.Next(10, 21); // Damage between 10 and 20
                    enemy.TakeDamage(damage);

                    Console.WriteLine($"You attacked the {enemy.Name} and dealt {damage} damage.");
                    actionContext.PerformAction(); // Displays attack type
                    notifier.Notify($"Enemy health: {enemy.HP} HP");

                    if (!enemy.IsAlive())
                    {
                        notifier.Notify($"The {enemy.Name} has been defeated!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid action. Please choose again.");
                }
            }

            Console.WriteLine("Game Over. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
