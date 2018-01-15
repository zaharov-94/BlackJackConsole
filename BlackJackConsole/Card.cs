﻿using BlackJackConsole.Enums;

namespace BlackJackConsole
{
    /// <summary>
    /// Playing card
    /// </summary>
    public class Card
    {
        public Suite Suite { get; set; }
        public Worth Worth { get; set; }
    }
}