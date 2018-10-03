using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackJack
{
    class Deck
    {
        private int _nrOfDecks;
        private List<Card> _cards;

        public Deck(int nrOfDecks)
        {
            _nrOfDecks = nrOfDecks;
            ResetAndShuffle();
        }

        public void ResetAndShuffle()
        {
            _cards = new List<Card>();
            for (int i = 0; i < _nrOfDecks * 52; i++)
            {
                int cardValue = i % 13 + 1;
                SuitType cardSuit = (SuitType)(i%4);
                _cards.Add(new Card(cardValue, cardSuit));
            }
            Shuffle();
        }

        private static Random rng = new Random();

        public void Shuffle()
        {
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card c = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = c;
            }
        }

        public Card Draw()
        {
            Card c = _cards[0];
            _cards.Remove(_cards.First());
            return c;
        }

        public void Insert(Card card)
        {
            _cards.Add(card);
        }
    }
}
