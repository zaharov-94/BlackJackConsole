using System;
using System.Collections.Generic;
using System.Linq;
using BlackJackConsole.Enums;

namespace BlackJackConsole
{
    internal class CardDesk
    {
        private Stack<Card> _desk;
        private Random _rand;

        public CardDesk()
        {
            _desk = new Stack<Card>(Variables.DeskSize);
            _rand = new Random();
            CreateDesk();
        }

        public Card GetCard()
        {
            return _desk.Pop();
        }

        public void ShuffleDesk()
        {
            List<Card> list = new List<Card>();
            list = _desk.OrderBy(x => _rand.Next()).ToList();
            _desk.Clear();
            foreach (Card c in list)
            {
                _desk.Push(c);
            }
        }

        private void CreateDesk()
        {
            
            foreach (Suite s in Enum.GetValues(typeof(Suite)))
            {
                foreach(Worth w in Enum.GetValues(typeof(Worth)))
                {
                    if ((int)w <= Variables.maxNotFigureCardsValue)
                    {
                        _desk.Push(new Card { Suite = s, Worth = w, Value=(int)w });
                    }
                    if ((int)w > Variables.maxNotFigureCardsValue)
                    {
                        _desk.Push(new Card { Suite = s, Worth = w, Value = Variables.figureCardsValue });
                    }
                }
            }
        }
   }
}
