using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RawCraft.Menu.BaseClasses
{
    class Textbox : Button
    {
        bool _hasFocus;
        int _maxTextLength = 100;
        string _textboxName;
        SpriteFont _textboxNameFont;
        Vector2 _namePosition;

        public Textbox(Texture2D left, Texture2D mid, Texture2D right, int width,
            Vector2 pos, string text, SpriteFont bigFont, SpriteFont normalFont) : base(left, mid, right, width, "", bigFont)
        {
            _namePosition = pos;
            _textboxNameFont = normalFont;
            _textboxName = text;
            EventInput.CharEntered += UpdateText;
        }

        protected void UpdateText(object sender, CharacterEventArgs e)
        {
            if (_hasFocus)
            {
                if (e.Character == (char)Keys.Back)
                {
                    if (Text.Length > 0)
                    {
                        Text = Text.Remove(Text.Length - 1);
                    }
                }
                else if (Text.Length < _maxTextLength)
                {
                    Text += e.Character;
                }
            }
        }

        public void SetTextLength(int length)
        {
            _maxTextLength = length;
        }

        public virtual string GetText()
        {
            return Text;
        }

        public virtual void Update(MouseState mouse, KeyboardState keyboard)
        {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y,
                TexLeft.Width + TexMid.Width * BtnWidth + TexRight.Width, TexMid.Height);
            HitboxMouse = new Rectangle(mouse.X, mouse.Y, 1, 1);

            BtnColor = _hasFocus ? new Color(255, 255, 255, 255) : new Color(180, 180, 180, 255);

            if (HitboxMouse.Intersects(Hitbox))
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                    _hasFocus = true;
            }
            else
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                    _hasFocus = false;
            }
            _namePosition = Position + new Vector2(0, -_textboxNameFont.MeasureString(_textboxName).Y);
            TextPosition = Position + new Vector2(Hitbox.Width / 2f, Hitbox.Height / 2f) - ButtonFont.MeasureString(Text) / 2;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(_textboxNameFont, _textboxName, _namePosition, BtnColor);
        }
    }
}