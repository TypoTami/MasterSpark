using System;
using System.Numerics;
using MasterSpark.Engine;
using Raylib_cs;

namespace MasterSpark.Scenes
{
    public class MainMenu : Scene
    {
        private Texture2D _logo;
        public MainMenu() : base("MainMenu")
        {
            _logo = Raylib.LoadTexture("Assets/logo.png");
        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                Controller.LoadScene("TestScene");
            }
        }

        public override void Draw()
        {
            // Maybe have some cherry blossoms in the background. Would be nice!
            Engine.Draw.Sprite(_logo, new Vector2(Raylib.GetScreenWidth()/2f, Raylib.GetScreenHeight()/5f), 0.15f, 0f, Color.WHITE);
        }
    }
}