using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JackJack
{
    class Card
    {
        public int Value { get; set; }
        public SuitType Suit { get; set; }
        public int BlackJackValue { get { return Math.Min(Value, 10); } }

        public Card(int value, SuitType suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString()
        {
            int suitCharVal = (int)Enum.GetValues(Suit.GetType()).GetValue((int)Suit);
            string suitString = DecodeEncodedNonAsciiCharacters($"\\u{suitCharVal}".ToString());
            char suitChar = Convert.ToChar(suitString);
            
            switch (Value)
            {
                case 1: return "A" + suitChar;
                case 11: return "J" + suitChar;
                case 12: return "Q" + suitChar;
                case 13: return "K" + suitChar;
                default: return Value.ToString() + suitChar;
            }
        }

        static string DecodeEncodedNonAsciiCharacters(string value)
        {
            return Regex.Replace(
                value,
                @"\\u(?<Value>[a-zA-Z0-9]{4})",
                m => {
                    return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
                });
        }
    }
}