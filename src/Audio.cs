using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace MonoCelesteClassic
{
    /// <summary>
    /// Simple container for all audio assets and playing them. These get loaded in Celeste.LoadContent();
    /// </summary>
    public static class Audio
    {
        public static Dictionary<string, SoundEffect> Bgm = new Dictionary<string, SoundEffect>();
        public static Dictionary<string, SoundEffect> Sfx = new Dictionary<string, SoundEffect>();

        public static SoundEffectInstance NowPlaying = null;

        public static void Play(string sfxIndex)
        {
            Sfx[sfxIndex].Play();
        }

        public static void Play (SoundEffect sfx)
        {
            sfx.Play();
        }

        public static void SetMusic(string bgmIndex)
        {
            if (bgmIndex == null) {
                NowPlaying.Stop();
                NowPlaying.Dispose();

                return;
            }

            if (NowPlaying != null) {
                NowPlaying.Stop();
                NowPlaying.Dispose();
            }

            NowPlaying = Bgm[bgmIndex].CreateInstance();
            NowPlaying.Play();
            NowPlaying.IsLooped = true;
        }
    }
}
