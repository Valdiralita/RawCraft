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
    class Button
    {
        protected Texture2D TexLeft, TexMid, TexRight;
        protected int BtnWidth;
        protected SpriteFont ButtonFont;
        protected Vector2 Position, TextPosition;
        protected Rectangle Hitbox, HitboxMouse;
        protected string Text;
        protected Color BtnColor = new Color(200, 200, 200, 255);
        protected bool Clicked;

        public Button(Texture2D left, Texture2D mid, Texture2D right, int width)
        {
            BtnWidth = width;
            TexLeft = left;
            TexMid = mid;
            TexRight = right;
        }

        public Button(Texture2D left, Texture2D mid, Texture2D right, int width, Vector2 pos, string text, SpriteFont font) : this(left, mid, right, width)
        {
            Text = text;
            ButtonFont = font;
        }

        public void SetBtnWidth(int btnw)
        {
            BtnWidth = btnw;
        }

        public int GetWidth
        {
            get { return TexLeft.Width + TexMid.Width * BtnWidth + TexRight.Width; }
        }

        public void SetPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }

        public virtual void SetText(string text)
        {
            Text = text;
        }

        public void Update(MouseState mouse)
        {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, (int)(TexLeft.Width + TexMid.Width * BtnWidth + TexRight.Width), (int)TexMid.Height);
            HitboxMouse = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (HitboxMouse.Intersects(Hitbox))
            {
                BtnColor = new Color(255, 255, 255, 255);

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    Clicked = true;
                }
                else
                {
                    Clicked = false;
                }
            }
            else
            {
                BtnColor = new Color(180, 180, 180, 255);
                Clicked = false;
            }

            TextPosition = Position + new Vector2(Hitbox.Width / 2, Hitbox.Height / 2) - ButtonFont.MeasureString(Text) / 2;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TexLeft, Position, BtnColor);

            for (int i = 0; i < BtnWidth; i++)
                spriteBatch.Draw(TexMid, Position + new Vector2(TexMid.Width * i + TexLeft.Width, 0), BtnColor);

            spriteBatch.Draw(TexRight, Position + new Vector2(TexMid.Width * BtnWidth, 0), BtnColor);
            spriteBatch.DrawString(ButtonFont, Text, TextPosition, BtnColor);
        }

        public bool isClicked
        {
            get { return Clicked; }
        }
    }
}
