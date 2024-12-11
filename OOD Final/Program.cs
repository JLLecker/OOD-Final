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
            bool playAgain = true;

            while (playAgain)
            {

                // Observer Setup
                EventNotifier characterNotifier = new EventNotifier();
                EventNotifier enemyNotifier = new EventNotifier();

                HUD hud = new HUD();
                Sound soundSystem = new Sound();

                characterNotifier.AddObserver(hud);
                enemyNotifier.AddObserver(hud);
                characterNotifier.AddObserver(soundSystem);
                enemyNotifier.AddObserver(soundSystem);

                Character character = null;
                ActionContext actionContext = null;
                string chosenClass = null; // Store the valid chosen class
                bool validCharacter = false;

                while (!validCharacter)
                {
                    try
                    {
                        // Step 1: Choose Class
                        if (chosenClass == null)
                        {
                            Console.WriteLine("Choose your character class: Mage, Warrior, Archer, Thief, Knight");
                            string type = Console.ReadLine()?.Trim().ToLower();

                            // Validate class type
                            if (type != "mage" && type != "warrior" && type != "archer" && type != "thief" && type != "knight")
                            {
                                Console.WriteLine("Invalid character class. Try again.");
                                continue;
                            }

                            chosenClass = type; // Save the valid class choice
                        }

                        // Step 2: Enter Name
                        Console.WriteLine("Enter your character's name:");
                        string name = Console.ReadLine()?.Trim();

                        // Validate character name
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Character name cannot be empty or whitespace. Please try again.");
                            continue; // Ask for the name again
                        }

                        // Attempt to create the character
                        (character, actionContext) = CharacterFactory.CreateCharacter(chosenClass, name);
                        Console.WriteLine($"Created character: {character.ToString()}");

                        validCharacter = true; // Exit the loop on successful creation
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        Console.WriteLine("Please try again.");
                    }
                }

                //int healthPotions = 2;
                //Console.WriteLine($"You have {healthPotions} health potions available.");


                // Encounter Setup: Random Enemy
                var random = new Random();
                Enemy enemy = EnemyFactory.CreateRandomEnemy();
                Console.WriteLine($"A wild {enemy.Name} appears!\n   {enemy}");

                bool inCombat = true; // controls combat loop

                // Combat Loop
                while (inCombat && enemy.IsAlive() && character.IsAlive())
                {
                    Console.WriteLine("Choose an action by number:\n1. Main \n2. Secondary \n3. Heal \n4. Flee");
                    string action = Console.ReadLine()?.Trim();

                    string characterResult;

                    switch (action)
                    {
                        case "1":
                            characterResult = character.PerformPrimaryAttack(); // Displays attack type
                            int rollResult = character.AttackRoll(character); // Returns attack dmg
                            enemy.TakeDamage(rollResult);

                            enemyNotifier.NotifyObservers($"Enemy health: {enemy.HitPoints} HP");
                            break;

                        case "2":
                            characterResult = character.PerformSecondaryAttack(); // Displays attack type
                            rollResult = character.AttackRoll(character); // Returns attack dmg
                            enemy.TakeDamage(rollResult);

                            enemyNotifier.NotifyObservers($"Enemy health: {enemy.HitPoints} HP");
                            break;

                        case "3":
                            characterResult = character.Heal();

                            characterNotifier.NotifyObservers(characterResult);
                            break;

                        case "4":
                            characterResult = character.Flee();
                            characterNotifier.NotifyObservers(characterResult);
                            characterNotifier.NotifyObservers($"Your health: {character.HitPoints} HP");
                            inCombat = false; // exit combat loop
                            continue;

                        default:
                            Console.WriteLine("Invalid action. Please choose again.");
                            continue;
                    }


                    if (enemy.IsAlive())
                    {
                        int enemyDamage = enemy.AttackRoll(enemy);
                        character.TakeDamage(enemyDamage);
                        characterNotifier.NotifyObservers($"Your health: {character.HitPoints} HP");
                        Console.WriteLine("--------------");
                    }

                }

                // End of battle
                if (!character.IsAlive())
                {
                    characterNotifier.NotifyObservers($"You have been defeated by {enemy.Name}!", isDeathNofication: true);
                }
                else if (!enemy.IsAlive())
                {
                    characterNotifier.NotifyObservers($"You defeated the {enemy.Name}!", isDeathNofication: true);
                }

                // Ask if the player wants to play again
                Console.WriteLine("Would you like to play again? (yes/no)");
                string response = Console.ReadLine()?.Trim()?.ToLower();

                if (response != "yes")
                {
                    Console.WriteLine("Thank you for playing! Goodbye.");
                    playAgain = false;
                    Console.ReadLine();
                }
            }
        }
    }
}
