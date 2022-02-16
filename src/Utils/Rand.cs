using System;

namespace MonoCelesteClassic
{
    public static class Rand
    {
        public static float NextFloat(this Random random)
        {
            return (float) random.NextDouble();
        }

        public static float NextFloat(this Random random, float max)
        {
            return random.NextFloat() * max;
        }
    }
}
