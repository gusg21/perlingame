using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SimplexNoise;

namespace PerlinGame_Shared
{
    public class PerlinMap
    {
        private GraphicsDevice _graphics;
        private Tileset _tileset;
        private Tilemap _tilemap;

        private int _octaves;
        private float _baseScale;

        public PerlinMap(GraphicsDevice graphicsDevice, ContentManager content, int octaves, float baseScale)
        {
            _graphics = graphicsDevice;
            _tileset = new Tileset(content.Load<Texture2D>("tileset"), 32, 4);
            _tilemap = new Tilemap(_tileset, 100, 100);

            _octaves = octaves;
            _baseScale = baseScale;
            
            GenerateMap();
        }

        private float Threshold(float x, float threshold)
        {
            return x > threshold ? 1f : 0f;
        }

        private int FloatToTile(float x)
        {
            if (x > 0.5f)
                return 0;
            else if (x > 0.45f)
                return 1;
            else
                return 2;
        }
        
        public void GenerateMap()
        {
            Noise.Seed = Guid.NewGuid().GetHashCode();
            
            for (int i = 0; i < _tilemap.Width * _tilemap.Height; i++)
            {
                float n = 0f;
                for (int oct = 0; oct < _octaves; oct++)
                {
                    float scale = _baseScale + _baseScale * (oct * 2);
                    n += Noise.CalcPixel2D(i % _tilemap.Width + oct * 10, i / _tilemap.Width + oct * 10, scale) / MathF.Pow(2, oct + 1);
                }

                n /= 256f;

                int x = (int) _tilemap.ExpandPosition(i).X;
                int y = (int) _tilemap.ExpandPosition(i).Y;
                _tilemap.Set(FloatToTile(n), x, y);
            }
        }

        public void Draw(SpriteBatch batch)
        {
            _tilemap.Draw(batch);
        }
    }
}