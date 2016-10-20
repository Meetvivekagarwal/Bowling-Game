using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
    This class will create instance for alley, associate players to same alley and handles the operation of the bowlng game from reading pins state input to displaying individual scoreboard 
*/

namespace BowlingAlley
{
    class BowlingAlleys
    {
        static void Main(string[] args)
        {


            Alley al = new Alley();
            // Check for multiple players and their information
            Console.WriteLine("How many players want to play? ");
            int numberOfPlayers;

            bool isNumeric = Int32.TryParse(Console.ReadLine(), out numberOfPlayers);
            while(!isNumeric)
            {
                Console.WriteLine("How many players want to play? - only numeric");
                isNumeric = Int32.TryParse(Console.ReadLine(), out numberOfPlayers);
            }

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine("Player Name");
                string name = Console.ReadLine();

                Console.WriteLine("Age");
                int age =Convert.ToInt32(Console.ReadLine());
                al.addPlayers(name,age);

            }

                        
            // Toggling the game among the players based on their turns and displaying the scoreboard for individual players
            for (int i = 0; i <= 20; i++)
            {
                // Rotating game among players in same alley
                foreach (Player player in al.getPlayers())
                {
                    // Check whether player game is over
                    if (player.returnOutput != -1)
                    {
                        // Reading pinstates from console in this case but can we modified to read from hardware API service 
                        Console.Write(player.name + ":: please enter the pins state :");
                        string pins = Console.ReadLine();

                        // Check if pins state contains only up or downs up - 0 and down -1 [ Counting down only to check the score]
                        Match match = Regex.Match(pins, @"[01]+");
                        // check if pattern matches and pins state length is 10 only.
                        while (!match.Success || pins.Length != 10)
                        {
                            Console.WriteLine("Input pin states are invalid - length should be 10 and input should be 1 or 0");
                            Console.Write(player.name + ":: please re-enter the pins state :");
                            pins = Console.ReadLine();
                            match = Regex.Match(pins, @"[01]+");
                        }
                        // Count the score based on number of downs in pins state
                        int score = pins.Count(x => x == '1');
                        //int score = Convert.ToInt32(Console.ReadLine());
                        
                        // Setting the score for individual players
                        int result = player.setScore(score,pins);

                        // Display scoreboard, frame score and total score of users
                        Console.WriteLine("ScoreBoard :: " + player.getScoreBoard());
                        Console.WriteLine("Frame Score :: " + player.getFramesScore());
                        Console.WriteLine("Total score :: " + player.getTotalScore());
                        // Display the message to user based on return from set score method
                        Console.WriteLine((result == -1) ? "Game Over !!!" : (result == 1) ? "Spare !!!" : (result == 2) ? "Strike !!!" : "");
                        Console.WriteLine("------------------");
                      
                    }
                }


            }
           
            Console.ReadLine();


        }
    }

    

}