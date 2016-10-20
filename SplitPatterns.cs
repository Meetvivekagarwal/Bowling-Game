using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
This class provides different split pattern that can happen in a bowling game. Using constructur it loads all the patterns to the generic list of patterns and return that list in loadAllSPlitPatterns method 
*/
namespace BowlingAlley
{
    class SplitPatterns
    {
        static List<string> patterns = new List<string>();

        // Adding unqiue split patterns to the patterns list 
        static SplitPatterns()
        {
            
            patterns.Add("-7-10");
            patterns.Add("-5-7");
            patterns.Add("-5-10");
            patterns.Add("-5-7-10");
            patterns.Add("-3-7");
            patterns.Add("-2-10");
            patterns.Add("-2-7");
            patterns.Add("-3-10");
            patterns.Add("-2-7-10");
            patterns.Add("-3-7-10");
            patterns.Add("-4-6-7-10");
            patterns.Add("-4-6-7-8-10");
            patterns.Add("-4-6-7-9-10");
            patterns.Add("-3-4-6-7-10");
            patterns.Add("-2-4-6-7-10");
            patterns.Add("-2-4-6-7-8-10");
            patterns.Add("-3-4-6-7-9-10");
            patterns.Add("-2-3-4-6-7-10");
            patterns.Add("-4-7-10");
            patterns.Add("-6-7-10");

            
        }

        // Returning patterns list to scoreboard class 
        internal static List<string> loadAllSplitPatterns()
        {
            return patterns;
        }
    }
}
