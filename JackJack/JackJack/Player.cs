using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackJack
{
    class Player
    {
        public List<Card> Hand { get; set; }
        public Card LastDrawnCard { get; set; }
        public int LowValue { get; set; }
        public int HighValue { get; set; }
        public int BestValue { get; set; }

        public Player()
        {

        }

        public void Reset()
        {

        }
    }
}
