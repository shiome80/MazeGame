using System;

namespace MazeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameMenu();
        }
        private static void GameMenu ()
        {
            Console.WriteLine("Test af forskellige tasks");
            Console.WriteLine("Brug: 1, 2, 3");
            int testInput = int.Parse(Console.ReadLine());

            switch (testInput)
            {
                case 1:
                    {

                        break;
                    }
                case 2:
                    {

                        break;
                    }
                case 3:
                    {
                        EncounterType();
                        break;
                    }
            }
        }

        private static void EncounterType ()
        {
            Random encounterPick = new Random();
            int newFoe = encounterPick.Next(1, 21);

            switch (newFoe)
            {
                case 1:
                    {
                        DeathTrap();
                        break;
                    }
                case int n when (n <= 10 && n >= 2):
                    {
                        Goblin();
                        break;
                    }
                case int n when (n <= 15 && n >= 10):
                    {
                        TripWire();
                        break;
                    }
                case int n when (n <= 19 && n >= 15):
                    {
                        SpikeTrap();
                        break;
                    }
                case 20:
                    {
                        Lucky();
                        break;
                    }
            }
        }
        private static void DeathTrap()
        {
            Console.Clear();
            Random chance = new Random();
            int you;

            Console.WriteLine("You stand before a seemingly buttomless pit.");
            Console.WriteLine("What do you do?");
            string userInput = Console.ReadLine();

            if (userInput.ToLower().Contains("jump"))
            {
                you = chance.Next(1, 100);
                if (you >= 25)
                {
                    Console.WriteLine("You succed jumping over the pit");
                    Console.ReadKey(true);
                    EncounterType();
                }
                else
                {
                    Console.WriteLine("You fail jumping the pit and fall to your death.");
                    Console.ReadKey(true);
                    // Jump to Menu
                }
            } 
            else
            {
                Console.WriteLine("Wrong input");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey(true);
                DeathTrap();
            }
        }

        private static void Goblin()
        {
            Console.Clear();
            Random rand = new Random();
            int chance = rand.Next(1, 20);

            string input;
            Console.WriteLine("You stand before a single goblin");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("");
            Console.WriteLine("Attack");
            Console.WriteLine("Befriend   -    Run away");
                
            input = Console.ReadLine().ToLower().Trim();
            if (input.Contains("attack"))
            {
                Console.WriteLine("You attack the goblin");
                if (chance == 20)
                {
                    Console.WriteLine("and punch so hard crack his skull open, killing it instantly");
                    Console.ReadKey(true);
                    EncounterType();
                }
                else if (chance == 1)
                {
                    Console.WriteLine("You charge the goblin but fall to the ground");
                    Console.WriteLine("The goblin start beating you");
                    Console.WriteLine("You take 10 damage");
                    Console.ReadKey(true);
                    EncounterType();
                }
                else
                {
                    Console.WriteLine("You attack the goblin with your fist");
                    Console.WriteLine("The goblin flees into the darkness");
                    Console.ReadKey(true);
                    EncounterType();
                }
            }
            else if (input.Contains("run"))
            {
                Console.WriteLine("You can't run dumbass.. You're trapped in a maze..");
                Console.ReadKey(true);
                Goblin();
            }
            else if (input.Contains("befriend"))
            {
                Console.WriteLine("You try to make the goblin your friend.");
                Console.ReadKey(true);
                Console.WriteLine("Goblins are dumb and thinks you are casting a spell");
                Console.ReadKey(true);
                Console.WriteLine("The goblin gets scared and throws his dagger at you and runs away");
                Console.WriteLine("You take 5 damage");
                Console.ReadKey(true);
                EncounterType();
                // continue to next field
            }
        }

        private static void TripWire()
        {
            Console.Clear();
            Random chance = new Random();
            int success = chance.Next(1, 3);

            Console.WriteLine("There is a trip wire near the ground");
            Console.ReadKey(true);

            if (success == 1)
            {
                Console.WriteLine("You don't even notice it");
                Console.WriteLine("You get a concussion and take 10 damage");
                Console.ReadKey(true);
                EncounterType();
            }
            else if (success == 2)
            {
                Console.WriteLine("You only just notice the wire and manage to break the fall");
                Console.WriteLine("You take 5 damage");
                Console.ReadKey(true);
                EncounterType();
            }
            else
            {
                Console.WriteLine("You notice it easily and skip over it");
                Console.WriteLine("Continue without taking any damage.");
                Console.ReadKey(true);
                EncounterType();
            }
        }

        private static void SpikeTrap()
        {
            Console.Clear();
            Console.WriteLine("You stand at a hallway");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Walk    -     Look Around");
            string input = Console.ReadLine().ToLower().Trim();

            if (input.Contains("walk"))
            {
                Console.WriteLine("You continue walking only to trigger a spike trap in the floor");
                Console.WriteLine("Taking 50 damage");
                Console.ReadKey(true);
                EncounterType();
            }
            else if (input.Contains("look"))
            {
                Console.WriteLine("You look around and notice some holes in the ground");
                Console.ReadKey(true);
                Console.WriteLine("You jump the trap and take no damage.");
                Console.ReadKey(true);
                EncounterType();
            }
        }

        private static void Lucky()
        {
            Console.Clear();
            Console.WriteLine("You find an unknown potion");
            Console.WriteLine("What do you want to do with it?");
            Console.WriteLine("Drink   -   Leave it");
            Random chance = new Random();
            int success = chance.Next(1, 20);

            string input = Console.ReadLine().ToLower().Trim();
            if (input.Contains("drink"))
            {
                if (success == 20)
                {
                    Console.WriteLine("You drink the potion restoring 30 hp.");
                    Console.ReadKey(true);
                    EncounterType();
                }
                else if (success == 1)
                {
                    Console.WriteLine("You drink the potion but it has gone stale.");
                    Console.WriteLine("You take 10 damage");
                    Console.ReadKey(true);
                    EncounterType();
                }
                else
                {
                    Console.WriteLine("You drink the potion restoring 15 hp");
                    Console.ReadKey(true);
                    EncounterType();
                }
            }
        }
    }
}
