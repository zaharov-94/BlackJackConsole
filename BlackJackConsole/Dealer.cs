using BlackJackConsole.Enums;
using System.Linq;

namespace BlackJackConsole
{
    internal class Dealer
    {
        private CardDesk _cardDesk;

        public Dealer(Player player, Player computer)
        {
            StartDelivery(player, computer);
        }

        public void AddCard(Player player)
        {
            if (player.Name == Names.Player)
            {
                player.Cards.Add(_cardDesk.GetCard());
            }
            if (player.Name == Names.Computer)
            {
                TakeComputerCards(player);
            }
        }

        public int CalculateResult(Player player, Player computer)
        {
            int playerCardSum = player.Cards.Select(x => x.Value).Sum();
            int computerCardSum = computer.Cards.Select(x => x.Value).Sum();

            if ((playerCardSum > Variables.WinCombinatin) || (computerCardSum == Variables.WinCombinatin))
            {
                return -1;
            }

            if ((playerCardSum == Variables.WinCombinatin) || (computerCardSum > Variables.WinCombinatin))
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
            _cardDesk.ShuffleDesk();
            AddCard(player);
            AddCard(computer);
        }

        private void TakeComputerCards(Player player)
        {
            int cardSum = player.Cards.Select(x => x.Value).Sum();
            while (cardSum < Variables.ComputerStopValue)
            {
                player.Cards.Add(_cardDesk.GetCard());
                cardSum = player.Cards.Select(x => x.Value).Sum();
            }
        }
    }
}
