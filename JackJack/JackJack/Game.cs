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
        public int PlayerBet { get; set; }

        public Game()
        {
            Player = new Player();
            Dealer = new Player();
            Reset();
        }

        public void HardReset()
        {
            Player = new Player();
            Reset();
        }

        public void Reset()
        {

            Player.Reset();
            Dealer.Reset();
            Deck = new Deck(4);
            PlayerBet = 0;

            Status = GameStatus.Playing;

            //Place bets

            string betString = "";
            string errorString = "";
            char betKey;
            do
            {
                betString = "";
                Console.Clear();
                Console.WriteLine("Welcome to JackJack\n");

                Console.Write(errorString);
                errorString = "";
                if (Player.Money == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have lost all of your money...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Do you want to start over? (Y)es/(N)o > ");
                    char resetKey;
                    while (true)
                    {
                        resetKey = Console.ReadKey().KeyChar;

                        if (resetKey == 'y')
                            HardReset();
                        else if (resetKey == 'N' || resetKey == 'n')
                            Environment.Exit(-1);
                    }
                }

                Console.WriteLine($"You have: ${Player.Money}");
                Console.Write($"Place your bet ($2 - $500) > ");
                do
                {
                    betKey = Console.ReadKey(true).KeyChar;
                    // Console.WriteLine(betKey == '\b');
                    if (betKey == '\b' && betString.Length > 0)
                    {
                        betString = "";
                        break;
                    }
                    //Console.WriteLine(Char.IsNumber(betKey));
                    if (Char.IsNumber(betKey) && (Convert.ToInt32(betKey.ToString()) > 0 || betString.Length > 0))
                    {
                        betString += betKey;
                        Console.Write(betKey);
                    }
                    //Console.WriteLine(betString);
                } while (betKey != '\r');
                PlayerBet = betString.Length == 0 ? 0 : Convert.ToInt32(betString);
                if (PlayerBet <= 500 && PlayerBet > Player.Money)
                    errorString = "You don't have enough money!\n";
                else if (PlayerBet > 500)
                    errorString = "The bet was too high!\n";
                else if (PlayerBet < 2)
                    errorString = "The bet was too low!\n";
            } while (errorString.Length != 0);

            Console.WriteLine("\n");
            

            //Begin game
            Dealer.Hand.Add(Deck.Draw());

            Console.WriteLine("The dealer has:" + Dealer.ToString() + " | " + Dealer.HighValue);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~");
            PlayerDraw();

            //Status check
            switch (Status)
            {
                case GameStatus.Won: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"The dealer got {Dealer.HighValue} and lost \nYou gained ${(int)(PlayerBet * 0.5)}"); Player.Money += (int)(PlayerBet * 0.5); break;
                case GameStatus.Lost: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"You got {Player.BestValue} and lost \nYou lost ${PlayerBet}"); Player.Money -= PlayerBet; break;
                case GameStatus.Tie: Console.WriteLine("You are both losers!"); break;
                case GameStatus.BlackJack: Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"You got BLACKJACK! \nYou gained ${(int)(PlayerBet*1.5)}"); Player.Money += (int)(PlayerBet * 1.5); break;
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            //Replay or quit
            Console.Write("Do you want to play again? (Y)es/(N)o > ");
            char key;
            while (true)
            {
                key = Console.ReadKey().KeyChar;

                if (key == 'y')
                    Reset();
                else if (key == 'N' || key == 'n')
                    Environment.Exit(-1);
            }
        }

        public void PlayerDraw()
        {
            Player.Hand.Add(Deck.Draw());

            char key;
            do
            {
                Player.Hand.Add(Deck.Draw());
                Console.WriteLine($"You have:{Player.ToString()} | {Player.BestValue}");
                Console.WriteLine("------------------");

                if (Player.BestValue > 21)
                {
                    Status = GameStatus.Lost;
                    return;
                }
                if (Player.BestValue == 21 && Player.Hand.Count == 2)
                {
                    Status = GameStatus.BlackJack;
                    return;
                }
                Console.Write("(H)it | (S)top > ");


                do
                {
                    key = (char)Console.ReadKey(true).Key;
                } while (key != 'H' && key != 'S');
                Console.WriteLine($"{key}\n");
            } while (key == 'h' || key == 'H');


            DealerDraw();
        }

        public void DealerDraw()
        {
            do
            {
                Dealer.Hand.Add(Deck.Draw());
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine($"The dealer has:{Dealer.ToString()} | {Dealer.HighValue}");

                if (Dealer.HighValue > 21)
                {
                    Status = GameStatus.Won;
                    return;
                }

            } while (Dealer.HighValue < 17);

            if (Dealer.HighValue > Player.BestValue)
            {
                Status = GameStatus.Lost;
                return;
            }
            else if (Dealer.HighValue < Player.BestValue || Player.BestValue == 21)
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
        }
    }
}
