using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RawCraft.Storage.Map;
using RawCraft.Storage;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Concurrent;

namespace RawCraft.Renderer
{
    class Renderer
    {
        private ManualResetEvent _queueNotifier;
        private ConcurrentQueue<Chunk> chunkQueue;
        private GraphicsDevice gd;
        int id;

        public Renderer(ConcurrentQueue<Chunk> _renderQueue, object _gd, ManualResetEvent _qn, int i)
        {
            chunkQueue = _renderQueue;
            gd = (GraphicsDevice)_gd; ;
            _queueNotifier = _qn;
            id = i;
        }

        public void RenderThread()
        {
            VertexIndexGenerator gen = new VertexIndexGenerator();
            while (true)
            {
                _queueNotifier.WaitOne();
                while (chunkQueue.Count != 0)
                {
                    Chunk chunk;
                    if (chunkQueue.TryDequeue(out chunk))
                    {
                        chunk.UpdateMesh(gen, (GraphicsDevice)gd);
                    }
                }
                _queueNotifier.Reset();
            }
        }
    }
}
