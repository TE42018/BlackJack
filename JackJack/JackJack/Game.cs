using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackJack
{
    class Game
    {
        public Player Player { get; set; }
        public Player Dealer { get; set; }
        public Deck Deck { get; set; }
        public GameStatus Status { get; set; }

        public Game()
        {
            Reset();
        }

        public void Reset()
        {
            Player = new Player();
            Dealer = new Player();
            Deck = new Deck(4);


            Player.Hand.Add(Deck.Draw());
            Player.Hand.Add(Deck.Draw());
            Player.Hand.Add(Deck.Draw());
            Console.WriteLine(Player.BestValue);
            //Console.WriteLine(Player.LowValue);
            //Console.WriteLine(Player.Hand[0] + " " + Player.Hand[1]);
        }

        public void PlayerDraw()
        {

        }

        public void DealerDraw()
        {

        }
    }
}
