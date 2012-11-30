using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RawCraft.Menu.BaseClasses
{
    class Sprite
    {
        Vector2 _position;
        Texture2D _texture;

        public Sprite(Texture2D tex)
        {
            _texture = tex;
        }

        public void SetTexture(Texture2D tex)
        {
            _texture = tex;
        }

        public void SetPosition(Vector2 pos)
        {
            _position = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

        public int GetWidth
        {
            get { return _texture.Width; }
        }

        public int GetHeight
        {
            get { return _texture.Height; }
        }
    }
}
