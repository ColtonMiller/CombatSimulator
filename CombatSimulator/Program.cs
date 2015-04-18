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
        bool playing = true;
        bool playAgain = true;
        //counter for health of user and enemy
        int UserHealth = 100;
        int EnemyHealth = 200;
        //random generators 
        Random rng = new Random();
        Random rng2 = new Random();
        //users inital input 
        string usersInput = string.Empty;
        static int intUserInput = 0;
        //valid user responce
        static int validUserInput = 0;
        static void Main(string[] args)
        {
        }
        public static void ValidateUserInput (string userInput) 
        {
           int.TryParse(userInput, out intUserInput);
            switch (intUserInput)
	        {
		        case 1:
                    validUserInput = 1;
                 break;
                case 2:
                    validUserInput = 2;
                 break;
                case 3: 
                    validUserInput = 3;
                 break;
                
                default:
                    Console.WriteLine("Invalid Entry");
                 break;
	        }
        }
    }
}
