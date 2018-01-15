using System;

namespace BlackJackConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Hello();
            Play();
            Console.ReadLine();
        }

        static void Hello()
        {
            Console.WriteLine("Hi, Player!");
            Console.WriteLine("Click on some button to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        static void Play()
        {
            Game gm = new Game(); ;
            ConsoleKeyInfo cki;
            Console.WriteLine("Do you want start play? (Y/N)");
            cki = Console.ReadKey();
            Console.Clear();
            while (cki.Key.ToString() == "Y")
            {
                gm.AddCardPlayer();
                gm.ShowCards();
                gm.SubmitCards();
                gm.ShowScore();
                Console.WriteLine("Do you want start play? (Y/N)");
                cki = Console.ReadKey();
                gm.ResetGame();
                Console.Clear();
            }
            gm.ShowScore();
        }

    }
}
