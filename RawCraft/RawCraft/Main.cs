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
using Microsoft.Xna.Framework.Content;

namespace RawCraft
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        Effect effect;
        Thread networkThread, render;
        Camera camera;
        StatisticOverlay statistics;
        Texture2D terrain;
        MainMenu mainMenu;
        DepthStencilState depthState, depthStateOff;
        GameState currentGameState;
        SpriteBatch spriteBatch;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            currentGameState = GameState.MainMenu;
            base.Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += Window_ClientSizeChanged; //resize function
        }

        protected override void Initialize()
        {
            VertexPositions.Initialize();
            EventInput.Initialize(Window);
            Blocks.InitialzizeBlocks();

            graphics.PreferredBackBufferWidth = Config.Width;
            graphics.PreferredBackBufferHeight = Config.Height;

            if (!Config.VSync)
            {
                IsFixedTimeStep = false;
                graphics.SynchronizeWithVerticalRetrace = false;
            }
            graphics.ApplyChanges();
            base.Initialize();

            camera = new Camera(0.3f, 0.001f, GraphicsDevice); //move speed, rotate speed, ...
            spriteBatch = new SpriteBatch(GraphicsDevice);

            statistics = new StatisticOverlay(base.Content.Load<SpriteFont>("NormalFont"), new Vector2(48, 48)); //debug
            mainMenu = new MainMenu(base.Content);

            InitializeEffect();
        }

        protected override void LoadContent()
        {
            string TerrainPath = "Content/terrain.png";

            if (File.Exists(TerrainPath))
                terrain = Texture2D.FromStream(GraphicsDevice, File.Open(TerrainPath, FileMode.Open));
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
                            terrain = Texture2D.FromStream(GraphicsDevice, ms);
                        }
                        else
                            throw new FileNotFoundException("Missing terrain.png!");
                    }
                }
                else
                    throw new FileNotFoundException("Missing terrain.png!");
            }
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            switch (currentGameState)
            {
                case GameState.Exit:
                    CloseGame();
                    break;
                case GameState.MainMenu:
                    currentGameState = mainMenu.Update(mouseState, keyboardState, currentGameState);
                    IsMouseVisible = true;
                    break;
                case GameState.Options:
                        break;
                case GameState.NoInterface:
                case GameState.InGame:
                    if (networkThread == null)
                        Connect();
                    IsMouseVisible = false;
                    camera.Update();

                    effect.Parameters["View"].SetValue(camera.ViewMatrix);

                    if (keyboardState.IsKeyDown(Keys.Escape))
                    {
                        Disconnect();
                        currentGameState = GameState.MainMenu;
                    }
                    break;
            }
            statistics.UpdateText(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (currentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Begin();
                    mainMenu.Draw(spriteBatch);
                    spriteBatch.End();

                    break;
                // case GS.Options:
                //     {
                //         break;
                //     }
                // case GS.NoInterface:
                case GameState.InGame:
                    ApplyEffects();

                    base.GraphicsDevice.DepthStencilState = depthState;
                        
                    foreach (KeyValuePair<Vector2, Chunk> item in MapChunks.Chunks)
                        item.Value.DrawOpaque(effect);

                    base.GraphicsDevice.DepthStencilState = depthStateOff;

                    foreach (KeyValuePair<Vector2, Chunk> item in MapChunks.Chunks)
                        item.Value.DrawWater(effect);

                    break;
            }

            spriteBatch.Begin();
            statistics.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ApplyEffects()
        {
            effect.Parameters["vecViewPos"].SetValue(new Vector3((float)Player.X, (float)Player.Y, (float)Player.Z));
            base.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            base.GraphicsDevice.SamplerStates[1] = SamplerState.PointClamp;
        }

        private void InitializeEffect()
        {
            depthState = new DepthStencilState();
            depthState.DepthBufferEnable = true;
            depthState.DepthBufferWriteEnable = true;
            depthState.ReferenceStencil = 10;
            depthState.StencilFunction = CompareFunction.LessEqual;

            depthStateOff = new DepthStencilState();
            depthStateOff.DepthBufferEnable = true;
            depthStateOff.DepthBufferWriteEnable = false;

            effect = Content.Load<Effect>("Effect");
            effect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(0, 0, 0)));
            effect.Parameters["Projection"].SetValue(camera.ProjectionMatrix);
            effect.Parameters["entSkin1"].SetValue(terrain);

            effect.Parameters["vecSunDir"].SetValue(new Vector3(1, 5, 2));
            //effect.Parameters["vecAmbient"].SetValue(new Vector3(150f / 255, 150f / 255, 150f / 255));
            effect.Parameters["vecAmbient"].SetValue(new Vector3(90f / 255, 115f / 255, 130f / 255));
            effect.Parameters["vecSunColor"].SetValue(new Vector3(198f / 255, 169f / 255, 134f / 255));
        }

        private void Connect()
        {
            TextureCoordinates.InitializeTextures();

            NetworkHandler NetHandler = new NetworkHandler();
            networkThread = new Thread(NetHandler.NetThread);
            networkThread.Start();

            RenderFIFO fifo = new RenderFIFO();
            render = new Thread(fifo.MeshGenerateThread);
            render.Start(base.GraphicsDevice);
        }

        public void CloseGame()
        {
            Disconnect();
            Exit();
        }

        public void Disconnect() // does not work!
        {
            if (render != null)
            {
                render.Abort(); //nothing to do here
                render = null;
            }

            if (networkThread != null)
            {
                networkThread.Abort(); //maybe send a 0xFF
                networkThread = null;
            }

            MapChunks.Disconnect();
        }

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            Config.Height = Window.ClientBounds.Height;
            Config.Width = Window.ClientBounds.Width;
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
        }
    }
}
