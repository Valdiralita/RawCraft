using System.Linq;
using System.Collections.Concurrent;
using RawCraft.Storage;
using RawCraft.Storage.Map;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace RawCraft.Renderer
{
    class RenderFIFO
    {
        private static ManualResetEvent _queueNotifier = new ManualResetEvent(false);
        private static ConcurrentQueue<Chunk> _renderQueue = new ConcurrentQueue<Chunk>();

        public void CreateThreads(object gd)
        {
            for (int i = 0; i < 4; i++)
            {
                Renderer rT = new Renderer(_renderQueue, gd, _queueNotifier, i);
                Thread _thread = new Thread(rT.RenderThread); 
                _thread.Priority = ThreadPriority.Lowest;
                _thread.IsBackground = true;
                _thread.Start();
            }
        }

        public static int Count
        {
            get { return _renderQueue.Count; }
        }

        public static void Enqueue(Chunk c, bool[] toRender)
        {
            Chunk adjacentChunk;

            if (!_renderQueue.Contains(c))
                _renderQueue.Enqueue(c);

            if (toRender[0] && MapChunks.Map.TryGetValue(new Vector2(c.ChunkX + 1, c.ChunkZ), out adjacentChunk))        // check if there is a chunk (at the vector2 position) and rerender it
                if (!_renderQueue.Contains(adjacentChunk))                                                                   // dont enqueue the chunk if its already in queue
                    _renderQueue.Enqueue(adjacentChunk);

            if (toRender[1] && MapChunks.Map.TryGetValue(new Vector2(c.ChunkX - 1, c.ChunkZ), out adjacentChunk))
                if (!_renderQueue.Contains(adjacentChunk))
                    _renderQueue.Enqueue(adjacentChunk);

            if (toRender[2] && MapChunks.Map.TryGetValue(new Vector2(c.ChunkX, c.ChunkZ + 1), out adjacentChunk))
                if (!_renderQueue.Contains(adjacentChunk))
                    _renderQueue.Enqueue(adjacentChunk);

            if (toRender[3] && MapChunks.Map.TryGetValue(new Vector2(c.ChunkX, c.ChunkZ - 1), out adjacentChunk))
                if (!_renderQueue.Contains(adjacentChunk))
                    _renderQueue.Enqueue(adjacentChunk);

            _queueNotifier.Set();
        }
    }
}