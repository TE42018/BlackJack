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
        public int LowValue { get { return Hand.Sum(c=>(c.BlackJackValue)); } }
        public int HighValue { get { return Hand.Sum(c => (c.BlackJackValue > 1 ? c.BlackJackValue : 11)); } }
        public int BestValue { get { return GetBestValue(Hand); } }
        public int Money { get; set; }

        private int GetBestValue(List<Card> hand)
        {
            int sum = 0;

            hand.Sort((c1, c2) => c2.BlackJackValue.CompareTo(c1.BlackJackValue));
            foreach (var c in hand)
            {
                int bjv = c.BlackJackValue;

                if (bjv == 1 && sum + 11 <= 21)
                {
                    sum += 11;
                }
                else
                    sum += bjv;

                //Console.WriteLine(c.ToString());
            }

            return sum;
        }

        public Player()
        {
            Money = 75;
            Reset();
        }

        public void Reset()
        {
            Hand = new List<Card>();
            
            //Hand.Sum(item => (item.Value));
        }

        public override string ToString()
        {
            string playerString = "";

            foreach (var c in Hand)
            {
                playerString += $" {c.ToString()}";
            }
            return playerString;
        }
    }
}
