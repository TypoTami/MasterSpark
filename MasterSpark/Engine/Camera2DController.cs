using System.Numerics;
using Raylib_cs;

namespace MasterSpark.Engine
{
    public class Camera2DController
    {
        private Camera2D _camera;
        private RenderTexture2D _renderTexture;
        private int _baseWidth;
        private int _baseHeight;
        private float _scale;

        public Camera2DController(int width, int height, float scale = 1f)
        {
            _camera = new Camera2D
            {
                zoom = 1f,
                rotation = 0f,
                offset = Vector2.Zero,
                target = Vector2.Zero
            };
            

            _baseWidth = width;
            _baseHeight = height;

            _renderTexture = Raylib.LoadRenderTexture(_baseWidth, _baseHeight);
            
            SetScale(scale);
            SetOffset(new Vector2(_baseWidth/2f, _baseHeight/2f));
            SetTarget(new Vector2(_baseWidth/2f, _baseHeight/2f));
        }

        ~Camera2DController() => Raylib.UnloadRenderTexture(_renderTexture);

        public void SetZoom(float zoom)
        {
            SetOffset(new Vector2(_baseWidth/2f, _baseHeight/2f));
            
            _camera.zoom = zoom * _scale;
        }

        public void SetRotation(float rotation) => _camera.rotation = rotation;

        public void SetOffset(Vector2 offset)
        {
            offset *= _scale;
            
            _camera.offset = offset;
        }

        public void SetTarget(Vector2 target) => _camera.target = target;
        public void SetScale(float scale)
        {
            // var previousTex = _renderTexture;
            _scale = scale;
            _camera.zoom = scale;
            
            Raylib.UnloadRenderTexture(_renderTexture);
            _renderTexture = Raylib.LoadRenderTexture((int) (_baseWidth * _scale), (int) (_baseHeight *_scale));
        }

        public void Begin()
        {
            Raylib.BeginTextureMode(_renderTexture);
            Raylib.BeginMode2D(_camera);
        }

        public void End()
        {
            Raylib.EndMode2D();
            Raylib.EndTextureMode();
        }

        public void DrawCamera(Vector2 position)
        {
            Raylib.DrawTexturePro(
                _renderTexture.texture,
                new Rectangle(0f, 0f, _renderTexture.texture.width, -_renderTexture.texture.height),
                new Rectangle(position.X, position.Y, _baseWidth, _baseHeight),
                new Vector2(0f, 0f),
                0f,
                Color.WHITE
            );
        }
    }
}