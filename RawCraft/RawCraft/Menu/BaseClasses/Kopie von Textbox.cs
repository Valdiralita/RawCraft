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
    class Textbox2 : Button
    {
        protected bool HasFocus;
        protected IList<Keys> LastPressedKeys, PressedKeys;
        protected int MaxTextLength = 100;
        protected string TextboxName;
        protected SpriteFont TextboxNameFont;
        protected Vector2 NamePosition;


        public Textbox2(Texture2D left, Texture2D mid, Texture2D right, int width, Vector2 pos, string text, SpriteFont BigFont, SpriteFont NormalFont)
            : base(left, mid, right, width, pos, "", BigFont)
        {
            TextboxNameFont = NormalFont;
            TextboxName = text;
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
            base.Hitbox = new Rectangle((int)Position.X, (int)Position.Y, (int)(TexLeft.Width + TexMid.Width * BtnWidth + TexRight.Width), (int)TexMid.Height);
            HitboxMouse = new Rectangle(mouse.X, mouse.Y, 1, 1);

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

            UpdateText(keyboard);
        }

        private void UpdateText(KeyboardState keyboard)
        {
            if (HasFocus)
            {
                PressedKeys = (IList<Keys>)keyboard.GetPressedKeys();

                foreach (Keys k in PressedKeys)
                {
                    if (!LastPressedKeys.Contains(k))
                    {
                        if (Text.Length < MaxTextLength)
                        {
                            switch (k)
                            {
                                case Keys.OemMinus:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += '_';
                                    else
                                        Text += '-';
                                    break;

                                case Keys.D1:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += '!';
                                    else
                                        Text += '1';
                                    break;

                                case Keys.D2:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += '"';
                                    else
                                        Text += '2';
                                    break;

                                case Keys.D3:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += '§';
                                    else
                                        Text += '3';
                                    break;

                                case Keys.D4:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += '$';
                                    else
                                        Text += '4';
                                    break;

                                case Keys.D5:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += '%';
                                    else
                                        Text += '5';
                                    break;

                                case Keys.D6:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += '&';
                                    else
                                        Text += '6';
                                    break;

                                case Keys.D7:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += '/';
                                    else
                                        Text += '7';
                                    break;

                                case Keys.D8:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += '(';
                                    else
                                        Text += '8';
                                    break;

                                case Keys.D9:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += ')';
                                    else
                                        Text += '9';
                                    break;

                                case Keys.D0:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += '=';
                                    else
                                        Text += '0';
                                    break;

                                case Keys.OemSemicolon:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += ';';
                                    else
                                        Text += ',';
                                    break;

                                case Keys.NumPad0:
                                    Text += "0";
                                    break;

                                case Keys.NumPad1:
                                    Text += "1";
                                    break;

                                case Keys.NumPad2:
                                    Text += "2";
                                    break;

                                case Keys.NumPad3:
                                    Text += "3";
                                    break;

                                case Keys.NumPad4:
                                    Text += "4";
                                    break;

                                case Keys.NumPad5:
                                    Text += "5";
                                    break;

                                case Keys.NumPad6:
                                    Text += "6";
                                    break;

                                case Keys.NumPad7:
                                    Text += "7";
                                    break;

                                case Keys.NumPad8:
                                    Text += "8";
                                    break;

                                case Keys.NumPad9:
                                    Text += "9";
                                    break;

                                case Keys.OemPeriod:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += ":";
                                    else
                                        Text += '.';
                                    break;

                                case Keys.Back:
                                    if (Text.Length > 0)
                                    {
                                        Text = Text.Remove(Text.Length - 1);
                                    }
                                    break;

                                case Keys.LeftShift:
                                    break;

                                case Keys.RightShift:
                                    break;

                                case Keys.V:
                                    if (PressedKeys.Contains(Keys.LeftControl) || PressedKeys.Contains(Keys.RightControl))
                                        break; //todo
                                    else
                                        goto default;

                                case Keys.RightControl:
                                case Keys.LeftControl:
                                    break;

                                default:
                                    if (PressedKeys.Contains(Keys.LeftShift) || PressedKeys.Contains(Keys.RightShift))
                                        Text += char.ToUpper((char)k);
                                    else
                                        Text += char.ToLower((char)k);
                                    break;
                            }
                        }


                    }
                }
                LastPressedKeys = PressedKeys;
            }
            TextPosition = Position + new Vector2(Hitbox.Width / 2, Hitbox.Height / 2) - ButtonFont.MeasureString(Text) / 2;
            NamePosition = Position + new Vector2(0, -TextboxNameFont.MeasureString(TextboxName).Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(TextboxNameFont, TextboxName, NamePosition, Color.White);
        }

    }
}