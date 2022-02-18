using Microsoft.Xna.Framework.Audio;
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

            // Load music.
            Audio.Bgm.Add("mus0", Content.Load<SoundEffect>("Audio/Music/mus0"));
            Audio.Bgm.Add("mus10", Content.Load<SoundEffect>("Audio/Music/mus10"));
            Audio.Bgm.Add("mus20", Content.Load<SoundEffect>("Audio/Music/mus20"));
            Audio.Bgm.Add("mus30", Content.Load<SoundEffect>("Audio/Music/mus30"));
            Audio.Bgm.Add("mus40", Content.Load<SoundEffect>("Audio/Music/mus40"));
            Audio.Bgm.Add("pico8boot", Content.Load<SoundEffect>("Audio/Music/pico8boot"));

            // Load sound effects.
            Audio.Sfx.Add("snd0", Content.Load<SoundEffect>("Audio/SoundEffects/snd0"));
            Audio.Sfx.Add("snd1", Content.Load<SoundEffect>("Audio/SoundEffects/snd1"));
            Audio.Sfx.Add("snd2", Content.Load<SoundEffect>("Audio/SoundEffects/snd2"));
            Audio.Sfx.Add("snd3", Content.Load<SoundEffect>("Audio/SoundEffects/snd3"));
            Audio.Sfx.Add("snd4", Content.Load<SoundEffect>("Audio/SoundEffects/snd4"));
            Audio.Sfx.Add("snd5", Content.Load<SoundEffect>("Audio/SoundEffects/snd5"));
            Audio.Sfx.Add("snd6", Content.Load<SoundEffect>("Audio/SoundEffects/snd6"));
            Audio.Sfx.Add("snd7", Content.Load<SoundEffect>("Audio/SoundEffects/snd7"));
            Audio.Sfx.Add("snd8", Content.Load<SoundEffect>("Audio/SoundEffects/snd8"));
            Audio.Sfx.Add("snd9", Content.Load<SoundEffect>("Audio/SoundEffects/snd9"));
            Audio.Sfx.Add("snd13", Content.Load<SoundEffect>("Audio/SoundEffects/snd13"));
            Audio.Sfx.Add("snd14", Content.Load<SoundEffect>("Audio/SoundEffects/snd14"));
            Audio.Sfx.Add("snd15", Content.Load<SoundEffect>("Audio/SoundEffects/snd15"));
            Audio.Sfx.Add("snd16", Content.Load<SoundEffect>("Audio/SoundEffects/snd16"));
            Audio.Sfx.Add("snd23", Content.Load<SoundEffect>("Audio/SoundEffects/snd23"));
            Audio.Sfx.Add("snd35", Content.Load<SoundEffect>("Audio/SoundEffects/snd35"));
            Audio.Sfx.Add("snd37", Content.Load<SoundEffect>("Audio/SoundEffects/snd37"));
            Audio.Sfx.Add("snd38", Content.Load<SoundEffect>("Audio/SoundEffects/snd38"));
            Audio.Sfx.Add("snd40", Content.Load<SoundEffect>("Audio/SoundEffects/snd40"));
            Audio.Sfx.Add("snd50", Content.Load<SoundEffect>("Audio/SoundEffects/snd50"));
            Audio.Sfx.Add("snd51", Content.Load<SoundEffect>("Audio/SoundEffects/snd51"));
            Audio.Sfx.Add("snd54", Content.Load<SoundEffect>("Audio/SoundEffects/snd54"));
            Audio.Sfx.Add("snd55", Content.Load<SoundEffect>("Audio/SoundEffects/snd55"));
        }
    }
}
