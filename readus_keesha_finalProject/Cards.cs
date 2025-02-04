﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readus_keesha_finalProject
{
    public class Cards
    {
        public enum CardSuits
        {
            Hearts = 1,
            Clubs = 2,
            Diamonds = 3,
            Spades = 4

        }

        public enum CardValues
        {

            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

        public CardSuits Suit { get; set; }
        public CardValues Value { get; set; }







        public Cards(CardSuits suits, CardValues values)
        {
            Suit = suits;
            Value = values;

        }


        public override string ToString()
        {
            return Value.ToString() + " of " + Suit.ToString();
        }
    }
}
