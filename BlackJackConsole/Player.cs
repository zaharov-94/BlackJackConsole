using System;
using System.Collections.Generic;

namespace BlackJackConsole
{
    internal class Player
    {
        List<Card> _cd;
        int _cardSum;

        public int CardSum
        {
            get
            {
                _cardSum = 0;
                foreach (Card c in _cd)
                {
                    _cardSum += (int)c.Worth;
                }
                return _cardSum;
            }
        }

        public Player(Card card)
        {
            _cd = new List<Card>();
            _cd.Add(card);
        }

        public void TakeCard(Card card)
        {
            _cd.Add(card);
        }

        public void ShowCards()
        {
            _cardSum = 0;
            Console.WriteLine("Player cards:");
            foreach (Card c in _cd)
            {
                Console.WriteLine(c.Suite + " " + c.Worth);
                _cardSum += (int)c.Worth;
            }
            Console.WriteLine("Player cards sum: {0}\n", _cardSum);
        }
    }
}
