using System;

namespace MazeGame
{
    class Program
    {
        public static int[] playerP = { 2, 3 };
        public static int steps = 0;
        public static int[] stats = { 100, 20 };
        public static int maxSlots = 5;
        public static int[] items = new int [maxSlots];

        static void Main(string[] args)
        {
            GameMenu();
        }

        // Testing area for our codes
        private static void GameMenu()
        {
            Console.WriteLine("Test af forskellige tasks");
            Console.WriteLine("Brug: 1, 2, 3, 4");
            int testInput = int.Parse(Console.ReadLine());

            switch (testInput)
            {
                case 1:
                    {
                        //Inventory

                        break;
                    }
                case 2:
                    {
                        WeirdStranger();
                        break;
                    }
                case 3:
                    {
                        //EncounterType();
                        LeverFun();
                        break;
                    }
                case 4:
                    {
                        Gui();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong input");
                        break;
                    }
            }
        }

        private static void EncounterType()
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
                case int n when (n <= 8 && n >= 2):
                    {
                        Gui();
                        break;
                    }
                case int n when (n <= 12 && n >= 9):
                    {
                        Goblin();
                        break;
                    }
                case int n when (n <= 17 && n >= 13):
                    {
                        TripWire();
                        break;
                    }
                case int n when (n == 19 || n == 18):
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

        // Encounters
        private static void DeathTrap()
        {
            Console.Clear();
            Random chance = new Random();
            int you;

            Console.WriteLine("You stand before a seemingly buttomless pit.");
            Console.WriteLine("What do you do?");
            Console.WriteLine("1. Try jump over \n2. Kill yourself");
            string userInput = Console.ReadLine();

            if (userInput.ToLower().Contains("1"))
            {
                you = chance.Next(1, 100);
                if (you >= 25)
                {
                    Console.WriteLine("You succed jumping over the pit");
                    Console.ReadKey(true);
                    Gui();
                }
                else
                {
                    Console.WriteLine("You fail jumping the pit and fall to your death.");
                    Console.ReadKey(true);
                    Reset();
                }
            }
            else if (userInput.ToLower().Trim().Contains("2"))
            {
                Console.WriteLine("I mean.... sure.. go ahead");
                Console.ReadKey(true);
                Console.WriteLine("Guess you die...");
                Console.ReadKey(true);
                Console.WriteLine("Press enter to start over");
                Console.ReadKey(true);
                Reset();
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
            int chance = rand.Next(1, 21);

            string input;
            Console.WriteLine("You stand before a single goblin");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("");
            Console.WriteLine("1. Attack \n2. Befriend \n3. Run away");
                
            input = Console.ReadLine().ToLower().Trim();
            if (input.Contains("1"))
            {
                Console.WriteLine("You attack the goblin");
                Console.WriteLine("");
                Console.ReadKey(true);

                if (chance == 20)
                {
                    Console.WriteLine("and punch so hard crack his skull open, killing it instantly");
                    Console.ReadKey(true);
                    Gui();
                }
                else if (chance == 1)
                {
                    Console.WriteLine("You charge the goblin but fall to the ground");
                    Console.WriteLine("The goblin start beating you");
                    Console.WriteLine("You take 10 damage");
                    Console.ReadKey(true);
                    stats[0] -= 10;
                    Gui();
                }
                else
                {
                    Console.WriteLine("You attack the goblin with your fist");
                    Console.WriteLine("The goblin gets scared and flees into the darkness");
                    Console.ReadKey(true);
                    Gui();
                }
            }
            else if (input.Contains("3"))
            {
                Console.WriteLine("You can't run dumbass.. You're trapped in a maze..");
                Console.ReadKey(true);
                Goblin();
            }
            else if (input.Contains("2"))
            {
                Console.WriteLine("You try to make the goblin your friend.");
                Console.ReadKey(true);
                Console.WriteLine("Goblins are dumb and thinks you are casting a spell");
                Console.ReadKey(true);
                Console.WriteLine("The goblin gets scared and throws his dagger at you and runs away");
                Console.WriteLine("You take 5 damage");
                stats[0] -= 5;
                Console.ReadKey(true);
                Gui();
            }
            else
            {                Console.WriteLine("Wrong input");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey(true);                Goblin();            }
        }

        private static void TripWire()
        {
            Console.Clear();
            Random chance = new Random();
            int success = chance.Next(1, 4);

            Console.WriteLine("There is a trip wire near the ground");
            Console.ReadKey(true);

            if (success == 1)
            {
                Console.WriteLine("You don't even notice it");
                Console.WriteLine("You get a concussion and take 10 damage");
                stats[0] -= 10;
                Console.ReadKey(true);
                Gui();
            }
            else if (success == 2)
            {
                Console.WriteLine("You only just notice the wire and manage to break the fall");
                Console.WriteLine("You take 5 damage");
                stats[0] -= 5;
                Console.ReadKey(true);
                Gui();
            }
            else
            {
                Console.WriteLine("You notice it easily and skip over it");
                Console.WriteLine("Continue without taking any damage.");
                Console.ReadKey(true);
                Gui();
            }
        }

        private static void SpikeTrap()
        {
            Console.Clear();
            Console.WriteLine("You stand at a hallway");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Walk \n2. Look Around");

            Random chance = new Random();
            int success = chance.Next(1, 21);

            string input = Console.ReadLine().ToLower().Trim();

            if (input.Contains("1"))
            {
                Console.WriteLine("You continue walking only to trigger a spike trap in the floor");
                Console.WriteLine("Taking 50 damage");
                Console.ReadKey(true);
                stats[0] -= 50;
                Gui();
            }
            else if (input.Contains("2"))
            {
                Console.WriteLine("You look around and notice some holes in the ground");
                if (success != 1)
                {
                    Console.ReadKey(true);
                    Console.WriteLine("You jump the trap and take no damage.");
                    Console.ReadKey(true);
                    Gui();
                }
                else
                {
                    Console.WriteLine("You attempt to jump over the trap");
                    Console.ReadKey(true);
                    Console.WriteLine("But you don't get enough speed get your foot impaled");
                    Console.WriteLine("And take 20 damage");
                    Console.ReadKey(true);
                    stats[0] -= 20;
                    Gui();
                }
            }
            else
            {
                Console.WriteLine("Wrong input");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey(true);
                SpikeTrap();
            }
        }

        private static void Lucky()
        {
            Console.Clear();
            Console.WriteLine("You find an unknown potion");
            Console.WriteLine("What do you want to do with it?");
            Console.WriteLine("1. Drink\n2. Leave it");
            
            Random chance = new Random();
            int success = chance.Next(1, 21);

            string input = Console.ReadLine().ToLower().Trim();
            if (input.Contains("1"))
            {
                if (success == 20)
                {
                    Console.WriteLine("You drink the potion ");
                    Console.ReadKey(true);
                    if (stats[0] >= 100)
                    {
                        Console.WriteLine("Your HP can't go higher than 100");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        Console.Write("restoring 30 hp.");
                        stats[0] += 30;
                    }
                    Gui();
                }
                else if (success == 1)
                {
                    Console.WriteLine("You drink the potion but it turns out to be poison.");
                    Console.WriteLine("You take 10 damage");
                    Console.ReadKey(true);
                    stats[0] -= 10;
                    Gui();
                }
                else
                {
                    if (stats[0] >= 100)
                    {
                        Console.WriteLine("Your Hp can't go higher than 100");
                        Console.ReadKey(true);
                        Gui();
                    }
                    else
                    {
                        Console.WriteLine("You drink the potion restoring 15 hp");
                        Console.ReadKey(true);
                        stats[0] += 15;
                        Gui();
                    }
                }
            }
            else if (input.Contains("2"))
            {
                Console.WriteLine("You leave the potion");
                Console.ReadKey(true);
                Gui();
            }
            else
            {
                Console.WriteLine("Wrong input");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey(true);
                Lucky();
            }
        }
        private static void LeverFun()
        {
            Console.Clear();
            Console.WriteLine("You come across an old, almost rotten wooden lever");
            Console.ReadKey(true);
            Console.WriteLine("The tiles on the floor are not like the rest of the maze");
            Console.ReadKey(true);
            Console.WriteLine("What do you do?");
            Console.WriteLine("1. Continue Walking \n2. Pull Lever");
            string input = Console.ReadLine().ToLower().Trim();
            Random chance = new Random();
            int success = chance.Next(1, 21);
            if (input.Contains("1"))
            {
                Console.WriteLine("You walk across the odd looking tiles");
                Console.ReadKey(true);
                if (success == 1)
                {
                    Console.WriteLine("This triggers a hidden trap \nAn arrow flies out of the wall and hits your arm \nYou take 10 damage");
                    Console.ReadKey(true);
                    stats[0] -= 10;
                    Gui();
                }
                else if (success <= 20)
                {
                    Console.WriteLine("Good thing nothing happened");
                    Console.ReadKey(true);
                    Gui();
                }
            }
            else if (input.Contains("2"))
            {
                Console.WriteLine("You pull the lever");
                Console.ReadKey(true);
                if (success == 1)
                {
                    Console.WriteLine("But the slightest touch breaks the lever");
                    Console.ReadKey(true);
                    Console.WriteLine("You continue walking");
                    Console.ReadKey(true);
                    Gui();
                }
                else if (success > 1 && success < 20)
                {
                    Console.WriteLine("You don't notice anything happening \nUntil a stretching arm with a boxing glove hits you hard in the nuts");
                    Console.WriteLine("You take 20 damage and leave your masculinity");
                    Console.ReadKey(true);
                    stats[0] -= 20;
                    Gui();
                }
                else if (success == 20)
                {
                    Console.WriteLine("The lever opens a hidden door");
                    Console.ReadKey(true);
                    Console.WriteLine("Do you want to continue or see what is inside?");
                    Console.WriteLine("1. Walk the Maze \n2. Hidden Room");
                    input = Console.ReadLine().Trim().ToLower();
                    if (input != "1")
                    {
                        WeirdStranger();
                    }
                    else
                    {
                        Gui();
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey(true);
                    LeverFun();
                }            }        }
        static void WeirdStranger()        {            string[] differentItems = { "Potion of Health", "Plague" };            Random rndNumber = new Random();            int i = rndNumber.Next(differentItems.Length);            Console.WriteLine("You have met weird looking stranger. He wants to give you a present.Do you accept it?\n[Y] or [N]");            string input = Console.ReadLine();            if (input.ToLower() == "y")            {                if (differentItems[i] == "Potion of Health")                {                    Console.WriteLine($"You got a {differentItems[i]} and increased your health by 10");                    Console.ReadKey(true);                    if (stats[0] >= 100)
                    {
                        Console.WriteLine("Your HP can't go higher than 100");
                        Console.ReadKey(true);
                        Gui();
                    }                    Gui();                }                else                {                    Console.WriteLine($"You got a {differentItems[i]} and took 20 damage!");                    Console.ReadKey(true);                    stats[0] -= 20;                    Gui();                }            }            else            {                Console.WriteLine("You like playing it safe and move on!");                Console.ReadKey(true);                Gui();            }            //Console.WriteLine("Health: " + health);        }

        // User Interface
        static void GuiDrawLine(int[] Maze, int line)        {            Console.BackgroundColor = ConsoleColor.Gray;            int i = 1 * line * 56 ;            while (i < 1 * line * 56 + 56)            {                //Console.BackgroundColor = Color[2];                //Console.ForegroundColor = Color[1];                //Console.Write(Maze[i + line * 56]);                switch (Maze[i])                {                    case 0:                        {                            //Pathway                            Console.Write(" ");                            break;                        }                    case 1:                        {                            //Border wall                            Console.ForegroundColor = ConsoleColor.DarkRed;                            Console.Write("█");                            Console.ForegroundColor = ConsoleColor.White;                            break;                        }                    case 2:                        {                            //Wall                            Console.ForegroundColor = ConsoleColor.Red;                            Console.Write("▓");                            Console.ForegroundColor = ConsoleColor.White;                            break;                        }
                    case 3:
                        {
                            //Bush
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("*");                            Console.ForegroundColor = ConsoleColor.White;                            break;
                        }
                    case 4:
                        {
                            //Goal
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("░");                            Console.BackgroundColor = ConsoleColor.Gray;                            break;
                        }
                    case 5:                        {
                            //Player
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("¤");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                    case 6:                        {
                            //Lava
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                        }                    default:                        {                            Console.Write(" ");                            break;                        }                }                i += 1;            }            Console.BackgroundColor = ConsoleColor.Black;        }
        static void Gui()        {            int[] Maze = {  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                            1, 0, 0, 2, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 2, 2, 0, 2, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 4, 1,
                            1, 0, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 2, 0, 0, 2, 2, 0, 2, 2, 2, 2, 2, 0, 0, 2, 0, 2, 0, 2, 0, 2, 2, 2, 0, 2, 0, 1,
                            1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 2, 2, 0, 0, 0, 0, 2, 3, 2, 3, 2, 0, 2, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 1,
                            1, 0, 2, 2, 2, 2, 0, 2, 0, 0, 2, 2, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2, 0, 2, 0, 2, 2, 2, 0, 0, 0, 1,
                            1, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 0, 0, 0, 0, 0, 2, 0, 2, 2, 0, 2, 2, 0, 0, 2, 2, 2, 2, 0, 2, 2, 2, 0, 0, 2, 2, 2, 2, 0, 2, 0, 0, 0, 2, 2, 2, 2, 1,
                            1, 0, 0, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 2, 0, 2, 2, 2, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1,
                            1, 2, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 2, 2, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 1,
                            1, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 1,
                            1, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 2, 2, 2, 0, 0, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 0, 2, 0, 2, 0, 2, 1,
                            1, 0, 2, 0, 2, 2, 2, 0, 2, 2, 0, 2, 2, 0, 2, 0, 0, 2, 2, 0, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 2, 2, 0, 2, 1,
                            1, 0, 0, 0, 0, 0, 2, 0, 0, 2, 0, 2, 0, 0, 2, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 2, 2, 2, 0, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 0, 0, 0, 0, 2, 0, 0, 1,
                            1, 0, 2, 2, 2, 0, 2, 2, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 2, 2, 2, 0, 2, 2, 2, 2, 0, 3, 3, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1,
                            1, 0, 0, 0, 2, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 3, 3, 0, 0, 0, 0, 2, 0, 2, 2, 0, 2, 2, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 2, 0, 0, 0, 0, 1,
                            1, 0, 2, 0, 2, 0, 2, 2, 0, 2, 0, 0, 2, 2, 2, 2, 2, 0, 2, 0, 2, 2, 2, 0, 3, 3, 3, 3, 3, 0, 2, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 2, 2, 2, 2, 2, 1,
                            1, 2, 2, 0, 2, 0, 0, 2, 0, 2, 0, 0, 0, 0, 2, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 1,
                            1, 0, 2, 0, 2, 2, 0, 2, 0, 2, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 2, 0, 2, 2, 2, 2, 0, 2, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 2, 2, 2, 1,
                            1, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 2, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 0, 0, 2, 0, 0, 0, 1,
                            1, 0, 2, 2, 2, 2, 0, 2, 0, 2, 2, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 0, 2, 0, 1,
                            1, 0, 2, 0, 0, 0, 0, 2, 0, 0, 2, 0, 2, 0, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 1,
                            1, 0, 2, 0, 2, 2, 2, 2, 2, 0, 0, 0, 2, 0, 2, 0, 6, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 0, 2, 0, 2, 0, 1,
                            1, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 2, 6, 6, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 2, 0, 2, 0, 2, 0, 1,
                            1, 2, 2, 2, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 2, 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 2, 0, 2, 0, 0, 0, 2, 0, 1,
                            1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 0, 0, 2, 2, 0, 2, 0, 2, 0, 0, 0, 0, 2, 2, 2, 2, 0, 2, 0, 2, 3, 2, 3, 2, 0, 2, 0, 0, 2, 0, 2, 2, 2, 0, 2, 2, 2, 0, 0, 2, 0, 2, 2, 2, 0, 1,
                            1, 0, 2, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 2, 2, 0, 2, 0, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 1,
                            1, 0, 2, 0, 2, 0, 2, 0, 0, 0, 2, 0, 2, 0, 2, 2, 2, 2, 0, 2, 2, 0, 2, 0, 0, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 0, 2, 2, 0, 2, 2, 2, 2, 0, 0, 2, 0, 0, 2, 0, 2, 2, 2, 2, 1,
                            1, 0, 2, 0, 0, 0, 2, 0, 2, 2, 2, 0, 2, 0, 2, 2, 2, 2, 0, 2, 2, 0, 0, 0, 2, 0, 2, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 2, 0, 2, 2, 2, 0, 2, 0, 2, 0, 0, 0, 1,
                            1, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 2, 2, 0, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 2, 2, 2, 0, 0, 0, 2, 0, 1,
                            1, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 2, 2, 2, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 1,
                            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                           };
            //1 = ydre mur
            //2 = inder mur
            //3 = busk
            //4 = mål
            //0 = pathway
            if (stats[0] < 1) { Dead(); }
            Console.WriteLine(Maze.Length);
            Maze[(playerP[0] - 1 ) + ((31 - playerP[1]) * 56)] = 5;
            Console.Clear();            GuiDrawLine(Maze, 0); Console.WriteLine("\t\t\t\tHEALTH");            GuiDrawLine(Maze, 1);
            Console.Write("\t[");            int i = 0;            while (i < 51)
            {
                if(i > stats[0]/2)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (stats[0] / 2 < 20)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else if (stats[0] / 2 < 40)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                Console.Write(" ");
                i += 1;

            }            Console.BackgroundColor = ConsoleColor.Black;            Console.Write("]");            Console.WriteLine();            GuiDrawLine(Maze, 2); Console.WriteLine();            GuiDrawLine(Maze, 3); Console.WriteLine("\tLuck\t{0}",stats[1]);            GuiDrawLine(Maze, 4); Console.WriteLine();            GuiDrawLine(Maze, 5); Console.WriteLine();            GuiDrawLine(Maze, 6); Console.WriteLine();            GuiDrawLine(Maze, 7); Console.WriteLine();            GuiDrawLine(Maze, 8); Console.WriteLine();            GuiDrawLine(Maze, 9); Console.WriteLine();            GuiDrawLine(Maze, 10); Console.WriteLine();            GuiDrawLine(Maze, 11); Console.WriteLine();            GuiDrawLine(Maze, 12); Console.WriteLine();            GuiDrawLine(Maze, 13); Console.WriteLine();            GuiDrawLine(Maze, 14); Console.WriteLine();            GuiDrawLine(Maze, 15); Console.WriteLine();            GuiDrawLine(Maze, 16); Console.WriteLine();            GuiDrawLine(Maze, 17); Console.WriteLine();            GuiDrawLine(Maze, 18); Console.WriteLine();            GuiDrawLine(Maze, 19); Console.WriteLine();            GuiDrawLine(Maze, 20); Console.WriteLine();            GuiDrawLine(Maze, 21); Console.WriteLine();            GuiDrawLine(Maze, 22); Console.WriteLine();            GuiDrawLine(Maze, 23); Console.WriteLine();            GuiDrawLine(Maze, 24); Console.WriteLine();            GuiDrawLine(Maze, 25); Console.WriteLine();            GuiDrawLine(Maze, 26); Console.WriteLine();            GuiDrawLine(Maze, 27); Console.WriteLine();            GuiDrawLine(Maze, 28); Console.WriteLine();            GuiDrawLine(Maze, 29); Console.Write("");            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (Maze[(playerP[0] - 1) + ((31 - (playerP[1] + 1)) * 56)] != 1 & Maze[(playerP[0] - 1) + ((31 - (playerP[1] + 1)) * 56)] != 2)
                {
                    if (Maze[(playerP[0] - 1) + ((31 - (playerP[1] + 1)) * 56)] == 6)
                    {
                        playerP[1] += 1;
                        steps += 1;
                        stats[0] -= 5;
                    }
                    else
                    {
                        playerP[1] += 1;
                        steps += 1;
                    }
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (Maze[(playerP[0] - 1) + ((31 - (playerP[1] - 1)) * 56)] != 1 & Maze[(playerP[0] - 1) + ((31 - (playerP[1] - 1)) * 56)] != 2)
                {
                    if (Maze[(playerP[0] - 1) + ((31 - (playerP[1] - 1)) * 56)] == 6)
                    {
                        playerP[1] -= 1;
                        steps += 1;
                        stats[0] -= 5;
                    }
                    else
                    {
                        playerP[1] -= 1;
                        steps += 1;
                    }
                }
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                if (Maze[(playerP[0]) + ((31 - (playerP[1])) * 56)] != 1 & Maze[(playerP[0]) + ((31 - (playerP[1])) * 56)] != 2)
                {
                    if (Maze[(playerP[0]) + ((31 - (playerP[1])) * 56)] == 6)
                    {
                        playerP[0] += 1;
                        steps += 1;
                        stats[0] -= 5;
                    }
                    else
                    {
                        playerP[0] += 1;
                        steps += 1;
                    }
                }
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                if (Maze[(playerP[0] - 2) + ((31 - (playerP[1])) * 56)] != 1 & Maze[(playerP[0] - 2) + ((31 - (playerP[1])) * 56)] != 2)
                {
                    if (Maze[(playerP[0] - 2) + ((31 - (playerP[1])) * 56)] ==6)
                    {
                        playerP[0] -= 1;
                        steps += 1;
                        stats[0] -= 5;
                    }
                    else
                    {
                        playerP[0] -= 1;
                        steps += 1;
                    }
                    
                }
            }
            else if (key.Key == ConsoleKey.Escape)
            {

            }
            else if (key.Key == ConsoleKey.E)
            {
                Inventory();
            }
            else if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar)
            {

            }
            int[] goal = { 55, 30 };
            if (steps == 4)
            {
                steps = 0 - new Random().Next(0, 3);
                EncounterType();
            }
            else if (playerP[0] == goal[0] & playerP[1] == goal[1])
            {
                Win();
            }
            else
            {
                Gui();
            }
        }
        static void Dead()
        {
            Console.Clear();
            Console.WriteLine("You died!!!");
            Console.WriteLine("Press \"ENTER\" to try again");
            Console.ReadLine();
            Reset();
        }

        static void Win()
        {
            Console.Clear();
            Console.WriteLine("You won!!!");
            Console.WriteLine("Press \"ENTER\" to start again");
            Console.ReadLine();
            Reset();
        }
        static void Reset()
        {
            playerP[0] = 2;
            playerP[1] = 2;
            steps = 0;
            stats[0] = 100;
            Gui();
        }

        // Inventory System, Adding an item and removing it 

        static void Inventory()
        {
            CheckItemsInInventory(); 
        }

        //Items and inventory
        static bool AddItem(int itemId)
        {

            for (int i = 0; i < maxSlots; i++)
            {
                //check if slot is empty
                if (items[i] == 0)
                {
                    //add item in empty slot
                    items[i] = itemId;
                    return true;
                }
            }
            //inventory is full
            return false;
        }

        static bool RemoveItem(int itemId)
        {

            for (int i = 0; i < maxSlots; i++)
            {
                //checks each slot for the matching item id  
                if (items[i] == itemId)
                {
                    //remove item from slot
                    items[i] = 0;
                    return true;
                }
            }
            //item doesnt exist in inventory 
            return false;
        }

        
        static void CheckItemsInInventory()
        {
            //List of items in array that'll be printed to the console 

            string[] inventoryItems = { "Potion of Health", "Bag of Holding", "50 Gold Coins" };
            Console.Clear();
            Console.WriteLine(inventoryItems[0]);
            Console.WriteLine(inventoryItems[1]);
            Console.WriteLine(inventoryItems[2]);
            Console.ReadKey();
        }

    }
}

// Problem with win condition applies when standing on position next to. Even with a wall between.
// Maze is HUGE and takes a long time completing.
