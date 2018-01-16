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

        private void ShowCards(bool finished)
        {
            if(finished)
            {
                _display.ShowCards(Names.Player, _dl.GetPlayer(Names.Player).Cards);
                _display.ShowSum(_dl.GetPlayer(Names.Player).CardSum);
                _display.ShowCards(Names.Computer, _dl.GetPlayer(Names.Computer).Cards);
                _display.ShowSum(_dl.GetPlayer(Names.Computer).CardSum);
            }
            if (!finished)
            {
                _display.ShowCards(Names.Player, _dl.GetPlayer(Names.Player).Cards);
                _display.ShowSum(_dl.GetPlayer(Names.Player).CardSum);
            }

        }

        private void DistributeCards()
        {
            char d;
            int result;
            ShowCards(false);
            while (true)
            {
                d = _display.PlayDialog(false);
                if (d == Variables.Take)
                {
                    _dl.AddCard(Names.Player);
                    ShowCards(false);
                }
                if (d == Variables.Pass)
                {
                    _dl.AddCard(Names.Computer);
                    result = _dl.CalculateResult();
                    _display.ShowResult(result);
                    ShowCards(true);
                    break;
                }
                if ((d != Variables.Pass) && (d != Variables.Take))
                {
                    ShowCards(false);
                }

            }
        }
    }
}
