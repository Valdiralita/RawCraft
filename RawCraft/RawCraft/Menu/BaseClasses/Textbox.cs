using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RawCraft.Menu.BaseClasses
{
    class Textbox : Button
    {
        protected bool HasFocus;
        protected int MaxTextLength = 100;
        protected string TextboxName;
        protected SpriteFont TextboxNameFont;
        protected Vector2 NamePosition;

        public Textbox(Texture2D left, Texture2D mid, Texture2D right, int width,
            Vector2 pos, string text, SpriteFont BigFont, SpriteFont NormalFont) : base(left, mid, right, width, "", BigFont)
        {
            TextboxNameFont = NormalFont;
            TextboxName = text;
            EventInput.CharEntered += UpdateText;
        }

        protected void UpdateText(object sender, CharacterEventArgs e)
        {
            if (HasFocus)
            {
                if (e.Character == (char)Keys.Back)
                {
                    if (Text.Length > 0)
                    {
                        Text = Text.Remove(Text.Length - 1);
                    }
                }
                else if (Text.Length < MaxTextLength)
                {
                    Text += e.Character;
                }
            }
        }

        public void SetTextLength(int length)
        {
            MaxTextLength = length;
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

            BtnColor = HasFocus ? new Color(255, 255, 255, 255) : new Color(180, 180, 180, 255);

            if (HitboxMouse.Intersects(Hitbox))
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                    HasFocus = true;
            }
            else
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                    HasFocus = false;
            }
            NamePosition = Position + new Vector2(0, -TextboxNameFont.MeasureString(TextboxName).Y);
            TextPosition = Position + new Vector2(Hitbox.Width / 2, Hitbox.Height / 2) - ButtonFont.MeasureString(Text) / 2;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(TextboxNameFont, TextboxName, NamePosition, BtnColor);
        }
    }
}