using System;
using System.Numerics;
using Raylib_cs;

namespace MasterSpark.Utils
{
    public static class Drawing
    {
        public static void DrawSprite(Texture2D sprite, Vector2 position, float scale, float radians, Color colour)
        {
            Vector2 spriteOrigin = new Vector2(
                position.X - (sprite.width * 0.5f) * scale,
                position.Y - (sprite.height * 0.5f) * scale
            );

            float x1 = spriteOrigin.X - position.X;
            float y1 = spriteOrigin.Y - position.Y;

            float x2 = x1 * (float)Math.Cos(radians) - y1 * (float)Math.Sin(radians);
            float y2 = x1 * (float)Math.Sin(radians) + y1 * (float)Math.Cos(radians);

            spriteOrigin.X = x2 + position.X;
            spriteOrigin.Y = y2 + position.Y;

            Raylib.DrawTextureEx(sprite, spriteOrigin, radians * (float)(180/Math.PI), scale, colour);
        }
    }
}