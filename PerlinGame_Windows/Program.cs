using System;
using PerlinGame_Shared;

namespace PerlinGame_Windows
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new PerlinGame())
                game.Run();
        }
    }
}