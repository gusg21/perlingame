using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PerlinGame_Shared
{
    public class Tileset
    {
        public Vector2 TileSize => new Vector2(_tileSize, _tileSize);
        public Texture2D Source;
        
        private int _tilesWide;
        private int _tileSize;
        
        public Tileset(Texture2D source, int tileSize, int tilesWide)
        {
            Source = source;
            _tileSize = tileSize;
            _tilesWide = tilesWide;
        }

        public void Draw(SpriteBatch batch, int tileIndex, Vector2 position)
        {
            batch.Draw(Source, position, new Rectangle(
                tileIndex % _tilesWide * _tileSize, tileIndex / _tilesWide * _tileSize, _tileSize, _tileSize
                ), Color.White);
        }
    }
}