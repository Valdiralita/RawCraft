using System;
using System.Threading;
using System.IO;

namespace RawCraft
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            // Attempt to get texture pack
            if (File.Exists(Path.Combine(MinecraftUtilities.DotMinecraft, "bin", "minecraft.jar")))
            {
                
            }

            using (Main game = new Main())
            {
                game.Run();
            }
        }
    }
}

