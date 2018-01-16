using BlackJackConsole.Enums;
using System;

namespace BlackJackConsole
{
    internal class Game
    {
        private Dealer _dealer;
        private Display _display;

        public Game()
        {
            _dealer = new Dealer();
            _display = new Display();
        }

        public void Play()
        {
            _display.Hello();
            while (_display.PlayDialog(true) == Variables.Yes)
            {
                DistributeCards();
                _display.ShowScore(_dealer.PlayerWins, _dealer.ComputerWins);
                ResetGame();
            }
            _display.ShowScore(_dealer.PlayerWins, _dealer.ComputerWins);
            _display.DeleyScreen();
        }

        private void ResetGame()
        {
            _dealer.StartDelivery();
        }

        private void ShowCards(bool finished)
        {
            if(finished)
            {
                _display.ShowCards(Names.Player, _dealer.GetPlayer(Names.Player).Cards);
                _display.ShowSum(_dealer.GetPlayer(Names.Player).CardSum);
                _display.ShowCards(Names.Computer, _dealer.GetPlayer(Names.Computer).Cards);
                _display.ShowSum(_dealer.GetPlayer(Names.Computer).CardSum);
            }
            if (!finished)
            {
                _display.ShowCards(Names.Player, _dealer.GetPlayer(Names.Player).Cards);
                _display.ShowSum(_dealer.GetPlayer(Names.Player).CardSum);
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
                    _dealer.AddCard(Names.Player);
                    ShowCards(false);
                }
                if (d == Variables.Pass)
                {
                    _dealer.AddCard(Names.Computer);
                    result = _dealer.CalculateResult();
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
