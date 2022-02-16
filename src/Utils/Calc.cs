using Microsoft.Xna.Framework;
using System;

namespace MonoCelesteClassic
{
    public static class Calc
    {
        #region Consts

        public const float TAU = MathF.PI * 2f;

        #endregion

        public static Random Random = new Random();

        public static Color HexToColor(string hex)
        {
            byte r, g, b;

            if (hex.StartsWith('#')) {
                hex = hex.Substring(1, 6);
            }

            r = byte.Parse(hex.Substring(0, 2));
            g = byte.Parse(hex.Substring(2, 2));
            b = byte.Parse(hex.Substring(4, 2));

            return new Color(r, g, b);
        }
    }
}
