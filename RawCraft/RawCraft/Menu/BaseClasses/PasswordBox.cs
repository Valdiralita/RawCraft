using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Storage;

namespace Menu
{
    class PWTextbox : Button
    {
        protected bool HasFocus;
        protected int MaxTextLength = 100;
        protected string TextboxName;
        protected SpriteFont TextboxNameFont;
        protected Vector2 NamePosition;
        private string TrueText = "";

        public PWTextbox(Texture2D left, Texture2D mid, Texture2D right, int width, Vector2 pos, string text, SpriteFont BigFont, SpriteFont NormalFont)
            : base(left, mid, right, width, pos, "", BigFont)
        {
            TextboxNameFont = NormalFont;
            TextboxName = text;
            EventInput.CharEntered += new CharEnteredHandler(UpdateText);
        }

        public void SetTextLength(int length)
        {
            MaxTextLength = length;
        }

        public virtual string GetText()
        {
            return TrueText;
        }

        public virtual void Update(MouseState mouse, KeyboardState keyboard)
        {
            base.Hitbox = new Rectangle((int)Position.X, (int)Position.Y, (int)(TexLeft.Width + TexMid.Width * BtnWidth + TexRight.Width), (int)TexMid.Height);
            HitboxMouse = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (HasFocus)
            {
                BtnColor = new Color(255, 255, 255, 255);
            }
            else
            {
                BtnColor = new Color(200, 200, 200, 255);
            }

            if (HitboxMouse.Intersects(base.Hitbox))
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    HasFocus = true;
                }
            }
            else
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    HasFocus = false;
                }
            }

            NamePosition = Position + new Vector2(0, -TextboxNameFont.MeasureString(TextboxName).Y);
            TextPosition = Position + new Vector2(Hitbox.Width / 2, Hitbox.Height / 2) - ButtonFont.MeasureString(base.Text) / 2;
        }

        protected void UpdateText(object sender, CharacterEventArgs e)
        {
            if (HasFocus)
            {
                if (e.Character == (char)Keys.Back)
                {
                    if (TrueText.Length > 0)
                    {
                        TrueText = TrueText.Remove(TrueText.Length - 1);
                    }
                }
                else if (TrueText.Length < MaxTextLength)
                {
                    TrueText += e.Character;
                }
            }

            base.Text = "";
            for (int i = 0; i < TrueText.Length; i++)
            {
                base.Text += '*';
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(TextboxNameFont, TextboxName, NamePosition, BtnColor);
        }

        public override void SetText(string text)
        {
            TrueText = text;

            base.Text = "";
            for (int i = 0; i < TrueText.Length; i++)
            {
                base.Text += '*';
            }
        }
    }
}