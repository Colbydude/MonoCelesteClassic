using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoCelesteClassic
{
    public enum Facings
    {
        Left = -1,
        Right = 1
    }

    /// <summary>
    /// Global input manager.
    /// </summary>
    public static class Input
    {
        // axes
        public static VirtualAxis MoveX;
        public static VirtualAxis MoveY;

        // buttons
        public static VirtualButton Jump;
        public static VirtualButton Dash;

        internal static void Bind()
        {
            MoveX = new VirtualAxis(
                new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehaviors.CancelOut, Keys.A, Keys.D),
                new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehaviors.CancelOut, Keys.Left, Keys.Right),
                new VirtualAxis.PadDpadLeftRight(0),
                new VirtualAxis.PadLeftStickX(0, 0.2f)
            );

            MoveY = new VirtualAxis(
                new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehaviors.CancelOut, Keys.W, Keys.S),
                new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehaviors.CancelOut, Keys.Up, Keys.Down),
                new VirtualAxis.PadDpadUpDown(0),
                new VirtualAxis.PadLeftStickY(0, 0.2f)
            );

            Jump = new VirtualButton(
                0.15f,
                new VirtualButton.KeyboardKey(Keys.Z),
                new VirtualButton.KeyboardKey(Keys.C),
                new VirtualButton.PadButton(0, Buttons.A)
            );

            Dash = new VirtualButton(
                0.15f,
                new VirtualButton.KeyboardKey(Keys.X),
                new VirtualButton.KeyboardKey(Keys.V),
                new VirtualButton.PadButton(0, Buttons.X),
                new VirtualButton.PadButton(0, Buttons.B)
            );
        }

        /// <summary>
        /// Simple helper for determining the dash direction.
        /// </summary>
        /// <param name="facing"></param>
        /// <returns></returns>
        public static Vector2 GetAimVector(Facings facing)
        {
            if (MoveX == 0 && MoveY == 0) {
                return new Vector2((int) facing, MoveY);
            }

            return new Vector2(MoveX, MoveY);
        }
    }
}
