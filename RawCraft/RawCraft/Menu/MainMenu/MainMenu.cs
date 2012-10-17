using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using RawCraft.Menu.BaseClasses;
using RawCraft.Storage;
using Microsoft.Xna.Framework;

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
        float zoom;

        public MainMenu()
        {
            logoTexture = Misc.Content.Load<Texture2D>("logo");

            btnTexLeft = Misc.Content.Load<Texture2D>("ButtonLeft");
            btnTexMid = Misc.Content.Load<Texture2D>("ButtonMid");
            btnTexRight = Misc.Content.Load<Texture2D>("ButtonRight");

            txtTexLeft = Misc.Content.Load<Texture2D>("TextboxLeft");
            txtTexMid = Misc.Content.Load<Texture2D>("TextboxMid");
            txtTexRight = Misc.Content.Load<Texture2D>("TextboxRight");

            logo = new Sprite(logoTexture);

            mainMenuBackground = new Background(Misc.Content.Load<Texture2D>("background"));

            play = new Button(btnTexLeft, btnTexMid, btnTexRight, 40, "Connect", Misc.BigFont);
            exit = new Button(btnTexLeft, btnTexMid, btnTexRight, 40, "Quit Game", Misc.BigFont);

            userName = new Textbox(txtTexLeft, txtTexMid, txtTexRight, 40, Vector2.Zero, "Username:", Misc.BigFont, Misc.NormalFont);
            password = new PasswordBox(txtTexLeft, txtTexMid, txtTexRight, 40, Vector2.Zero, "Password:", Misc.BigFont, Misc.NormalFont);
            server = new Textbox(txtTexLeft, txtTexMid, txtTexRight, 100, Vector2.Zero, "Server:", Misc.BigFont, Misc.NormalFont);

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

        public void Update()
        {
            play.SetPosition(new Vector2(Misc.Width / 16 * 11 - play.GetWidth / 2, (float)(Misc.Height - btnTexMid.Height * 1.5)));
            play.Update(Misc.mouseState);

            exit.SetPosition(new Vector2(Misc.Width / 16 * 5 - exit.GetWidth / 2, (float)(Misc.Height - btnTexMid.Height * 1.5)));
            exit.Update(Misc.mouseState);

            userName.SetPosition(new Vector2(Misc.Width / 16 * 5 - userName.GetWidth / 2, (float)(Misc.Height - btnTexMid.Height * 4.5)));
            userName.Update(Misc.mouseState, Misc.keyboardState);

            password.SetPosition(new Vector2(Misc.Width / 16 * 11 - password.GetWidth / 2, (float)(Misc.Height - btnTexMid.Height * 4.5)));
            password.Update(Misc.mouseState, Misc.keyboardState);

            server.SetBtnWidth((Misc.Width - (Misc.Width / 8 * 5 - exit.GetWidth)) / 8 - 2);
            server.SetPosition(new Vector2(Misc.Width / 16 * 5 - exit.GetWidth / 2, Misc.Height - btnTexMid.Height * 3));
            server.Update(Misc.mouseState, Misc.keyboardState);

            logo.SetPosition(new Vector2(Misc.Width / 2 - logo.GetWidth / 2, Misc.Height / 16 * 4 - logo.GetHeight / 2));

            password.Update(Misc.mouseState, Misc.keyboardState);
            server.Update(Misc.mouseState, Misc.keyboardState);

            if (exit.IsClicked)
                Misc.CurrentGameState = Misc.GameState.Exit;

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
                Misc.CurrentGameState = Misc.GameState.InGame;
            }
        }

        public void Draw()
        {
            mainMenuBackground.Draw(Misc.spriteBatch);

            play.Draw(Misc.spriteBatch);
            exit.Draw(Misc.spriteBatch);

            userName.Draw(Misc.spriteBatch);
            password.Draw(Misc.spriteBatch);
            server.Draw(Misc.spriteBatch);

            logo.Draw(Misc.spriteBatch);

            zoom += 0.03f;
            Misc.spriteBatch.DrawString(Misc.NormalFont, "Not finished yet!", new Vector2(950, 250),
                Color.Yellow, -0.3f, new Vector2(100, 30), 1.5f + (float)Math.Abs(Math.Sin(zoom)) /2, SpriteEffects.None, 0);
        }
    }
}
