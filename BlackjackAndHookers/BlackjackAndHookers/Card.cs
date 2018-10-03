using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackAndHookers
{
    class Card
    {
        public int Value = 1;
        public SuitType suit;
        public int BlackJackValue;

        public Card(int value, SuitType suit)
        {
            Random rnd = new Random();
            int Value = rnd.Next(1, 13);

        }
        public override string ToString()
        {
            return base.ToString();

        }


    }
}
