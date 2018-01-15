using System;
using System.Collections.Generic;

namespace BlackJackConsole
{
    public class Dealer
    {
        private List<Card> _cd;
        private int _cardSum;

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

        public Dealer(Card card)
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
            Console.WriteLine("Dealer cards:");
            foreach (Card c in _cd)
            {
                Console.WriteLine(c.Suite + " " + c.Worth);
                _cardSum += (int)c.Worth;
            }
            Console.WriteLine("Dealer cards sum: {0}\n", _cardSum);
        }
    }
}
