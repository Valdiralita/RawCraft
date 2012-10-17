using System;
using System.Collections.Generic;
using System.Linq;
using Ionic.Zip;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;
using System.Collections.ObjectModel;
using Network;
using Storage;
using Renderer;
using Interface;
using Menu;
using System.IO;

namespace RawCraft
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        //Slotbar Slotbar;
        Thread NetworkThread, Render;
        Camera camera;
        StatisticOverlay Statistics;
        Texture2D Terrain; // TerrainEM;
        MainMenu mainMenu;
        DepthStencilState depthState, depthStateOff;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Misc.Content = Content;
            Misc.Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged); //resize function
        }

        protected override void Initialize()
        {
            VertexPositions.Initialize();
            Menu.EventInput.Initialize(this.Window);
            Blocks.InitialzizeBlocks();

            graphics.PreferredBackBufferWidth = Misc.Width;
            graphics.PreferredBackBufferHeight = Misc.Height;


            if (!Misc.VSync)
            {
                this.IsFixedTimeStep = false;
                graphics.SynchronizeWithVerticalRetrace = false;
            }
            graphics.ApplyChanges();
            base.Initialize();

            camera = new Camera(1f, 0.001f, GraphicsDevice); //move speed, rotate speed, devic
            //Slotbar = new Slotbar(Window.ClientBounds.Width, Window.ClientBounds.Height);
            Misc.spriteBatch = new SpriteBatch(GraphicsDevice);

            Statistics = new StatisticOverlay(Misc.NormalFont, new Vector2(48, 48));
            mainMenu = new MainMenu();

            InitializeEffect();
        }

        protected override void LoadContent()
        {
            //TerrainEM = Misc.Content.Load<Texture2D>("terrainEM");
            Misc.NormalFont = Misc.Content.Load<SpriteFont>("NormalFont");
            Misc.BigFont = Misc.Content.Load<SpriteFont>("BigFont");

            if (File.Exists("terrain.png"))
                Terrain = Texture2D.FromStream(GraphicsDevice, File.Open("terrain.png", FileMode.Open));
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
                            Terrain = Texture2D.FromStream(GraphicsDevice, ms);
                        }
                        else
                            throw new FileNotFoundException("Missing terrain.png!");
                    }
                }
                else
                    throw new FileNotFoundException("Missing terrain.png!");
            }
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            Misc.keyboardState = Keyboard.GetState();
            Misc.mouseState = Mouse.GetState();

            switch (Misc.CurrentGameState)
            {
                case Misc.GameState.Exit:
                    {
                        CloseGame();
                        break;
                    }
                case Misc.GameState.MainMenu:
                    {
                        mainMenu.Update();
                        IsMouseVisible = true;
                        break;
                    }
                case Misc.GameState.Options:
                    {
                        break;
                    }
                case Misc.GameState.NoInterface:
                case Misc.GameState.InGame:
                    {
                        if (NetworkThread == null)
                            Connect();

                        IsMouseVisible = false;
                        camera.Update();

                        Misc.effect.Parameters["View"].SetValue(camera.ViewMatrix);

                        if (Misc.keyboardState.IsKeyDown(Keys.Escape))
                        {
                            Disconnect();
                            Misc.CurrentGameState = Misc.GameState.MainMenu;
                        }

                        break;
                    }
            }
            Statistics.UpdateText(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Misc.graphics.Clear(Color.CornflowerBlue);

            switch (Misc.CurrentGameState)
            {
                case Misc.GameState.MainMenu:
                    {
                        Misc.spriteBatch.Begin();
                        mainMenu.Draw();
                        Misc.spriteBatch.End();

                        break;
                    }
                // case Misc.GameState.Options:
                //     {
                //         break;
                //     }
                // case Misc.GameState.NoInterface:
                case Misc.GameState.InGame:
                    {
                        ApplyEffects();

                        Misc.graphics.DepthStencilState = depthState;
                        
                        foreach (KeyValuePair<Vector2, Chunk> item in MapChunks.Chunks)
                        {
                            item.Value.DrawOpaque();
                        }

                        Misc.graphics.DepthStencilState = depthStateOff;

                        foreach (KeyValuePair<Vector2, Chunk> item in MapChunks.Chunks)
                        {
                            item.Value.DrawWater();
                        }

                        break;
                    }
            }

            Misc.spriteBatch.Begin();
            Statistics.Draw();
            Misc.spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ApplyEffects()
        {
            Misc.effect.Parameters["vecViewPos"].SetValue(new Vector3((float)Storage.Player.X, (float)Storage.Player.Y, (float)Storage.Player.Z));
            Misc.graphics.SamplerStates[0] = SamplerState.PointClamp;
            Misc.graphics.SamplerStates[1] = SamplerState.PointClamp;
           // Misc.graphics.BlendState = BlendState.Opaque;


           
        }

        private void InitializeEffect()
        {
            Misc.graphics = GraphicsDevice;

            depthState = new DepthStencilState();
            depthState.DepthBufferEnable = true;
            depthState.DepthBufferWriteEnable = true;
            depthState.ReferenceStencil = 10;
            depthState.StencilFunction = CompareFunction.LessEqual;

            depthStateOff = new DepthStencilState();
            depthStateOff.DepthBufferEnable = true;
            depthStateOff.DepthBufferWriteEnable = false;

            Misc.effect = Content.Load<Effect>("Effect");
            Misc.effect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(0, 0, 0)));
            Misc.effect.Parameters["Projection"].SetValue(camera.ProjectionMatrix);
            Misc.effect.Parameters["entSkin1"].SetValue(Terrain);

          
            //Misc.effect.Parameters["entSkin2"].SetValue(TerrainEM);

            Misc.effect.Parameters["vecSunDir"].SetValue(new Vector3(1, 5, 2));
            //Misc.effect.Parameters["vecAmbient"].SetValue(new Vector3(150f / 255, 150f / 255, 150f / 255));
            Misc.effect.Parameters["vecAmbient"].SetValue(new Vector3(90f / 255, 115f / 255, 130f / 255));
            Misc.effect.Parameters["vecSunColor"].SetValue(new Vector3(198f / 255, 169f / 255, 134f / 255));

            // RasterizerState rs = new RasterizerState(); //reduce triangles 
            // rs.CullMode = CullMode.CullCounterClockwiseFace;
            // Misc.effect.GraphicsDevice.RasterizerState = rs; // call it every frame

        }

        private void Connect()
        {
            TextureCoordinates.InitializeTextures();

            NetworkThread = new Thread(new Network.Network().NetThread);
            NetworkThread.Start();

            Render = new Thread(new RenderFIFO().MeshGenerateThread);
            Render.Start();
        }

        public void CloseGame()
        {
            Disconnect();
            this.Exit();
        }

        public void Disconnect() // does not work!
        {
            if (Render != null)
            {
                Render.Abort(); //nothing to do here
                Render = null;
            }

            if (NetworkThread != null)
            {
                NetworkThread.Abort(); //maybe send a 0xFF
                NetworkThread = null;
            }

            MapChunks.Disconnect();
        }

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            Misc.Height = Window.ClientBounds.Height;
            Misc.Width = Window.ClientBounds.Width;
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            //Slotbar = new Slotbar(Window.ClientBounds.Width, Window.ClientBounds.Height);
        }

    }
}
