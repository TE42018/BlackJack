using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackAndHookers
{
    class Deck
    {
        int _nrOfDecks;
        List<Card> _cards = new List<Card>();
        public static int plworkmister;

        public Deck(int _nrOfDecks)
        {
            _nrOfDecks = 2;

            for (int i = 0; i < _nrOfDecks; i++) 
            {
                for (int j = 0; j < 52; j++)
                {
                    plworkmister = j;
                }
            }
        }

        

        public void ResetAndShuffle()
        {

        }
        public void Shuffle()
        {

        }
        public void Draw(Card c)
        {
            
        }

    }
}
