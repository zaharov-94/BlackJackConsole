using BlackJackConsole.Enums;
using System;

namespace BlackJackConsole
{
    internal class Game
    {
        private Dealer _dl;
        private Display _display;

        public Game()
        {
            _dl = new Dealer();
            _display = new Display();
        }

        public void Play()
        {
            _display.Hello();
            while (_display.PlayDialog(true) == Variables.Yes)
            {
                DistributeCards();
                _display.ShowScore(_dl.PlayerWins, _dl.ComputerWins);
                ResetGame();
            }
            _display.ShowScore(_dl.PlayerWins, _dl.ComputerWins);
            _display.DeleyScreen();
        }

        private void ResetGame()
        {
            _dl.StartDelivery();
        }

        private void DistributeCards()
        {
            char d;
            _dl.ShowCards(false);
            while (true)
            {
                d = _display.PlayDialog(false);
                if (d == Variables.Take)
                {
                    if (_dl.AddCard(Names.Player) == 0)
                    {
                        _dl.ShowCards(false);
                    }
                    else break;
                }
                if (d == Variables.Pass)
                {
                    if (_dl.AddCard(Names.Computer) == 0)
                    {
                        _dl.CalculateResult();
                        _dl.ShowCards(true);
                    }
                    break;
                }
                if ((d != Variables.Pass) && (d != Variables.Take))
                {
                    _dl.ShowCards(false);
                }
            }
        }
    }
}
