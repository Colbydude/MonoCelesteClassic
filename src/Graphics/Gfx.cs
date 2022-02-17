using System.Collections.Generic;

namespace MonoCelesteClassic
{
    /// <summary>
    /// Simple container for all graphic assets. These get loaded in Celeste.LoadContent().
    /// </summary>
    public static class Gfx
    {
        public static Dictionary<string, MTexture> Game = new Dictionary<string, MTexture>();
    }
}
