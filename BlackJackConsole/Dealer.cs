using BlackJackConsole.Enums;
using System.Linq;

namespace BlackJackConsole
{
    internal class Dealer
    {
        private Player _player;
        private Player _computer;
        private CardDesk _cardDesk;

        public Dealer(Player player, Player computer)
        {
            StartDelivery(player, computer);
        }

        public int AddCard(Names name)
        {
            if (name == Names.Player)
            {
                _player.TakeCard(_cardDesk.GetCard());
            }
            if (name == Names.Computer)
            {
                while (_computer.Cards.Select(x => x.Value).Sum() < Variables.ComputerStopValue)
                {
                    _computer.TakeCard(_cardDesk.GetCard());
                }
                
            }
            return 0;
        }

        public int CalculateResult()
        {
            int playerCardSum = _player.Cards.Select(x => x.Value).Sum();
            int computerCardSum = _computer.Cards.Select(x => x.Value).Sum();

            if (playerCardSum == Variables.WinCombinatin)
            {
                return 1;
            }
            if (playerCardSum > Variables.WinCombinatin)
            {
                return -1;
            }
            if (computerCardSum == Variables.WinCombinatin)
            {
                return -1;
            }
            if (computerCardSum > Variables.WinCombinatin)
            {
                return 1;
            }
            if (playerCardSum > computerCardSum)
            {
                return 1;
            }
            if (playerCardSum < computerCardSum)
            {
                return -1;
            }
            return 0;
        }

        public void StartDelivery(Player player, Player computer)
        {
            _cardDesk = new CardDesk();

            _player = player;
            AddCard(_player.Name);
            _computer = computer;
            AddCard(_computer.Name);
        }
    }
}
