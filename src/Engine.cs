using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoCelesteClassic
{
    public class Engine : Game
    {
        public static Engine Instance { get; private set; }
        public static GraphicsDeviceManager Graphics { get; private set; }

        // time
        public static float DeltaTime { get; private set; }
        public static float RawDeltaTime { get; private set; }
        public static float TimeRate = 1f;
        public static float FreezeTimer;
        public static int FPS;
        private TimeSpan counterElapsed = TimeSpan.Zero;
        private int fpsCounter = 0;

        // scene
        private Scene scene;
        private Scene nextScene;

        public Engine()
        {
            Instance = this;

            Graphics = new GraphicsDeviceManager(this);
            // Graphics.DeviceReset += OnGraphicsReset;
            // Graphics.DeviceCreated += OnGraphicsCreate;
            Graphics.SynchronizeWithVerticalRetrace = true;
            Graphics.PreferMultiSampling = false;
            Graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Graphics.PreferredBackBufferFormat = SurfaceFormat.Color;
            Graphics.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;
            Graphics.ApplyChanges();

            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferWidth = 720;

            Window.AllowUserResizing = true;
            // Window.ClientSizeChanged += OnClientSizeChanged;

            // if (fullscreen) {
            //     Graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //     Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //     Graphics.IsFullScreen = true;
            // }

            Content.RootDirectory = @"Content";

            IsMouseVisible = false;
            IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            Gfx.Game.Add("atlas", new MTexture(Content.Load<Texture2D>("Graphics/atlas")));
            Gfx.Game.Add("consolebg", new MTexture(Content.Load<Texture2D>("Graphics/consolebg")));
            Gfx.Game.Add("font", new MTexture(Content.Load<Texture2D>("Graphics/font")));
            Gfx.Game.Add("logo", new MTexture(Content.Load<Texture2D>("Graphics/logo")));

            MonoCelesteClassic.Draw.Initialize(GraphicsDevice);

            Scene = new Emulator();
        }

        protected override void Update(GameTime gameTime)
        {
            RawDeltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            DeltaTime = RawDeltaTime * TimeRate;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Exit();
                return;
            }

            // Update current scene
            if (FreezeTimer > 0)
                FreezeTimer = Math.Max(FreezeTimer - RawDeltaTime, 0);
            else if (scene != null) {
                scene.BeforeUpdate();
                scene.Update();
                scene.AfterUpdate();
            }

            // Changing scenes.
            if (scene != nextScene) {
                var lastScene = scene;
                if (scene != null)
                    scene.End();
                scene = nextScene;
                OnSceneTransition(lastScene, nextScene);
                if (scene != null)
                    scene.Begin();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (scene != null)
                scene.BeforeRender();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Viewport = Viewport;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (scene != null) {
                scene.Render();
                scene.AfterRender();
            }

            base.Draw(gameTime);

            // Frame counter
            fpsCounter++;
            counterElapsed += gameTime.ElapsedGameTime;
            if (counterElapsed >= TimeSpan.FromSeconds(1)) {
                FPS = fpsCounter;
                fpsCounter = 0;
                counterElapsed -= TimeSpan.FromSeconds(1);
            }
        }

        /// <summary>
        /// Called after a Scene ends, before the next Scene begins.
        /// </summary>
        protected virtual void OnSceneTransition(Scene from, Scene to)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            TimeRate = 1f;
        }

        /// <summary>
        /// The currently active Scene. Note that if set, the Scene will not actually change until the end of the Update.
        /// </summary>
        public static Scene Scene
        {
            get { return Instance.scene; }
            set { Instance.nextScene = value; }
        }

        #region Screen

        public static Viewport Viewport { get; private set; }
        public static Matrix ScreenMatrix;

        //@TODO

        #endregion
    }
}
