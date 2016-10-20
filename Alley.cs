using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 This class instantiate Alley for the game and associate multiple players who will play in same bowling alley 
*/

namespace BowlingAlley
{
    class Alley
    {

        List<Player> players = new List<Player>();

        // Associating multiple players to same alley 
        internal void addPlayers(string name, int age)
        {
            players.Add(new Player(name, age));
        }

        // To get the list of players
        internal List<Player> getPlayers()
        {
            return players;
        }

    }
}
