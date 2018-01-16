using System;
using System.Collections.Generic;
using BlackJackConsole.Enums;

namespace BlackJackConsole
{
    internal class CardDesk
    {
        private List<Card> _desk;
        private Random _rng;
        private bool[] _used;

        
        public CardDesk()
        {
            _desk = new List<Card>(52);
            _rng = new Random();
            _used = new bool[52];

            for (int i=0; i<52; i++)
            {
                _used[i] = false;
            }
            CreateDesk();

        }

        public Card GetCard()
        {
            int number = RandomCardValue();
            return _desk[number];
        }

        private int RandomCardValue()
        {
            int n = _rng.Next(52);
            while (true)
            {
                if (!_used[n])
                {
                    _used[n] = true;
                    return n;
                }
                else n = _rng.Next(52);
            }
        }

        private void CreateDesk()
        {
            foreach(Suite s in Enum.GetValues(typeof(Suite)))
            {
                foreach(Worth w in Enum.GetValues(typeof(Worth)))
                {
                    _desk.Add(new Card { Suite = s, Worth = w});
                }
            }
        }


   }
}
