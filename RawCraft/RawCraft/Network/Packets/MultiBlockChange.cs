using System;
using System.IO;
using RawCraft.Storage.Map;
using Microsoft.Xna.Framework;

namespace RawCraft.Network.Packets
{
    class MultiBlockChange
    {
        EnhancedStream stream;

        public MultiBlockChange(EnhancedStream s) 
        {
            stream = s;
            int chunkx = s.ReadInt();
            int chunkz = s.ReadInt();
            int count = s.ReadShort();
            int datacount = s.ReadInt();

            if (count * 4 != datacount)
                throw new Exception();

            UpdateChunk(chunkx, chunkz, count);
        }

        private void UpdateChunk(int chunkx, int chunkz, int count)
        {
            Chunk c;
        
            if (MapChunks.Chunks.TryGetValue(new Vector2(chunkx, chunkz), out c))
            {
                Console.WriteLine(count);
                for (int i = 0; i < count; i++)
                {
                    byte[] data = stream.ReadData(4);
        
                    int offsetX = (data[0] >> 4) & 0x0F;
                    int offsetZ = data[0] & 0x0F;
        
                    byte meta = (byte)(data[3] & 0x0F);
                    byte id = (byte)((data[2] << 4 | (data[3] >> 4) & 0x0F));
                    c.ChangeBlock(new Vector3(offsetX, data[1], offsetZ), id, meta, true);
                }

                c.EnqueueToRender();
            }
        }
    }
}
