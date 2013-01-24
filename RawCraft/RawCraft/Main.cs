using System;
using System.Collections.Generic;
using Ionic.Zip;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using RawCraft.Interface;
using RawCraft.Menu.BaseClasses;
using RawCraft.Menu.MainMenu;
using RawCraft.Renderer;
using RawCraft.Storage;
using RawCraft.Storage.Blocks;
using RawCraft.Storage.Map;
using System.IO;
using RawCraft.Network;

namespace RawCraft
{
    public class Main : Game
    {
        GraphicsDeviceManager _graphics;
        Effect _effect;
        Thread _networkThread, _render;
        Camera _camera;
        StatisticOverlay _statistics;
        Texture2D _terrain;
        MainMenu _mainMenu;
        DepthStencilState _depthState, _depthStateOff;
        GameState _currentGameState;
        SpriteBatch _spriteBatch;
        RenderFIFO fifo;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            _currentGameState = GameState.MainMenu;
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += Window_ClientSizeChanged; //resize function
        }
        
        protected override void Initialize()
        {
            VertexPositions.Initialize();
            EventInput.Initialize(Window);
            Blocks.InitialzizeBlocks();

            _graphics.PreferredBackBufferWidth = Config.Width;
            _graphics.PreferredBackBufferHeight = Config.Height;

            if (!Config.VSync)
            {
                IsFixedTimeStep = false;
                _graphics.SynchronizeWithVerticalRetrace = false;
            }
            _graphics.ApplyChanges();

            _camera = new Camera(0.3f, 0.002f, GraphicsDevice); //move speed, rotate speed, ...
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _statistics = new StatisticOverlay(Content.Load<SpriteFont>("NormalFont"), new Vector2(48, 48)); //debug
            _mainMenu = new MainMenu(Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            const string terrainPath = "Content/terrain.png";

            if (File.Exists(terrainPath))
                _terrain = Texture2D.FromStream(GraphicsDevice, File.Open(terrainPath, FileMode.Open));
            else
            {
                if (File.Exists(Path.Combine(MinecraftUtilities.DotMinecraft, "bin", "minecraft.jar")))
                {
                    using (var file = new ZipFile(Path.Combine(MinecraftUtilities.DotMinecraft, "bin", "minecraft.jar")))
                    {
                        if (file.ContainsEntry("terrain.png"))
                        {
                            var ms = new MemoryStream();
                            file["terrain.png"].Extract(ms);
                            ms.Seek(0, SeekOrigin.Begin);
                            _terrain = Texture2D.FromStream(GraphicsDevice, ms);
                        }
                        else
                            throw new FileNotFoundException("Missing terrain.png!");
                    }
                }
                else
                    throw new FileNotFoundException("Missing terrain.png!");
            }

            InitializeEffect();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            switch (_currentGameState)
            {
                case GameState.Exit:
                    CloseGame();
                    break;
                case GameState.MainMenu:
                    _currentGameState = _mainMenu.Update(mouseState, keyboardState, _currentGameState);
                    IsMouseVisible = true;
                    break;
                case GameState.Options:
                        break;
                case GameState.NoInterface:
                case GameState.InGame:
                    if (_networkThread == null)
                        Connect();
                    IsMouseVisible = false;
                    _camera.Update();

                    _effect.Parameters["View"].SetValue(_camera.ViewMatrix);

                    if (keyboardState.IsKeyDown(Keys.Escape))
                    {
                        Disconnect();
                        _currentGameState = GameState.MainMenu;
                    }
                    break;
            }
            _statistics.UpdateText(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (_currentGameState)
            {
                case GameState.MainMenu:
                    _spriteBatch.Begin();
                    _mainMenu.Draw(_spriteBatch);
                    _spriteBatch.End();

                    break;
                // case GS.Options:
                //     {
                //         break;
                //     }
                // case GS.NoInterface:
                case GameState.InGame:
                    ApplyEffects();

                    GraphicsDevice.DepthStencilState = _depthState;
                        
                    foreach (KeyValuePair<Vector2, Chunk> item in MapChunks.Map)
                        item.Value.DrawOpaque(_effect);

                    GraphicsDevice.DepthStencilState = _depthStateOff;

                    foreach (KeyValuePair<Vector2, Chunk> item in MapChunks.Map)
                        item.Value.DrawWater(_effect);

                    break;
            }

            _spriteBatch.Begin();
            _statistics.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ApplyEffects()
        {
            _effect.Parameters["vecViewPos"].SetValue(new Vector3((float)Player.X, (float)Player.Y, (float)Player.Z));
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            GraphicsDevice.SamplerStates[1] = SamplerState.PointClamp;
        }

        private void InitializeEffect()
        {
            _depthState = new DepthStencilState
                {
                    DepthBufferEnable = true,
                    DepthBufferWriteEnable = true,
                    ReferenceStencil = 10,
                    StencilFunction = CompareFunction.LessEqual
                };

            _depthStateOff = new DepthStencilState {DepthBufferEnable = true, DepthBufferWriteEnable = false};

            _effect = Content.Load<Effect>("Effect");
            _effect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(0, 0, 0)));
            _effect.Parameters["Projection"].SetValue(_camera.ProjectionMatrix);
            _effect.Parameters["entSkin1"].SetValue(_terrain);

            _effect.Parameters["vecSunDir"].SetValue(new Vector3(1, 5, 2));
            //effect.Parameters["vecAmbient"].SetValue(new Vector3(150f / 255, 150f / 255, 150f / 255));
            _effect.Parameters["vecAmbient"].SetValue(new Vector3(90f / 255, 115f / 255, 130f / 255));
            _effect.Parameters["vecSunColor"].SetValue(new Vector3(198f / 255, 169f / 255, 134f / 255));
        }

        private void Connect()
        {
            TextureCoordinates.InitializeTextures();

            NetworkHandler netHandler = new NetworkHandler();
            _networkThread = new Thread(netHandler.NetThread);
            _networkThread.IsBackground = true;
            _networkThread.Start();

            fifo = new RenderFIFO();
            _render = new Thread(fifo.CreateThreads);
            _render.IsBackground = true;
            _render.Start(GraphicsDevice);
        }

        public void CloseGame()
        {
            Disconnect();
            Exit();
        }

        public void Disconnect() // does not work!
        {
            MapChunks.Disconnect();
        }

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            Config.Height = Window.ClientBounds.Height;
            Config.Width = Window.ClientBounds.Width;
            _graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            _graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
        }
    }
}
