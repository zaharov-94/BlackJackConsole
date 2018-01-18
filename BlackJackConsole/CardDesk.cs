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
            FillDesk();
        }

        public Card GetCard()
        {
            return _desk.Pop();
        }

        public void ShuffleDesk()
        {
            _desk = new Stack<Card>(_desk.OrderBy(x => _rand.Next()));
        }

        private void FillDesk()
        {
            
            foreach (Suite suite in Enum.GetValues(typeof(Suite)))
            {
                foreach(Worth worth in Enum.GetValues(typeof(Worth)))
                {
                    if ((int)worth <= Variables.MaxNotFigureCardsValue)
                    {
                        _desk.Push(new Card { Suite = suite, Worth = worth, Value=(int)worth });
                    }
                    if ((int)worth > Variables.MaxNotFigureCardsValue)
                    {
                        _desk.Push(new Card { Suite = suite, Worth = worth, Value = Variables.FigureCardsValue });
                    }
                }
            }
        }
   }
}
