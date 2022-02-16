using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoCelesteClassic
{
    public class VirtualRenderTarget
    {
        public RenderTarget2D Target { get; private set; }

        public Rectangle Bounds { get { return Target.Bounds; } }
        public int Width { get { return Target.Width; } }
        public int Height { get { return Target.Height; } }

        public VirtualRenderTarget(string name, int width, int height)
        {
            Target = new RenderTarget2D(Engine.Graphics.GraphicsDevice, width, height);
        }
    }
}
