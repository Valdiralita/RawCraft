using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Storage;

namespace Menu
{
    class Sprite
    {
        Vector2 Position;
        Texture2D Texture;

        public Sprite(Texture2D tex)
        {
            Texture = tex;
        }

        public void SetTexture(Texture2D tex)
        {
            Texture = tex;
        }

        public void SetPosition(Vector2 pos)
        {
            Position = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public int GetWidth
        {
            get { return Texture.Width; }
        }

        public int GetHeight
        {
            get { return Texture.Height; }
        }
    }
}
