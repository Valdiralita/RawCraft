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
        Background _mainMenuBackground;
        Button _play, _exit;
        Sprite _logo;
        Texture2D _btnTexLeft, _btnTexMid, _btnTexRight, _txtTexLeft, _txtTexMid, _txtTexRight, _logoTexture;
        Textbox _userName, _server;
        PasswordBox _password;
        SpriteFont _bigFont, _normalFont;
        float _zoom;

        public MainMenu(ContentManager content)
        {
            _bigFont = content.Load<SpriteFont>("BigFont");
            _normalFont = content.Load<SpriteFont>("NormalFont");

            _logoTexture = content.Load<Texture2D>("logo");

            _btnTexLeft = content.Load<Texture2D>("ButtonLeft");
            _btnTexMid = content.Load<Texture2D>("ButtonMid");
            _btnTexRight = content.Load<Texture2D>("ButtonRight");

            _txtTexLeft = content.Load<Texture2D>("TextboxLeft");
            _txtTexMid = content.Load<Texture2D>("TextboxMid");
            _txtTexRight = content.Load<Texture2D>("TextboxRight");

            _logo = new Sprite(_logoTexture);

            _mainMenuBackground = new Background(content.Load<Texture2D>("background"));

            _play = new Button(_btnTexLeft, _btnTexMid, _btnTexRight, 40, "Connect", _bigFont);
            _exit = new Button(_btnTexLeft, _btnTexMid, _btnTexRight, 40, "Quit Game", _bigFont);

            _userName = new Textbox(_txtTexLeft, _txtTexMid, _txtTexRight, 40, Vector2.Zero, "Username:", _bigFont, _normalFont);
            _password = new PasswordBox(_txtTexLeft, _txtTexMid, _txtTexRight, 40, Vector2.Zero, "Password:", _bigFont, _normalFont);
            _server = new Textbox(_txtTexLeft, _txtTexMid, _txtTexRight, 100, Vector2.Zero, "Server:", _bigFont, _normalFont);

            _userName.SetTextLength(16);
            _password.SetTextLength(64);
            _server.SetTextLength(32);

            var login = MinecraftUtilities.GetLastLogin();

            if (login != null)
            {
                _userName.SetText(login.Username);
                _password.SetText(login.Password);
            }
        }

        public GameState Update(MouseState mouseState, KeyboardState keyboardState, GameState currentGS)
        {
            _play.SetPosition(new Vector2(Config.Width / 16 * 11 - _play.GetWidth / 2, (float)(Config.Height - _btnTexMid.Height * 1.5)));
            _play.Update(mouseState);

            _exit.SetPosition(new Vector2(Config.Width / 16 * 5 - _exit.GetWidth / 2, (float)(Config.Height - _btnTexMid.Height * 1.5)));
            _exit.Update(mouseState);

            _userName.SetPosition(new Vector2(Config.Width / 16 * 5 - _userName.GetWidth / 2, (float)(Config.Height - _btnTexMid.Height * 4.5)));
            _userName.Update(mouseState, keyboardState);

            _password.SetPosition(new Vector2(Config.Width / 16 * 11 - _password.GetWidth / 2, (float)(Config.Height - _btnTexMid.Height * 4.5)));
            _password.Update(mouseState, keyboardState);

            _server.SetBtnWidth((Config.Width - (Config.Width / 8 * 5 - _exit.GetWidth)) / 8 - 2);
            _server.SetPosition(new Vector2(Config.Width / 16 * 5 - _exit.GetWidth / 2, Config.Height - _btnTexMid.Height * 3));
            _server.Update(mouseState, keyboardState);

            _logo.SetPosition(new Vector2(Config.Width / 2 - _logo.GetWidth / 2, Config.Height / 16 * 4 - _logo.GetHeight / 2));

            _password.Update(mouseState, keyboardState);
            _server.Update(mouseState, keyboardState);

            if (_exit.IsClicked)
                return GameState.Exit;

            if (_play.IsClicked)
            {
                string serverText = _server.GetText();
                if (serverText.Contains(':'))
                {
                    Storage.Network.Server = serverText.Split(':').First();
                    Storage.Network.Port = Convert.ToUInt16(serverText.Split(':').Last());
                }
                else
                {
                    Storage.Network.Server = serverText;
                    Storage.Network.Port = 25565;
                }
                Storage.Network.UserName = _userName.GetText();
                Storage.Network.Password = _password.GetText();
                return GameState.InGame;
            }
            return currentGS;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _mainMenuBackground.Draw(spriteBatch);

            _play.Draw(spriteBatch);
            _exit.Draw(spriteBatch);

            _userName.Draw(spriteBatch);
            _password.Draw(spriteBatch);
            _server.Draw(spriteBatch);

            _logo.Draw(spriteBatch);

            _zoom += 0.03f;
            spriteBatch.DrawString(_normalFont, "Not finished yet!", new Vector2(950, 250),
                Color.Yellow, -0.3f, new Vector2(100, 30), 1.5f + (float)Math.Abs(Math.Sin(_zoom)) /2, SpriteEffects.None, 0);
        }
    }
}
