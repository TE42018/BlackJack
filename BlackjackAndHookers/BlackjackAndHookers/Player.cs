using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackAndHookers
{
    class Player
    {
        public List<Card> Hand = new List<Card>();
        public Card LastDrawnCard;
        public int LowValue;
        public int HighValue;
        public int BestValue;

        public void Reset()
        {

        }

        public void ToString(string s)
        {

        }
    }
}
