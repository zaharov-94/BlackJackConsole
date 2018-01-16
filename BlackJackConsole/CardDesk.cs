using System;
using System.Collections.Generic;
using BlackJackConsole.Enums;

namespace BlackJackConsole
{
    public class CardDesk
    {
        private List<Card> _desk;
        private Random _rng;
        private bool[] _used;
        private Dictionary<Worth, int> _weight;
        
        public CardDesk()
        {
            _desk = new List<Card>(52);
            _rng = new Random();
            _used = new bool[52];
            _weight = new Dictionary<Worth, int>(52);
            for (int i=0; i<52; i++)
            { _used[i] = false; }
            CreateDesk();
            FillWeight();
        }

        public Card GetCard()
        {
            int number = RandomCardValue();
            //foreach (var card in _desk)
            //    Console.WriteLine(card.Suite + " " + card.Worth);
            return _desk[number];
        }

        public int GetWeight(Worth w)
        {
            return _weight[w];
        }

        private int RandomCardValue()
        {
            int n = _rng.Next(52);
            while (true)
            {
                if (!_used[n]) { _used[n] = true; return n; }
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

        private void FillWeight ()
        {
            for(Worth w = Worth.two; w<=Worth.Ace; w++)
            {
                _weight.Add(w, (int)w+2);
            }
            for (Worth w = Worth.Jack; w <= Worth.King; w++)
            {
                _weight.Add(w, 10);
            }

        }
   }
}
