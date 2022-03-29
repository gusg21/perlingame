using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PerlinGame_Shared
{
    public class Tilemap
    {
        public int[] Tiles;
        public Tileset Tileset;
        public int Width;
        public int Height;
        
        public Tilemap(Tileset tileset, int width, int height)
        {
            Tiles = new int[width * height];
            Tileset = tileset;
            Width = width;
            Height = height;
        }

        public bool IsPositionValid(int x, int y)
        {
            var flatIndex = FlattenPosition(x, y);
            return flatIndex >= 0 && flatIndex < Tiles.Length;
        }

        public int FlattenPosition(int x, int y)
        {
            return y * Width + x % Width;
        }

        public Vector2 ExpandPosition(int flatIndex)
        {
            return new Vector2(
                flatIndex % Width, flatIndex / Width);
        }

        public void Set(int index, int x, int y)
        {
            if (IsPositionValid(x, y))
                Tiles[FlattenPosition(x, y)] = index;
        }

        public int Get(Vector2 position)
        {
            return Get((int) position.X, (int) position.Y);
        }

        public int Get(int x, int y)
        {
            if (IsPositionValid(x, y))
                return Tiles[FlattenPosition(x, y)];
            
            return -1;
        }

        public void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < Tiles.Length; i++)
            {
                Tileset.Draw(batch, Tiles[i], ExpandPosition(i) * Tileset.TileSize);
            }
        }
    }
}