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

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
