﻿using System.Collections.Concurrent;
using Microsoft.Xna.Framework;

namespace RawCraft.Storage.Map
{
    static class MapChunks
    {
        public static ConcurrentDictionary<Vector2, Chunk> Map = new ConcurrentDictionary<Vector2, Chunk>();

        public static void Disconnect()
        {
            Map = new ConcurrentDictionary<Vector2, Chunk>();
        }
    }
}