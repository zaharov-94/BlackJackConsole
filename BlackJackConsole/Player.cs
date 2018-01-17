using BlackJackConsole.Enums;
using System;
using System.Collections.Generic;

namespace BlackJackConsole
{
    internal class Player
    {
        private List<Card> _cards;
        private Names _name;

        public Names Name
        {
            get
            {
                return _name;
            }
        }           

        public List<Card> Cards
        {
            get
            {
                return _cards;
            }
        }

        public Player(Names name)
        {
            _name = name;          
            _cards = new List<Card>();
        }

        public void TakeCard(Card card)
        {
            _cards.Add(card);
        }

    }
}
