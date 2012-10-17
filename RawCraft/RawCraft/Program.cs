using System;
using System.Threading;
using System.IO;
using Ionic.Zip;
using Microsoft.Xna.Framework.Graphics;

namespace RawCraft
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Main game = new Main())
            {
                game.Run();
            }
        }
    }
}

