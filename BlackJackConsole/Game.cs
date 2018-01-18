using BlackJackConsole.Enums;
using System.Linq;

namespace BlackJackConsole
{
    internal class Game
    {
        private Dealer _dealer;
        private Display _display;
        private Player _player;
        private Player _computer;

        private int _playerWins;
        private int _computerWins;

        public Game()
        {
            _playerWins = 0;
            _computerWins = 0;
            _player = new Player(Names.Player);
            _computer = new Player(Names.Computer);
            _dealer = new Dealer(_player, _computer);
            _display = new Display();
        }

        public void PlayGame()
        {
            _display.Hello();
            while (_display.PlayDialog(true) == Variables.Yes)
            {
                ShowCards(false);
                PlayRound();
                _display.ShowScore(_playerWins, _computerWins);
                ResetGame();
            }
            _display.ShowScore(_playerWins, _computerWins);
            _display.DelayScreen();
        }

        private void ResetGame()
        {
            _player.Cards.Clear();
            _computer.Cards.Clear();
            _dealer.StartDelivery(_player, _computer);
        }

        private void ShowCards(bool finished)
        {
            _display.ShowCards(Names.Player, _player.Cards);
            _display.ShowSum(_player.Cards.Select(x => x.Value).Sum());
            if (finished)
            {
                _display.ShowCards(Names.Computer, _computer.Cards);
                _display.ShowSum(_computer.Cards.Select(x => x.Value).Sum());
            }
        }

        private void ShowResult()
        {
            int result = _dealer.CalculateResult(_player, _computer);
            ChangeStatistic(result);
            _display.ShowResult(result);
        }

        private void ChangeStatistic(int result)
        {
            if (result == 1)
            {
                _playerWins++;
            }
            if (result == -1)
            {
                _computerWins++;
            }
        }

        private void PlayRound()
        {
            char playerResponse = Variables.Take;

            while (playerResponse != Variables.Pass)
            {
                playerResponse = _display.PlayDialog(false);
                if (playerResponse == Variables.Take)
                {
                    _dealer.AddCard(_player);
                }
                if (playerResponse == Variables.Pass)
                {
                    _dealer.AddCard(_computer);
                    ShowResult();
                    break;
                }
                ShowCards(false);
            }
            ShowCards(true);
        }
    }
}
