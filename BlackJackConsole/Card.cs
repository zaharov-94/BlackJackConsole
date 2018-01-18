using BlackJackConsole.Enums;

namespace BlackJackConsole
{
    /// <summary>
    /// Playing card entity
    /// </summary>
    public class Card
    {
        public Suite Suite
        {
            get;
            set;
        }
        public Worth Worth
        {
            get;
            set;
        }
        public int Value
        {
            get;
            set;
        }
    }
}
