using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace MonoCelesteClassic
{
    /// <summary>
    /// Simple container for all audio assets and playing them. These get loaded in Celeste.LoadContent();
    /// </summary>
    public static class Audio
    {
        public static Dictionary<string, Song> Bgm = new Dictionary<string, Song>();
        public static Dictionary<string, SoundEffect> Sfx = new Dictionary<string, SoundEffect>();

        public static Song NowPlaying = null;

        public static void Play(string sfxIndex)
        {
            Sfx[sfxIndex].CreateInstance().Play();
        }

        public static void SetMusic(string bgmIndex)
        {
            if (NowPlaying != null) {
                MediaPlayer.Stop();
            }

            MediaPlayer.Play(Bgm[bgmIndex]);
        }
    }
}
