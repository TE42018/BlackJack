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
        public int LowValue { get { return Hand.Sum(c=>(c.Value)); } }
        public int HighValue { get { return Hand.Sum(c => (c.Value > 1 ? c.Value : 11)); } }
        public int BestValue { get; set; }

        public Player()
        {
            Reset();
        }

        public void Reset()
        {
            Hand = new List<Card>();
            
            Hand.Sum(item => (item.Value));
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
