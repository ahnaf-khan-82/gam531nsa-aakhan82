using System;
using Assignment1;

namespace Assignment1
{
     class Program
    {
        static void Main(string[] args)
        {
          using (Game game = new Game())
          {
            game.Run();
          }
        }
    }
}