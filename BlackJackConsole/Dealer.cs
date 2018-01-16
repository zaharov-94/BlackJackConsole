using BlackJackConsole.Enums;
using System;
using System.Collections.Generic;

namespace BlackJackConsole
{
    internal class Dealer
    {
        private Player _player;
        private Player _computer;
        private CardDesk _cd;
        private Display _display;
        private int _playerWins;
        private int _computerWins;

        public int PlayerWins
        {
            get
            {
                return _playerWins;
            }
        }
        public int ComputerWins
        {
            get
            {
                return _computerWins;
            }
        }

        public Dealer()
        {
            _playerWins = 0;
            _computerWins = 0;
            _display = new Display();
            StartDelivery();
        }

        public int AddCard(Names name)
        {
            if (name == Names.Player)
            {
                _player.TakeCard(_cd.GetCard());
                if (_player.CardSum == Variables.WinCombinatin)
                {
                    _playerWins++;
                    _display.ShowResult(1);
                    ShowCards(true);
                    return 1;
                }
                if (_player.CardSum > Variables.WinCombinatin)
                {
                    _computerWins++;
                    _display.ShowResult(-1);
                    ShowCards(true);
                    return -1;
                }
            }
            if (name == Names.Computer)
            {
                while (_computer.CardSum < 17)
                {
                    _computer.TakeCard(_cd.GetCard());
                }
                if (_computer.CardSum == Variables.WinCombinatin)
                {
                    _computerWins++;
                    _display.ShowResult(-1);
                    ShowCards(true);
                    return -1;
                }
                if (_computer.CardSum > Variables.WinCombinatin)
                {
                    _playerWins++;
                    _display.ShowResult(1);
                    ShowCards(true);
                    return 1;
                }
            }
            return 0;
        }

        public void CalculateResult()
        {
            if (_player.CardSum > _computer.CardSum)
            {
                _display.ShowResult(1);
                _playerWins++;
            }
            if (_player.CardSum < _computer.CardSum)
            {
                _display.ShowResult(-1);
                _computerWins++;
            }
            if (_player.CardSum == _computer.CardSum)
            {
                _display.ShowResult(0);
            }
        }

        public void StartDelivery()
        {
            _cd = new CardDesk();
            _player = new Player(Names.Player, _cd.GetCard());
            _computer = new Player(Names.Computer, _cd.GetCard());
        }

        public void ShowCards(bool final)
        {
            _player.ShowCards();
            if (final) _computer.ShowCards();
        }
    }
}
