using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Renderer;
using System.Collections.Concurrent;
using Microsoft.Xna.Framework;

namespace Storage
{
    static class MapChunks
    {
        public static ConcurrentDictionary<Vector2, Chunk> Chunks = new ConcurrentDictionary<Vector2, Chunk>();
        
        public static void Disconnect()
        {
            Chunks = new ConcurrentDictionary<Vector2, Chunk>();
        }

    }
}