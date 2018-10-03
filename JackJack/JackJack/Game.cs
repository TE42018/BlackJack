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
            Console.Clear();
            Console.WriteLine("Welcome to JackJack\n");

            Player = new Player();
            Dealer = new Player();
            Deck = new Deck(4);

            Status = GameStatus.Playing;

            Dealer.Hand.Add(Deck.Draw());
            
            Console.WriteLine("The dealer has:" + Dealer.ToString() + " | " + Dealer.HighValue);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~");
            PlayerDraw();
            switch (Status)
            {
                case GameStatus.Won: Console.WriteLine("The dealer got {0} and lost", Dealer.HighValue); break;
                case GameStatus.Lost: Console.WriteLine("You got {0} and lost", Player.BestValue); break;
                case GameStatus.Tie: Console.WriteLine("You are both losers!"); break;

            }
        }

        public void PlayerDraw()
        {
            Player.Hand.Add(Deck.Draw());

            char key;
            do
            {
                Player.Hand.Add(Deck.Draw());
                if (Player.BestValue > 21)
                {
                    Status = GameStatus.Lost;
                    return;
                }
                if(Player.BestValue == 21)
                {
                    Status = GameStatus.Won;
                    return;
                }

                Console.WriteLine($"You have:{Player.ToString()} | {Player.BestValue}");
                Console.WriteLine("------------------");
                Console.Write("(H)it | (S)top > ");

                do {
                    key = (char)Console.ReadKey().Key;
                } while (key != 'H' && key != 'S');
                Console.WriteLine("\n");
            } while (key == 'h' || key == 'H');
            DealerDraw();
        }

        public void DealerDraw()
        {
            do
            {
                Dealer.Hand.Add(Deck.Draw());
                System.Threading.Thread.Sleep(2000);

                if (Dealer.HighValue > 21)
                {
                    Status = GameStatus.Won;
                    return;
                }
                else if (Dealer.HighValue > Player.BestValue)
                {
                    Status = GameStatus.Lost;
                    return;
                }
                else if (Dealer.HighValue < Player.BestValue)
                {
                    Status = GameStatus.Won;
                    return;
                }
                else if (Dealer.HighValue == Player.BestValue && Dealer.HighValue > 16 && Dealer.HighValue < 20)
                {
                    Status = GameStatus.Lost;
                    return;
                }
                else if (Dealer.HighValue == Player.BestValue && Dealer.HighValue == 20)
                {
                    Status = GameStatus.Tie;
                    return;
                }
                

                Console.WriteLine($"The dealer has:{Dealer.ToString()} | {Dealer.HighValue}");
            } while (Dealer.HighValue < 17);
            //Hit until HighValue >= 17
        }
    }
}
