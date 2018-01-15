using System;
using System.Collections.Generic;
using BlackJackConsole.Enums;

namespace BlackJackConsole
{
    public class CardDesk
    {
        List<Card> desk;
        Random rng;
        bool[] used;

        public CardDesk()
        {
            desk = new List<Card>(52);
            rng = new Random();
            used = new bool[52];
            for(int i=0; i<52; i++)
            { used[i] = false; }
            CreateDesk();
        }

        int RandomCardValue()
        {
            int n = rng.Next(52);
            while (true)
            {
                if (!used[n]) { used[n] = true; return n; }
                else n = rng.Next(52);
            }
        }

        void CreateDesk()
        {
            foreach(Suite s in Enum.GetValues(typeof(Suite)))
            {
                foreach(Worth w in Enum.GetValues(typeof(Worth)))
                {
                    desk.Add(new Card { Suite = s, Worth = w});
                }
            }
        }

        public Card GetCard()
        {
            int number = RandomCardValue();
            foreach (var card in desk)
                Console.WriteLine(card.Suite+" "+card.Worth);
            return desk[number];
        }
    }
}
