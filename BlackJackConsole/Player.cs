using BlackJackConsole.Enums;
using System.Collections.Generic;

namespace BlackJackConsole
{
    internal class Player
    {
        public Names Name
        {
            get;
        }      
        
        public List<Card> Cards
        {
            get;
            set;
        }

        public Player(Names name)
        {
            Name = name;
            Cards = new List<Card>();
        }

    }
}
