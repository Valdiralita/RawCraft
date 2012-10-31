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
        private static ConcurrentQueue<Chunk> RenderQueue = new ConcurrentQueue<Chunk>();
        private static AutoResetEvent queueNotifier = new AutoResetEvent(false);

        public void MeshGenerateThread(object gd)
        {
            while (true)
            {
                queueNotifier.WaitOne();
                while (RenderQueue.Count != 0)
                {
                    Chunk chunk;
                    if (RenderQueue.TryDequeue(out chunk))
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
           get { return RenderQueue.Count; }
       }

        public static void Enqueue(Chunk c)
        {
            Chunk AdjacentChunk;

            if (!RenderQueue.Contains(c)) //check if chunk is in queue, if not then enqueue it
                RenderQueue.Enqueue(c);

            if (MapChunks.Chunks.TryGetValue(new Vector2(c.ChunkX + 1, c.ChunkZ + 1), out AdjacentChunk))       //check if there is a chunk (at the vector2 position) and rerender it
                if (!RenderQueue.Contains(AdjacentChunk))                                                       // dont enqueue the chunk if its already in queue
                    RenderQueue.Enqueue(AdjacentChunk);

            if (MapChunks.Chunks.TryGetValue(new Vector2(c.ChunkX - 1, c.ChunkZ + 1), out AdjacentChunk))
                if (!RenderQueue.Contains(AdjacentChunk))
                    RenderQueue.Enqueue(AdjacentChunk);

            if (MapChunks.Chunks.TryGetValue(new Vector2(c.ChunkX + 1, c.ChunkZ - 1), out AdjacentChunk))
                if (!RenderQueue.Contains(AdjacentChunk))
                    RenderQueue.Enqueue(AdjacentChunk);

            if (MapChunks.Chunks.TryGetValue(new Vector2(c.ChunkX - 1, c.ChunkZ - 1), out AdjacentChunk))
                if (!RenderQueue.Contains(AdjacentChunk))
                    RenderQueue.Enqueue(AdjacentChunk);

            queueNotifier.Set();
        }
    }
}
