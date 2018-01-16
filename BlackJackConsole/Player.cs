using BlackJackConsole.Enums;
using System;
using System.Collections.Generic;

namespace BlackJackConsole
{
    internal class Player
    {
        private List<Card> _cd;
        private Names _name;
        private Dictionary<Worth, int> _weight;
        private int _cardSum;

        public Names Name
        {
            get
            {
                return _name;
            }
        }           
        public int CardSum
        {

            get
            {
                _cardSum = 0;
                foreach (Card c in _cd)
                {
                    _cardSum += _weight[c.Worth];
                }
                return _cardSum;
            }
        }
        public List<Card> Cards
        {
            get
            {
                return _cd;
            }
        }

        public Player(Names name, Card card)
        {
            _name = name;          
            _cd = new List<Card>();
            _weight = new Dictionary<Worth, int>(Variables.WinCombinatin);
            FillWeight();
            _cd.Add(card);
        }

        public void TakeCard(Card card)
        {
            _cd.Add(card);
        }

        private void FillWeight()
        {
            for (Worth w = Worth.two; w <= Worth.Ace; w++)
            {
                _weight.Add(w, (int)w + 2);
            }
            for (Worth w = Worth.Jack; w <= Worth.King; w++)
            {
                _weight.Add(w, 10);
            }

        }
    }
}
