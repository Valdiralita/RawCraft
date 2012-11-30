using Microsoft.Xna.Framework.Graphics;
using RawCraft.Storage;
using Microsoft.Xna.Framework;

namespace RawCraft.Menu.BaseClasses
{
    class Background
    {
        Texture2D _texture;
        int _horizontalTileCount, _verticalTileCount;

        public Background(Texture2D texture)
        {
            _texture = texture;
        }

        public void SetTexture(Texture2D tex)
        {
            _texture = tex;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _horizontalTileCount = Config.Width / _texture.Width + 1;
            _verticalTileCount = Config.Height / _texture.Height + 1;

            for (int i = 0; i < _horizontalTileCount; i++)
            {
                for (int j = 0; j < _verticalTileCount; j++)
                    spriteBatch.Draw(_texture, new Vector2(_texture.Width * i, _texture.Height * j), Color.White);
            }
        }
    }
}
