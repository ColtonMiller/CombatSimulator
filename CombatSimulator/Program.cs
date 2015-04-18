using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
        //bool values for playing and play again
        static bool playing = true;
        static bool playAgain = true;
        //counter for health of user and enemy
        static int UserHealth = 100;
        static int EnemyHealth = 200;
        //random generators 
        static Random rng = new Random();
        static Random rng2 = new Random();
        //users inital input 
        static string usersInput = string.Empty;
        //valid user responce
        static int validUserInput = 0;
        static void Main(string[] args)
        {
           //start game with startscreen
            StartingScreen();
           //loops through game until playing equals false
            while (playing == true)
            {
                //check if user or dragon is dead
                CheckIfDead();
                //display info
                DisplayStats();
                //makes users input set to console read line
                usersInput = Console.ReadLine();
                //validate userinput
                ValidateUserInput(usersInput);
                //if input is 1 or 2 use Attack function else use heal function
                if (validUserInput == 1 || validUserInput == 2)
                {
                    Attack(validUserInput);
                }
                else if (validUserInput == 3)
                {
                    Heal();
                }
                EnemyAttack();
                //clear screen  to make it look static
                Console.Clear();

            }
        }
        /// <summary>
        /// checks that user input is either 1 2 or 3 
        /// </summary>
        /// <param name="userInput">takes in the string of userInput</param>
        public static void ValidateUserInput (string userInput) 
        {
            //make a switch with 3 cases of input being either 1 2 or 3 else it is an invalid entry
            switch (userInput)
	        {
		        case "1":
                    validUserInput = 1;
                 break;
                case "2":
                    validUserInput = 2;
                 break;
                case "3": 
                    validUserInput = 3;
                 break;
                
                default:
                    Console.WriteLine("Invalid Entry you trip over a rock");
                    System.Threading.Thread.Sleep(1000);
                 break;
	        }
        }
        /// <summary>
        /// Function for the begining of the game
        /// </summary>
        public static void StartingScreen()
        {
            Console.WriteLine("                       Welcome to Combat Simulator Warrior                                ");
            Console.WriteLine("                            press any key to continue                                     ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("   In this game you will fight for your life against a mighty Ice dragon that");
            Console.WriteLine("");
            Console.WriteLine("          can breath fire...I know it makes no sense but just...okay?");
            Console.WriteLine("");
            Console.WriteLine("  I mean really though ice dragon breathing fire thats like terrible evolution");
            Console.WriteLine("");
            Console.WriteLine("      Any way try to just look past that and hit any key to continue....");
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// gives ability info health and tells user to pick 1 2 or 3
        /// </summary>
        public static void DisplayStats()
        {
            Console.WriteLine("1: Is your Sword attack it can hit from 20-35 HP but only has a 70% chance to hit" );
            Console.WriteLine("2: Is your fire ball which actually does damage to the fire breathing ice dragon somehow...anyway it always hit for 10-15 HP");
            Console.WriteLine("3: Is your heal that regenerates 10-20 HP");
            Console.WriteLine("");
            Console.WriteLine("Remember the dragon attacks after you do with an 80% chance to hit for 5-15 HP");
            Console.WriteLine("");
            Console.WriteLine("Your Health: " + UserHealth);
            Console.WriteLine("Dragon's Health: " + EnemyHealth);
            Console.WriteLine("");
            Console.WriteLine("Select your ability by entering 1, 2, or 3");
        }
        /// <summary>
        /// does all the random instances of attacking and aplies to 
        /// </summary>
        /// <param name="number">users validated input</param>
        public static void Attack(int number)
        {
            //checks if attack is sword or fireball
            if (number == 1)
            {
                //attack is sword
                //make random chance to see if hits
                int swordChance = rng.Next(1, 11);
                //if it is 1-7 it hits else it doesn't
                if (swordChance < 8) 
                {
                    //hit
                    //set sword to random number between 20 to 35 take away that much from dragons health
                    int sword = rng.Next(20, 36);
                    EnemyHealth -= sword;
                    Console.WriteLine("Your sword hit and hit the dragon for " + sword);
                    System.Threading.Thread.Sleep(2000);
                }
                else if (swordChance >= 8)
                {
                    //didn't hit
                    Console.WriteLine("Your swing of the sword missed and didn't hurt the dragon");
                    System.Threading.Thread.Sleep(2000);
                }
                //dragons turn to attack
            }
            else
            {
                //attack it fireball
                //set fireball to random number between 10-15 take away that much from dragons health
                int fireball = rng.Next(10, 16);
                EnemyHealth -= fireball;
                Console.WriteLine("You hit the dragon for " + fireball);
                System.Threading.Thread.Sleep(2000);
            }
        }
        /// <summary>
        /// heals user with a max of 100 
        /// </summary>
        public static void Heal()
        {
            //set random number for heal add to user's HP
            int heal = rng.Next(10, 21);
            UserHealth += heal;
            //users health is over 100 set to 100
            if (UserHealth > 100)
            {
                UserHealth = 100;
            }
            Console.WriteLine("You heal for " + heal);
            System.Threading.Thread.Sleep(2000);
        }
        /// <summary>
        /// calculates enemy's attack 
        /// </summary>
        public static void EnemyAttack()
        {
            //set random number for chance
            int hitchance = rng2.Next(1, 11);
            //check if enemy hits or not
            if (hitchance < 9)
            {
                //enemy hit
                //make random for hit between 5-15 take out of userhealth
                int hit = rng2.Next(5, 16);
                UserHealth -= hit;
                Console.WriteLine("Dragon breathes fires and hits you for " + hit);
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                //enemy did not hit
                Console.WriteLine("You dodge the dragon's attack");
                System.Threading.Thread.Sleep(2000);
            }
        }
        public static void CheckIfDead()
        {
            //checks if user is dead
            if (UserHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("You died to a horribly improbably dragon well done!");
                Console.WriteLine("press any key to end the game and continue lossing...");
                Console.ReadKey();
                playing = false;
            }
            //checks if dragon is dead
            else if (EnemyHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("Congradulations you have slain a dragon that probably would have killed itself   either way");
                Console.WriteLine("press any key to end the game...");
                Console.ReadKey();
                playing = false;
            }
        }
    }
}
