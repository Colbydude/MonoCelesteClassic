using Microsoft.Xna.Framework.Graphics;

namespace MonoCelesteClassic
{
    /// <summary>
    /// Main entry point for the game.
    /// </summary>
    public class Celeste : Engine
    {
        public const int TargetWidth = 1920;
        public const int TargetHeight = 1080;

        public Celeste() : base(TargetWidth, TargetHeight, TargetWidth, TargetHeight, "Mono Celeste Classic", false) {
            //
        }

        protected override void Initialize()
        {
            base.Initialize();

            Input.Bind();

            Scene = new Emulator();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            // Load graphics.
            Gfx.Game.Add("atlas", new MTexture(Content.Load<Texture2D>("Graphics/atlas")));
            Gfx.Game.Add("consolebg", new MTexture(Content.Load<Texture2D>("Graphics/consolebg")));
            Gfx.Game.Add("font", new MTexture(Content.Load<Texture2D>("Graphics/font")));
            Gfx.Game.Add("logo", new MTexture(Content.Load<Texture2D>("Graphics/logo")));

            // Load audio.
            // @TODO
        }
    }
}
