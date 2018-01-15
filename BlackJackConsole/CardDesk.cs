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
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.two });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.three });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.four });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.five });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.six });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.seven });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.eight });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.nine });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.ten });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.Jack });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.Queen });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.King });
            desk.Add(new Card { Suite = Suite.clubs, Worth = Worth.Ace });

            desk.Add(new Card { Suite = Suite.diamonds, Worth = Worth.two });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.three });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.four });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.five });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.six });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.seven });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.eight });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.nine });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.ten });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.Jack });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.Queen });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.King });
            desk.Add(new Card {Suite = Suite.diamonds, Worth = Worth.Ace });

            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.two });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.three });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.four });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.five });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.six });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.seven });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.eight });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.nine });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.ten });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.Jack });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.Queen });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.King });
            desk.Add(new Card { Suite = Suite.hearts, Worth = Worth.Ace });

            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.two });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.three });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.four });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.five });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.six });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.seven });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.eight });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.nine });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.ten });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.Jack });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.Queen });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.King });
            desk.Add(new Card { Suite = Suite.spades, Worth = Worth.Ace });
        }

        public Card GetCard()
        {
            int number = RandomCardValue();
            
            return desk[number];
        }
    }
}
