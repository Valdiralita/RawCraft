using RawCraft.Storage.Map;
using Microsoft.Xna.Framework;

namespace RawCraft.Network.Packets
{
    class MultiBlockChange
    {
        EnhancedStream _stream;

        public MultiBlockChange(EnhancedStream s) 
        {
            _stream = s;
            int chunkx = s.ReadInt();
            int chunkz = s.ReadInt();
            int count = s.ReadShort();
            s.ReadInt();

            UpdateChunk(chunkx, chunkz, count);
        }

        private void UpdateChunk(int chunkx, int chunkz, int count)
        {
            Chunk c;
            byte[][] data = new byte[count][];
        
            if (MapChunks.Map.TryGetValue(new Vector2(chunkx, chunkz), out c))
            {
                for (int i = 0; i < count; i++)
                {
                    data[i] = _stream.ReadData(4);
                }
                c.MultiBlockChange(data, count);
            }
        }
    }
}
