using BlackJackConsole.Enums;

namespace BlackJackConsole
{
    internal class Dealer
    {
        private Player _player;
        private Player _computer;
        private CardDesk _cd;
        private int _playerWins;
        private int _computerWins;
        private Display _display = new Display();

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
            StartDelivery();
        }

        public int AddCard(Names name)
        {
            if (name == Names.Player)
            {
                _player.TakeCard(_cd.GetCard());
            }
            if (name == Names.Computer)
            {
                while (_computer.CardSum < 17)
                {
                    _computer.TakeCard(_cd.GetCard());
                }
                
            }
            return 0;
        }

        public int CalculateResult()
        {
            if (_player.CardSum == Variables.WinCombinatin)
            {
                _playerWins++;
                return 1;
            }
            if (_player.CardSum > Variables.WinCombinatin)
            {
                _computerWins++;
                return -1;
            }
            if (_computer.CardSum == Variables.WinCombinatin)
            {
                _computerWins++;
                return -1;
            }
            if (_computer.CardSum > Variables.WinCombinatin)
            {
                _playerWins++;
                return 1;
            }
            if (_player.CardSum > _computer.CardSum)
            {
                _playerWins++;
                return 1;
            }
            if (_player.CardSum < _computer.CardSum)
            {
                _computerWins++;
                return -1;
            }
            return 0;
        }

        public void StartDelivery()
        {
            _cd = new CardDesk();
            _player = new Player(Names.Player, _cd.GetCard());
            _computer = new Player(Names.Computer, _cd.GetCard());
        }

        public Player GetPlayer(Names name)
        {
            if (name == Names.Player) return _player;
            return _computer;
        }
    }
}
