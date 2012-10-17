using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RawCraft.Menu.BaseClasses
{
    class Sprite
    {
        Vector2 position;
        Texture2D texture;

        public Sprite(Texture2D tex)
        {
            texture = tex;
        }

        public void SetTexture(Texture2D tex)
        {
            texture = tex;
        }

        public void SetPosition(Vector2 pos)
        {
            position = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public int GetWidth
        {
            get { return texture.Width; }
        }

        public int GetHeight
        {
            get { return texture.Height; }
        }
    }
}
