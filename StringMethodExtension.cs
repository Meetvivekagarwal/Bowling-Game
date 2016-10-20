using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
This static class adds extension methods to string primitive data type which will be helpful in processing data with ease.
*/

namespace BowlingAlley
{
    static class StringMethodExtension
    {
        // This Extension method will give all the indexes of key occuring in string 
        internal static IEnumerable<int> allIndexes(this string pins, string searchUps)
        {
            int minIndex = pins.IndexOf(searchUps);
            while (minIndex != -1)
            {
                yield return minIndex+1;
                minIndex = pins.IndexOf(searchUps, minIndex + searchUps.Length);
            }
        }

        // This method will get the pins pattern using pins state
        internal static string getSplitPattern(this string pins)
        {
            string splitPattern = string.Empty;
            IEnumerable<int> allIndexes = pins.allIndexes("0");

            foreach (int index in allIndexes)
            {
                splitPattern += "-" + index;
            }
            return splitPattern;
        }

        // This method will check if pins patterns matches any of the identified one in list
        internal static bool splitPatternMatch(this string pins, List<string> splitPatterns)
        {

            string splitPattern = pins.getSplitPattern();
            if (splitPatterns.IndexOf(splitPattern) != -1)
            {
                return true;
            }

            return false;
        }

        
    }
}
