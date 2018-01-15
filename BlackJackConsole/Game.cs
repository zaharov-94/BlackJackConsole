using System;

namespace BlackJackConsole
{
    internal class Game
    {
        CardDesk cd;
        Dealer dl;
        Player pl;
        int playerWins;
        int dealerWins;

        public Game()
        {
            cd = new CardDesk();
            dl = new Dealer(cd.GetCard());
            pl = new Player(cd.GetCard());
            playerWins = 0;
            dealerWins = 0;
        }

        public int AddCardPlayer()
        {
            pl.TakeCard(cd.GetCard());
            if (pl.CardSum == 21) { playerWins++; Console.WriteLine("Player Win!\n"); ShowCards(); return 1; }
            if (pl.CardSum > 21) { dealerWins++; Console.WriteLine("Player Lose!\n"); ShowCards(); return -1; }
            return 0;
        }
        public int AddCardDealer()
        {
            while (dl.CardSum < 17)
            {
                dl.TakeCard(cd.GetCard());
            }
            if (dl.CardSum == 21) { dealerWins++; Console.WriteLine("Player Lose!\n"); ShowCards(); return -1; }
            if (dl.CardSum > 21) { playerWins++; Console.WriteLine("Player Win!\n"); ShowCards();  return 1; }
            return 0;
        }

        public void ShowCards()
        {
            dl.ShowCards();
            pl.ShowCards();
        }
        public void ShowScore()
        {
            Console.WriteLine("Score:");
            Console.WriteLine("Player Wins: {0} \nDealer Wins: {1}", playerWins, dealerWins);
        }

        public void CalculateResult()
        {
            if (pl.CardSum > dl.CardSum) { Console.WriteLine("Player Win!\n"); playerWins++; }
            else if (pl.CardSum < dl.CardSum) { Console.WriteLine("Player Lose!\n"); dealerWins++; }
            else { Console.WriteLine("Draw\n"); }

        }

        public void ResetGame()
        {
            cd = new CardDesk();
            dl = new Dealer(cd.GetCard());
            pl = new Player(cd.GetCard());
        }

        public void SubmitCards()
        {
            ConsoleKeyInfo cki;
            while (true)
            {
                Console.WriteLine("Click 'T' to take a card, or 'P' to pass");
                cki = Console.ReadKey();
                Console.Clear();

                if (cki.Key.ToString() == "T")
                {
                    if (AddCardPlayer() == 0)
                    {
                        ShowCards();
                    }
                    else break;
                }
                if (cki.Key.ToString() == "P")
                {
                    if (AddCardDealer() == 0)
                    {
                        CalculateResult();
                        ShowCards();
                    }
                    break;
                }

                if ((cki.Key.ToString() != "P") && (cki.Key.ToString() != "T"))
                {
                    ShowCards();
                }
            }
        }
    }
}
