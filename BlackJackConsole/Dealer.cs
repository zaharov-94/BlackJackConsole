using BlackJackConsole.Enums;
using System.Linq;

namespace BlackJackConsole
{
    internal class Dealer
    {
        private CardDesk _cardDesk;

        public Dealer(Player player, Player computer)
        {
            DistributeCards(player, computer);
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

        public Results CalculateResult(Player player, Player computer, bool isPlayerPassed)
        {
            int playerCardSum = player.Cards.Select(x => x.Value).Sum();
            int computerCardSum = computer.Cards.Select(x => x.Value).Sum();

            if ((playerCardSum > Variables.WinCombination) || (computerCardSum == Variables.WinCombination))
            {
                return Results.Lose;
            }

            if ((playerCardSum == Variables.WinCombination) || (computerCardSum > Variables.WinCombination))
            {
                return Results.Win;
            }
            
            if (isPlayerPassed && (playerCardSum > computerCardSum))
            {
                return Results.Win;
            }
            if (isPlayerPassed && (playerCardSum < computerCardSum))
            {
                return Results.Lose;
            }
            if (isPlayerPassed && (playerCardSum == computerCardSum))
            {
                return Results.Draw;
            }

            return Results.NoResult;
        }

        public void DistributeCards(Player player, Player computer)
        {
            _cardDesk = new CardDesk();
            _cardDesk.ShuffleDesk();
            player.Cards.Add(_cardDesk.GetCard());
            computer.Cards.Add(_cardDesk.GetCard());
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
