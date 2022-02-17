using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoCelesteClassic
{
    public enum Facings
    {
        Left = -1,
        Right = 1
    }

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
                new VirtualAxis.PadDpadLeftRight(1),
                new VirtualAxis.PadLeftStickX(1, 0.2f)
            );

            MoveY = new VirtualAxis(
                new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehaviors.CancelOut, Keys.W, Keys.S),
                new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehaviors.CancelOut, Keys.Up, Keys.Down),
                new VirtualAxis.PadDpadUpDown(1),
                new VirtualAxis.PadLeftStickY(1, 0.2f)
            );

            Jump = new VirtualButton(
                0.15f,
                new VirtualButton.KeyboardKey(Keys.Z),
                new VirtualButton.KeyboardKey(Keys.C),
                new VirtualButton.PadButton(1, Buttons.A)
            );

            Dash = new VirtualButton(
                0.15f,
                new VirtualButton.KeyboardKey(Keys.X),
                new VirtualButton.KeyboardKey(Keys.V),
                new VirtualButton.PadButton(1, Buttons.X),
                new VirtualButton.PadButton(1, Buttons.B)
            );
        }

        public static Vector2 GetAimVector(Facings facing)
        {
            if (MoveX == 0 && MoveY == 0) {
                return new Vector2((int) facing, MoveY);
            }

            return new Vector2(MoveX, MoveY);
        }
    }
}
