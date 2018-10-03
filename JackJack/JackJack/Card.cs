using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackJack
{
    class Card
    {
        public int Value { get; set; }
        public SuitType Suit { get; set; }
        public int BlackJackValue { get; set; }

        public Card(int value, SuitType suit)
        {
            Value = value;
            Suit = suit;
            BlackJackValue = Value; 
        }

        public override string ToString()
        {
            char suitChar = Suit.ToString().ToLower()[0];

            switch (Value)
            {
                case 1: return "A" + suitChar;
                case 11: return "J" + suitChar;
                case 12: return "Q" + suitChar;
                case 13: return "K" + suitChar;
                default: return Value.ToString() + suitChar;
            }
        }
    }
}
