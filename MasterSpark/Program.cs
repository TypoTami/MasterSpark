using System;
using System.Numerics;
using Raylib_cs;

namespace MasterSpark
{
    class Program
    {
        private static Game game;
        static void Main(string[] args)
        {
            game = new Game(new Vector2(1280, 720), 60);
            
            while (!Raylib.WindowShouldClose())
            {
                game.Update();
                game.Draw();
            }
        }
    }
}