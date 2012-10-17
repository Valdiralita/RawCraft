using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Storage;
using Microsoft.Xna.Framework.Graphics;

namespace Interface
{
    class TextOverlay
    {
        SpriteFont Font;
        string Text;
        Color TextColor = Color.White;
        Vector2 Position;

        public TextOverlay(SpriteFont font, Vector2 vec)
        {
            Font = font;
            Position = vec;
        }

        public TextOverlay(SpriteFont font, Vector2 vec, Color color)
        {
            Font = font;
            Position = vec;
            TextColor = color;
        }

        public virtual void UpdateText(string text)
        {
            Text = text;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Text, Position, Color.White);
        }
    }
}

