using System.Numerics;
using MasterSpark.Utils;
using Raylib_cs;

namespace MasterSpark
{
    public class Game
    {
        private Vector2 _windowSize;
        private int _targetFPS;

        private Scene _currentScene;
        
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

            _currentScene = new TestScene();
        }

        public void Update()
        {
            _windowSize = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
            Raylib.SetWindowTitle($"MasterSpark - {_windowSize} - {Raylib.GetFPS()}FPS/{Raylib.GetFrameTime()}ms");
        }

        public void Draw()
        {
            Raylib.BeginDrawing();
            {
                Raylib.ClearBackground(Color.LIGHTGRAY);
                
                _currentScene.Draw();
            }
            Raylib.EndDrawing();
        }
    }
}