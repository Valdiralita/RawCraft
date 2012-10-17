using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using RawCraft.Network;

namespace RawCraft.Storage
{
    class Misc
    {
        public static bool isConnected = true, VSync = true, EnableLog = false;
        public static int Width = 1280, Height = 720;

        public static Stopwatch RendertimeCounter = new Stopwatch();
        public static GameState CurrentGameState = GameState.MainMenu;

        public static GraphicsDevice graphics;
        public static Effect effect;
        public static SpriteBatch spriteBatch;
        public static ContentManager Content;
        public static KeyboardState keyboardState;
        public static MouseState mouseState;
        public static SpriteFont BigFont, NormalFont;

        public static Logging Log;

        public enum GameState
        {
            MainMenu,
            Options,
            InGame,
            NoInterface,
            Exit
        }

        public static Vector3[] normals =
        {
            new Vector3(0, 0, 1),  //5
            new Vector3(0, 0, -1), //2
            new Vector3(1, 0, 0),  //3
            new Vector3(-1, 0, 0), //4
            new Vector3(0, 1, 0),  //6
            new Vector3(0, -1, 0)  //1
        };
    }
}
