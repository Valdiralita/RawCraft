using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using RawCraft.Menu.BaseClasses;
using RawCraft.Storage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace RawCraft.Menu.MainMenu
{
    class MainMenu
    {
        Background mainMenuBackground;
        Button play, exit;
        Sprite logo;
        Texture2D btnTexLeft, btnTexMid, btnTexRight, txtTexLeft, txtTexMid, txtTexRight, logoTexture;
        Textbox userName, server;
        PasswordBox password;
        SpriteFont BigFont, NormalFont;
        float zoom;

        public MainMenu(ContentManager Content)
        {
            BigFont = Content.Load<SpriteFont>("BigFont");
            NormalFont = Content.Load<SpriteFont>("NormalFont");

            logoTexture = Content.Load<Texture2D>("logo");

            btnTexLeft = Content.Load<Texture2D>("ButtonLeft");
            btnTexMid = Content.Load<Texture2D>("ButtonMid");
            btnTexRight = Content.Load<Texture2D>("ButtonRight");

            txtTexLeft = Content.Load<Texture2D>("TextboxLeft");
            txtTexMid = Content.Load<Texture2D>("TextboxMid");
            txtTexRight = Content.Load<Texture2D>("TextboxRight");

            logo = new Sprite(logoTexture);

            mainMenuBackground = new Background(Content.Load<Texture2D>("background"));

            play = new Button(btnTexLeft, btnTexMid, btnTexRight, 40, "Connect", BigFont);
            exit = new Button(btnTexLeft, btnTexMid, btnTexRight, 40, "Quit Game", BigFont);

            userName = new Textbox(txtTexLeft, txtTexMid, txtTexRight, 40, Vector2.Zero, "Username:", BigFont, NormalFont);
            password = new PasswordBox(txtTexLeft, txtTexMid, txtTexRight, 40, Vector2.Zero, "Password:", BigFont, NormalFont);
            server = new Textbox(txtTexLeft, txtTexMid, txtTexRight, 100, Vector2.Zero, "Server:", BigFont, NormalFont);

            userName.SetTextLength(16);
            password.SetTextLength(64);
            server.SetTextLength(32);

            var login = MinecraftUtilities.GetLastLogin();

            if (login != null)
            {
                userName.SetText(login.Username);
                password.SetText(login.Password);
            }
        }

        public GameState Update(MouseState mouseState, KeyboardState keyboardState, GameState cGS)
        {
            play.SetPosition(new Vector2(Config.Width / 16 * 11 - play.GetWidth / 2, (float)(Config.Height - btnTexMid.Height * 1.5)));
            play.Update(mouseState);

            exit.SetPosition(new Vector2(Config.Width / 16 * 5 - exit.GetWidth / 2, (float)(Config.Height - btnTexMid.Height * 1.5)));
            exit.Update(mouseState);

            userName.SetPosition(new Vector2(Config.Width / 16 * 5 - userName.GetWidth / 2, (float)(Config.Height - btnTexMid.Height * 4.5)));
            userName.Update(mouseState, keyboardState);

            password.SetPosition(new Vector2(Config.Width / 16 * 11 - password.GetWidth / 2, (float)(Config.Height - btnTexMid.Height * 4.5)));
            password.Update(mouseState, keyboardState);

            server.SetBtnWidth((Config.Width - (Config.Width / 8 * 5 - exit.GetWidth)) / 8 - 2);
            server.SetPosition(new Vector2(Config.Width / 16 * 5 - exit.GetWidth / 2, Config.Height - btnTexMid.Height * 3));
            server.Update(mouseState, keyboardState);

            logo.SetPosition(new Vector2(Config.Width / 2 - logo.GetWidth / 2, Config.Height / 16 * 4 - logo.GetHeight / 2));

            password.Update(mouseState, keyboardState);
            server.Update(mouseState, keyboardState);

            if (exit.IsClicked)
                return GameState.Exit;

            if (play.IsClicked)
            {
                string serverText = this.server.GetText();
                if (serverText.Contains(':'))
                {
                    Storage.Network.Server = serverText.Split(':').First();
                    Storage.Network.Port = (int)Convert.ToUInt16(serverText.Split(':').Last());
                }
                else
                {
                    Storage.Network.Server = serverText;
                    Storage.Network.Port = 25565;
                }
                Storage.Network.UserName = userName.GetText();
                Storage.Network.Password = password.GetText();
                return GameState.InGame;
            }
            return cGS;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mainMenuBackground.Draw(spriteBatch);

            play.Draw(spriteBatch);
            exit.Draw(spriteBatch);

            userName.Draw(spriteBatch);
            password.Draw(spriteBatch);
            server.Draw(spriteBatch);

            logo.Draw(spriteBatch);

            zoom += 0.03f;
            spriteBatch.DrawString(NormalFont, "Not finished yet!", new Vector2(950, 250),
                Color.Yellow, -0.3f, new Vector2(100, 30), 1.5f + (float)Math.Abs(Math.Sin(zoom)) /2, SpriteEffects.None, 0);
        }
    }
}
