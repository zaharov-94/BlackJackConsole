using BlackJackConsole.Enums;
using System;
using System.Collections.Generic;

namespace BlackJackConsole
{
    public class Display
    {
        
        public void ShowResult(Results result)
        {
            if (result == Results.Win)
            {
                Console.WriteLine("Player Won!\n");
                return;
            }
            if (result == Results.Lose)
            {
                Console.WriteLine("Player Lose!\n");
                return;
            }
            if (result == Results.Draw)
            {
                Console.WriteLine("Draw!\n");
            }
        }
        
        public void ShowCards(Names name, List<Card> listCards)
        {
            Console.WriteLine("{0} cards: ", name);
            foreach (Card card in listCards)
            {
                Console.WriteLine(card.Suite + " " + card.Worth);
            }
         }

        public void ShowSum(int sum)
        {
            Console.WriteLine("Cards sum: {0}\n", sum);
        }

        public void ShowScore(int playerWins, int computerWins)
        {
            Console.WriteLine("Score:");
            Console.WriteLine("Player Wins: {0} \nComputer Wins: {1}\n", playerWins, computerWins);
        }

        public void ShowHelloMessage()
        {
            Console.WriteLine("Hi, Player!");
            Console.WriteLine("Click on some button to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public char PlayDialog(bool isStartDialog)//Переименовать
        {
            ConsoleKeyInfo consoleKeyInfo;
            if (isStartDialog)
            {
                Console.WriteLine("Do you want start play? (Y/N)\n");
            }
            if (!isStartDialog)
            {
                Console.WriteLine("Click 'T' to take a card, or 'P' to pass\n");
            }
            consoleKeyInfo = Console.ReadKey();
            Console.Clear();
            return char.Parse(consoleKeyInfo.Key.ToString());
        }

        public void DelayScreen()
        {
            Console.ReadLine();
        }
    }
}
