using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
This class create bowling board for individual players and provide method to set & get total score and to check the split in the pins state
*/

namespace BowlingAlley
{
    class ScoreBoard
    {
        int[] board = new int[25];
        internal string scoreBoard = string.Empty;
        internal string frameScore = string.Empty;
        internal int totalScore = 0;
        internal int returnOutput = 0;
        List<string> splitPatterns;
        int turn = 0;
        List<int> framesScore = new List<int>();

        // Initialize board and split patterns for individual players
        internal ScoreBoard()
        {
            for (int i = 0; i <= 24; i++)
            {
                board[i] = -1;
            }
            splitPatterns = SplitPatterns.loadAllSplitPatterns();
        }

        // To get total score of individual players
        internal List<int> getTotalScore()
        {
            int sum = 0;
            framesScore = new List<int>();
            int i = 0;
            // This bool variable to check whether we need to wait for next bowl to calculate score [ Strike / Spare]
            bool canCalculate = true;

            // Check only player active bowling board
            while (board[i] != -1)
            {
                             
                // If strike then add next frame/frames skipping the next round of same frame
                if (board[i].Equals(10))
                {
                    //If it's last frame then check for next round of same frame else next frame/frames
                    sum += StrikeORSpareCalculation((i < 18) ? i + 2 : i + 1, 2, ref canCalculate);
                    sum += 10;
                    i = i + 2;
                }
                // If spare then add next one frame/shot based on it's value
                else if (i % 2 == 0 && (board[i] + board[i + 1] == 10))
                {

                    sum += StrikeORSpareCalculation(i + 2, 1, ref canCalculate);
                    sum += 10;
                    i = i + 2;

                }
                // else just add the score
                else
                {

                    sum += board[i++];
                   

                }

                // If we can't calculate total score of spare or strike then wait for next rounds
                if (!canCalculate)

                {
                    break;
                }
                // else add the individual frame score to list
                else if (i > 0 && i % 2 == 0)
                {
                    framesScore.Add(sum);
                    sum = 0;
                }


            }


            return framesScore;
        }

        // To calculate total score and create frames score string to display
        internal void calculateScore()
        {
            frameScore = string.Empty;
            totalScore = 0;
            foreach (int frmscore in framesScore)
            {
                totalScore += frmscore;
                frameScore += frmscore.ToString() + "\t";
            }
        }

        // Set the score on the board based on input pins state & check for split patterns
        // To display message to player - return 2- Strike, 1- Spare, -1 - Game over
        internal int setScore(int score, string pins)
        {
            returnOutput = 0;
            // If strike then leave the next slot of frame as blank
            if (score == 10)
            {
                board[turn++] = score;
                // If it's not last frame then only leave next slot as blank
                if (turn < 18)
                {
                    board[turn++] = 0;
                }

                returnOutput = 2;
            }
            else
            {

                board[turn] = score;
                // if frame total is 10 then player hits the spare
                if (turn % 2 != 0 && score + board[turn - 1] == 10)
                {
                    returnOutput = 1;
                }
                turn++;


            }

            // Check for game over & if extra 13th slot is needed
            if (turn-1 == 20 || (turn-1 == 19 && (board[turn-1] + board[turn - 2] < 10)))
            {
                returnOutput = -1;
            }

            // Check for split pattern in pins state only for first round of frame
            bool isSplit = pins.splitPatternMatch(splitPatterns);
            // calculate total score, frame score and build scoreboard for individual players
            getTotalScore();
            calculateScore();
            getScoreBoard(isSplit);
            return returnOutput;
        }

        // To calculate framescore for strike or spare & indicate if needed to wait for next rounds for calculation
        internal int StrikeORSpareCalculation(int index, int count, ref bool canCalculate)
        {
            int sum = 0;
            // Count -2 for strike and 1 for spare
            while (count > 0)
            {
                // If seeking frame is empty then signal wait for next rounds
                if (board[index] == -1)
                {
                    canCalculate = false;
                    break;
                }
                // If seeking frame has strike then look for next frame
                if (board[index].Equals(10))
                {
                    sum += board[index];
                    // Checking for last frame calculation
                    index = (index < 18) ? index + 2 : index + 1;

                }
                // else simply add next frame score 
                else
                {
                    sum += board[index++];

                }
                count--;

            }
            return sum;
        }

        // To get customized scoreboard for player based on board values & append S-Split if matches
        internal string getScoreBoard(bool splitPatternMatch)
        {
            scoreBoard = string.Empty;
            int i = 0;
            // Considering only active board score
            while (board[i] != -1)
            {
                // Add tab space between two frames
                if (i % 2 == 0 & i<=18)
                {
                    scoreBoard += "\t";
                }
                // If strike then adding symbol to represent it
                if (board[i] == 10)
                {
                    scoreBoard += "X]";

                }
                // else check for spare and add split (S) if pattern matches
                else if (i % 2 == 0 && (board[i] + board[i + 1] == 10))
                {
                    scoreBoard += (splitPatternMatch) ? "S "+ board[i].ToString() + "]/]": board[i].ToString() + "]/]";
                    i++;
                }
                // Add symbol for 0 score only if the previous one was not strike
                else if (board[i] == 0)
                {
                    if (i == 0 || board[i - 1] != 10)
                    {
                        scoreBoard += "-]";
                    }

                }
                // Add score to board and append Split (S) if pattern matches
                else if(board[i] != 0)
                {
                    scoreBoard += (splitPatternMatch && i%2 ==0) ? "S " + board[i].ToString() + "]": board[i].ToString() + "]";

                }
                i++;
            }

            return scoreBoard;
        }

                
    }
}
