using System.Numerics;
using MasterSpark.Engine;
using Raylib_cs;

namespace MasterSpark.Scenes
{
    public class TestScene : Scene
    {
        private Camera2DController CamA;
        private Camera2DController CamB;

        private Texture2D testAsset;
        private Texture2D testBackground;

        public TestScene() : base("TestScene")
        {
            CamA = new Camera2DController(800, 600);
            CamB = new Camera2DController(600, 336, 0.5f);

            testAsset = Raylib.LoadTexture("Assets/Arrow.png");
            testBackground = Raylib.LoadTexture("Assets/onnar.png");
        }

        public override void Draw()
        {
            CamA.Begin();
            {
                Raylib.ClearBackground(Color.WHITE);
            
                Engine.Draw.Sprite(testAsset, new Vector2(650,100),1f,(float) (Raylib.GetTime()/1f), Color.RED);
                
                CamB.DrawCamera(new Vector2(10, 10));
            }
            CamA.End();

            CamB.Begin();
            {
                Raylib.ClearBackground(Color.SKYBLUE);
                Raylib.DrawTextureEx(testBackground, Vector2.Zero, 0f, 0.25f, Color.WHITE);
                
                Engine.Draw.Sprite(testAsset, new Vector2(300,168),1f,(float) (Raylib.GetTime()/1f), Color.GREEN);
            }
            CamB.End();

            CamA.DrawCamera(new Vector2(20, 20));
        }
    }
}