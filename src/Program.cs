using System;

namespace MonoCelesteClassic
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Celeste())
                game.Run();
        }
    }
}
