using System.Linq;
using System.Collections.Concurrent;
using RawCraft.Storage;
using RawCraft.Storage.Map;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RawCraft.Renderer
{
    class RenderFIFO
    {
        private static ConcurrentQueue<Chunk> _renderQueue = new ConcurrentQueue<Chunk>();
        private static AutoResetEvent _queueNotifier = new AutoResetEvent(false);

        public void MeshGenerateThread(object gd)
        {
            while (true)
            {
                _queueNotifier.WaitOne();
                while (_renderQueue.Count != 0)
                {
                    Chunk chunk;
                    if (_renderQueue.TryDequeue(out chunk))
                    {
                        Debug.RendertimeCounter.Start();
                        chunk.UpdateMesh((GraphicsDevice)gd);
                        Debug.RendertimeCounter.Stop();
                    }
                }
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