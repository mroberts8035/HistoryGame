using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enemies;
using HistoryLibrary;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dungeon Application";
            Console.WriteLine("Start your adventures now...\n");

            int score = 0;

            Weapon sword = new Weapon(1, 3, "Short Sword", 10);
            Weapon spear = new Weapon(2, 5, "Short Spear", 15);
            Weapon gladius = new Weapon(3, 7, "Roman Gladius", 20);


            Console.Write("Enter the players name: ");
            string userName = Console.ReadLine();

            Weapon playerWeapon = new Weapon();


            Console.Write("\nPlease select a weapon from the options below:\n" +
                "1) Sword\n" +
                "2) Spear\n" +
                "3) Gladius\n");


            ConsoleKey playerChoice = Console.ReadKey(true).Key;
            switch (playerChoice)
            {
                case ConsoleKey.D1:
                    playerWeapon = sword;
                    break;
                case ConsoleKey.D2:
                    playerWeapon = spear;
                    break;
                case ConsoleKey.D3:
                    playerWeapon = gladius;
                    break;
                default:
                    Console.WriteLine("Please chose one of the numbers listed!");
                    break;
            }

            Player player = new Player(userName, 65, 35, 40, 40, playerWeapon);
            Console.Clear();

            #region Arena Loop

            bool adventure = true;

            do
            {


                Console.WriteLine(ShowArena());


                TrainingDummy trainingDummy = new TrainingDummy();
                Student student = new Student();
                Apprentice apprentice = new Apprentice("Warrior Apprentice", 12, 12, 35, 20, "An apprentice skilled in combat!", sword);
                Apprentice soldier = new Apprentice("Seasoned Soldier", 24, 24, 40, 25, "A soldier battle hardened!", spear);
                Apprentice gladiator = new Apprentice("Gladiator", 36, 36, 45, 30, "A fearsome Gladiator who looks like he has multiple kills under his belt!", gladius);

                Opponent[] opponents = { trainingDummy, student, apprentice, soldier, gladiator };
                Random rand = new Random();
                int randomNbr = rand.Next(opponents.Length);
                Opponent challenger = opponents[randomNbr];

                Console.WriteLine("\nHere you see standing before you a {0}", challenger.Name);

                #region Battle

                bool battle = true;

                do
                {
                    //Menu for player actions

                    Console.Write("\nPlease choose your action:\n" +
                        "B) Battle\n" +
                        "S) Surrender\n" +
                        "P) Player Info\n" +
                        "O) Opponent Info\n" +
                        "X) End Game\n\n");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.B:

                            Combat.DoBattle(player, challenger);

                            if (challenger.Life <= 0)
                            {
                                Console.WriteLine("\nYou Defeated {0}!\n", challenger.Name);
                                battle = false;
                                score++;
                            }

                            break;
                        case ConsoleKey.S:
                            Console.WriteLine("Bow down in submission to the opponent and beg for thier mercy");

                            Console.WriteLine("{0} makes an example of your sumbission", challenger.Name);
                            Combat.DoAttack(challenger, player);
                            battle = false;
                            break;
                        case ConsoleKey.P:

                            Console.WriteLine("{0}'s Stats:\n", player.Name);
                            Console.WriteLine(player);
                            Console.WriteLine("Opponents Defeated " + score);
                            break;
                        case ConsoleKey.O:

                            Console.WriteLine("{0}'s Stats:\n", challenger.Name);
                            Console.WriteLine(challenger);

                            break;
                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            Console.WriteLine("So you have decided that this isn't the life for you. The training is too hard?");
                            adventure = false;
                            break;
                        default:
                            Console.WriteLine("If you cannot follow basic instructions how do you expect to pass your training?");
                            break;
                    }//end switch

                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("YOU HAVE DIED A WARRIORS DEATH!!!!");
                        Console.ResetColor();
                        adventure = false;
                    }


                } while (battle && adventure);

                #endregion

            } while (adventure);

            #endregion


            Console.WriteLine("You defeated " + score + " opponent" + ((score == 1) ? "." : "s."));

        }//end main

        private static string ShowArena()
        {
            string[] arenas =
            {
                "You find yourself in an open room. The floors, walls, and ceilings remind you of anchient Japan. Have you been transported through time? Is this real or just a test?",
                "Now you find yourself out in an open field. The grass is green and there are slight rolling hills. There is a forest line in the distance.",
                "You start to blink as you adjust to your surroundings. There are strange marks on the floor and a loud roar coming from the sides. You realize you are in some type of gym with a crowd watching.",
                "What happened now? How do we keep changing location? This is all so confusing. Now we seem to be in a forest next to a river. The sound of a waterfall is off in the distance and it is kind of distracting.",
                "The blinding bright light?! The deafenign sounds of a crowd?! The dusty ground?! The stone walls?! Can it be? Is this the famous Roman Collosseum?"
            }; //end string array
            Random rand = new Random();

            int a = rand.Next(arenas.Length);
            string arena = arenas[a];

            return arena;

        }//end ShowArena

    }//end class
}
