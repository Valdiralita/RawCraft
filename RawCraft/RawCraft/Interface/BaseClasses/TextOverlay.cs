using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RawCraft.Interface.BaseClasses
{
    class TextOverlay
    {
        SpriteFont _font;
        string _text;
        private Color _textColor = Color.White;
        Vector2 _position;

        public TextOverlay(SpriteFont font, Vector2 vec)
        {
            _font = font;
            _position = vec;
        }

        public TextOverlay(SpriteFont font, Vector2 vec, Color color) : this(font, vec)
        {
            TextColor = color;
        }

        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }

        public virtual void UpdateText(string text)
        {
            _text = text;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, _text, _position, Color.White);
        }
    }
}

