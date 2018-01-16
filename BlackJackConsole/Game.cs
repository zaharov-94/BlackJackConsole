using BlackJackConsole.Enums;
using System;

namespace BlackJackConsole
{
    internal class Game
    {
        private Dealer _dl;

        public Game()
        {
            _dl = new Dealer();
        }

        public void ShowScore()
        {
            Console.WriteLine("\nScore:");
            Console.WriteLine("Player Wins: {0} \nComputer Wins: {1}", _dl.PlayerWins, _dl.ComputerWins);
        }
 
        public void ResetGame()
        {
            _dl.StartDelivery();
        }

        public void DistributeCards()
        {
            ConsoleKeyInfo cki;
            while (true)
            {
                Console.Clear();
                _dl.ShowCards(false);
                Console.WriteLine("\nClick 'T' to take a card, or 'P' to pass");
                cki = Console.ReadKey();
                Console.Clear();

                if (cki.Key.ToString() == "T")
                {
                    if (_dl.AddCard(Names.Player) == 0)
                    {
                        _dl.ShowCards(false);
                    }
                    else break;
                }
                if (cki.Key.ToString() == "P")
                {
                    if (_dl.AddCard(Names.Computer) == 0)
                    {
                        _dl.CalculateResult();
                        _dl.ShowCards(true);
                    }
                    break;
                }
                if ((cki.Key.ToString() != "P") && (cki.Key.ToString() != "T"))
                {
                    _dl.ShowCards(false);
                }
            }
        }
    }
}
