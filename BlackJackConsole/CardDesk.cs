using System;
using System.Collections.Generic;
using BlackJackConsole.Enums;

namespace BlackJackConsole
{
    internal class CardDesk
    {
        private List<Card> _desk;
        private Random _rand;
        private bool[] _used;

        public CardDesk()
        {
            _desk = new List<Card>(Variables.DeskSize);
            _rand = new Random();
            _used = new bool[Variables.DeskSize];

            for (int i=0; i< Variables.DeskSize; i++)
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
            int n = _rand.Next(Variables.DeskSize);
            while (true)
            {
                if (!_used[n])
                {
                    _used[n] = true;
                    return n;
                }
                if (_used[n])
                {
                    n = _rand.Next(Variables.DeskSize);
                }
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
