using System;
using System.Collections.Generic;
using System.Linq;
using BlackJackConsole.Enums;

namespace BlackJackConsole
{
    internal class CardDesk
    {
        private Stack<Card> _desk;
        private Random _random;

        public CardDesk()
        {
            _desk = new Stack<Card>(Variables.DeskSize);
            _random = new Random();
            FillDesk();
        }

        public Card GetCard()
        {
            return _desk.Pop();
        }

        public void ShuffleDesk()
        {
            _desk = new Stack<Card>(_desk.OrderBy(x => _random.Next()));
        }

        private void FillDesk()
        {
            Worth worth = Worth.Two;
            Suite suite = Suite.Clubs;

            while (worth <= Worth.Ace)
            {
                _desk.Push(new Card { Suite = suite, Worth = worth, Value = CurrentWorthValue(worth) });
                suite++;
                if (suite == Suite.Spades)
                {
                    _desk.Push(new Card { Suite = suite, Worth = worth, Value = CurrentWorthValue(worth) });
                    worth++;
                    suite = Suite.Clubs;
                }
            }
        }
        
        private int CurrentWorthValue(Worth worth)
        {
            if (worth <= Worth.Nine)
            {
                return (int)worth + Variables.ValueCorrection;
            }
            if (worth == Worth.Ace)
            {
                return  Variables.AceValue;
            }
            return Variables.FaceCardValue;
        }
    }
}
