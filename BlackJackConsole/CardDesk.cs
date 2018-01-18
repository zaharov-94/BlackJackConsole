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

        private void FillDesk() //Убрать цикл в цикле!
        {
            Worth worth = Worth.Two;
            Suite suite = Suite.Clubs;
            //Первый вариант
            //foreach (Suite suite in Enum.GetValues(typeof(Suite)))
            //{
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Two, Value = 2 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Three, Value = 3 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Four, Value = 4 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Five, Value = 5 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Six, Value = 6 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Seven, Value = 7 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Eight, Value = 8 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Nine, Value = 9 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Ten, Value = 10 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Jack, Value = 10 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Queen, Value = 10 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.King, Value = 10 });
            //    _desk.Push(new Card { Suite = suite, Worth = Worth.Ace, Value = 11 });
            //}
            //Второй вариант
            //while ((worth <= Worth.Ace))
            //{
            //    _desk.Push(new Card { Suite = suite, Worth = worth, Value = 2 });
            //    if (suite == Suite.Spades)
            //    {
            //        suite = Suite.Clubs;
            //        worth++;
            //    }
            //    suite++;
            //}
        }
    }
}
