using System;
using System.Collections.Generic;
using BlackJackConsole.Enums;

namespace BlackJackConsole
{
    internal class CardDesk
    {
        private List<Card> _desk;
        private Random _rand;

        public CardDesk()
        {
            _desk = new List<Card>(Variables.DeskSize);
            _rand = new Random();
            CreateDesk();
        }

        public Card GetCard()
        {
            int n = _rand.Next(_desk.Count);
            Card card = _desk[n];
            _desk.RemoveAt(n);
            return card;
        }

        private void CreateDesk()
        {
            foreach(Suite s in Enum.GetValues(typeof(Suite)))
            {
                foreach(Worth w in Enum.GetValues(typeof(Worth)))
                {
                    if ((int)w < 10)
                    {
                        _desk.Add(new Card { Suite = s, Worth = w, Value=(int)w+2 });
                    }
                    if ((int)w >= 10)
                    {
                        _desk.Add(new Card { Suite = s, Worth = w, Value = 10 });
                    }
                }
            }
        }
   }
}
