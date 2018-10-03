using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Game game = new Game();
            
            Card c = new Card(1, SuitType.Diamond);
            Console.WriteLine(c.ToString());
            Console.ReadLine();
        }
    }
}
