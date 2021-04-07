using System.Numerics;
using MasterSpark.Engine;
using Raylib_cs;

namespace MasterSpark
{
    public class Game
    {
        private Vector2 _windowSize;
        private int _targetFPS;

        public SceneController Scene;
        
        public Game(Vector2 windowSize, int targetFPS)
        {
            _windowSize = windowSize;
            _targetFPS = targetFPS;
            
            Raylib.SetConfigFlags(
                ConfigFlag.FLAG_WINDOW_RESIZABLE |
                ConfigFlag.FLAG_MSAA_4X_HINT |
                ConfigFlag.FLAG_VSYNC_HINT
            );
            
            Raylib.InitWindow((int) windowSize.X, (int) windowSize.Y, "MasterSpark");

            Raylib.SetTargetFPS(_targetFPS);

            Scene = new SceneController();
            Scene.AddScene(new Scenes.TestScene());
            Scene.AddScene(new Scenes.MainMenu());
            
            Scene.LoadScene("MainMenu");
        }

        public void Update()
        {
            _windowSize = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
            Raylib.SetWindowTitle($"MasterSpark - {Scene.Current().Name} - {_windowSize} - {Raylib.GetFPS()}FPS/{Raylib.GetFrameTime()}ms");
            
            Scene.Current().Update();
        }

        public void Draw()
        {
            Raylib.BeginDrawing();
            {
                Raylib.ClearBackground(Color.LIGHTGRAY);
                
                Scene.Current().Draw();
            }
            Raylib.EndDrawing();
        }
    }
}