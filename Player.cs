using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
This class will create players profile and calculate and set scoreboard for individual players
*/

namespace BowlingAlley
{
    class Player
    {
        // Encapsulating player name and age properties 
        private string Name;
        private int Age;
        ScoreBoard scoreBoard;
        
        internal int returnOutput = 0;
        
        public string name
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }
        
        // Checking entered age should be between 1 and 100
        public int age
        {
            get
            {
                return Age;
            }

            set
            {
                if (value >= 1 && value <= 100)
                {
                    Age = value;
                }

            }
        }

        // Intialize player information and associate new scoreboard object to the player
        internal Player(string name, int age)
        {

            this.age = age;
            this.name = name;
            scoreBoard = new ScoreBoard();
        }

        // Set the score of the specific player based of pins state
        internal int setScore(int score, string pins)
        {
            returnOutput = scoreBoard.setScore(score,pins);
         
            return returnOutput;
        }
        // Get the pin state score board of individual players
        internal string getScoreBoard()
        {
            return scoreBoard.scoreBoard;
        }
        // Get the individual frame score of the game
        internal string getFramesScore()
        {
            return scoreBoard.frameScore;
        }
        // Get the bowling total score of the player
        internal string getTotalScore()
        {
            return scoreBoard.totalScore.ToString();
        }

    }
}

