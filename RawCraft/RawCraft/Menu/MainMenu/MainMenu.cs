using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Storage;
using Menu;
using Microsoft.Xna.Framework;

namespace Menu
{
    class MainMenu
    {
        Background MainMenuBackground;
        Button Play, Exit;
        Sprite Logo;
        Texture2D BtnTexLeft, BtnTexMid, BtnTexRight, TxtTexLeft, TxtTexMid, TxtTexRight, LogoTexture;
        Textbox UserName, Server;
        PWTextbox Password;
        float zoom = 0;
        public MainMenu()
        {
            LogoTexture = Misc.Content.Load<Texture2D>("logo");

            BtnTexLeft = Misc.Content.Load<Texture2D>("ButtonLeft");
            BtnTexMid = Misc.Content.Load<Texture2D>("ButtonMid");
            BtnTexRight = Misc.Content.Load<Texture2D>("ButtonRight");

            TxtTexLeft = Misc.Content.Load<Texture2D>("TextboxLeft");
            TxtTexMid = Misc.Content.Load<Texture2D>("TextboxMid");
            TxtTexRight = Misc.Content.Load<Texture2D>("TextboxRight");

            Logo = new Sprite(LogoTexture);

            MainMenuBackground = new Background(Misc.Content.Load<Texture2D>("background"));

            Play = new Button(BtnTexLeft, BtnTexMid, BtnTexRight, 40, Vector2.Zero, "Connect", Misc.BigFont);
            Exit = new Button(BtnTexLeft, BtnTexMid, BtnTexRight, 40, Vector2.Zero, "Quit Game", Misc.BigFont);

            UserName = new Textbox(TxtTexLeft, TxtTexMid, TxtTexRight, 40, Vector2.Zero, "Username:", Misc.BigFont, Misc.NormalFont);
            Password = new PWTextbox(TxtTexLeft, TxtTexMid, TxtTexRight, 40, Vector2.Zero, "Password:", Misc.BigFont, Misc.NormalFont);
            Server = new Textbox(TxtTexLeft, TxtTexMid, TxtTexRight, 100, Vector2.Zero, "Server:", Misc.BigFont, Misc.NormalFont);

            UserName.SetTextLength(16);
            Password.SetTextLength(64);
            Server.SetTextLength(32);

            UserName.SetText(Storage.Network.UserName);
            Password.SetText(Storage.Network.Password);
            Server.SetText(Storage.Network.Server);

        }

        public void Update()
        {
            Play.SetPosition(new Vector2(Misc.Width / 16 * 11 - Play.GetWidth / 2, (float)(Misc.Height - BtnTexMid.Height * 1.5)));
            Play.Update(Misc.mouseState);

            Exit.SetPosition(new Vector2(Misc.Width / 16 * 5 - Exit.GetWidth / 2, (float)(Misc.Height - BtnTexMid.Height * 1.5)));
            Exit.Update(Misc.mouseState);

            UserName.SetPosition(new Vector2(Misc.Width / 16 * 5 - UserName.GetWidth / 2, (float)(Misc.Height - BtnTexMid.Height * 4.5)));
            UserName.Update(Misc.mouseState, Misc.keyboardState);

            Password.SetPosition(new Vector2(Misc.Width / 16 * 11 - Password.GetWidth / 2, (float)(Misc.Height - BtnTexMid.Height * 4.5)));
            Password.Update(Misc.mouseState, Misc.keyboardState);

            Server.SetBtnWidth((Misc.Width - (Misc.Width / 8 * 5 - Exit.GetWidth)) / 8 - 2);
            Server.SetPosition(new Vector2(Misc.Width / 16 * 5 - Exit.GetWidth / 2, (float)(Misc.Height - BtnTexMid.Height * 3)));
            Server.Update(Misc.mouseState, Misc.keyboardState);

            Logo.SetPosition(new Vector2(Misc.Width / 2 - Logo.GetWidth / 2, Misc.Height / 16 * 4 - Logo.GetHeight / 2));

            if (Exit.isClicked)
                Misc.CurrentGameState = Misc.GameState.Exit;

            if (Play.isClicked)
                Misc.CurrentGameState = Misc.GameState.InGame;

            Password.Update(Misc.mouseState, Misc.keyboardState);
            Server.Update(Misc.mouseState, Misc.keyboardState);

            Storage.Network.UserName = UserName.GetText();
            Storage.Network.Password = Password.GetText();
            string server = Server.GetText();

            if (server.Contains(':'))
            {
                Storage.Network.Server = server.Split(':').First();
                Storage.Network.Port = (int)Convert.ToUInt16(server.Split(':').Last());
            }
            else
            {
                Storage.Network.Server = server;
                Storage.Network.Port = 25565;
            }
        }

        public void Draw()
        {
            MainMenuBackground.Draw(Misc.spriteBatch);

            Play.Draw(Misc.spriteBatch);
            Exit.Draw(Misc.spriteBatch);

            UserName.Draw(Misc.spriteBatch);
            Password.Draw(Misc.spriteBatch);
            Server.Draw(Misc.spriteBatch);

            Logo.Draw(Misc.spriteBatch);

            zoom += 0.03f;
            Misc.spriteBatch.DrawString(Misc.NormalFont, "Not finished yet!", new Vector2(950, 250), Color.Yellow, -0.3f, new Vector2(100, 30), 1.5f + (float)Math.Abs(Math.Sin(zoom)) /2, SpriteEffects.None, 0);
        }
    }
}
