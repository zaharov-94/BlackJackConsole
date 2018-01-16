using BlackJackConsole.Enums;
using System;
using System.Collections.Generic;

namespace BlackJackConsole
{
    public class Display
    {
        
        public void ShowResult(int winner)
        {
            if (winner == 1)
            {
                Console.WriteLine("Player Win!\n");
            }
            if (winner == -1)
            {
                Console.WriteLine("Player Lose!\n");
            }
            if (winner == 0)
            {
                Console.WriteLine("Draw!\n");
            }
        }
        
        public void ShowCards(Names name, List<Card> listCards)
        {
            Console.WriteLine("{0} cards: ", name);
            foreach (Card c in listCards)
            {
                Console.WriteLine(c.Suite + " " + c.Worth);
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

        public void Hello()
        {
            Console.WriteLine("Hi, Player!");
            Console.WriteLine("Click on some button to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public char PlayDialog(bool startDialog)
        {
            ConsoleKeyInfo cki;
            if (startDialog)
            {
                Console.WriteLine("Do you want start play? (Y/N)\n");
            }
            if (!startDialog)
            {
                Console.WriteLine("Click 'T' to take a card, or 'P' to pass\n");
            }
            cki = Console.ReadKey();
            Console.Clear();
            return char.Parse(cki.Key.ToString());
        }

        public void DeleyScreen()
        {
            Console.ReadLine();
        }
    }
}
