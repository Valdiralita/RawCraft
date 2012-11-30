using System;
using System.Linq;
using Ionic.Zlib;
using RawCraft.Storage.Map;
using Microsoft.Xna.Framework;

namespace RawCraft.Network.Packets
{
    class ChunkData
    {
        public ChunkData(EnhancedStream stream)
        {
            Store_Chunk(
                stream.ReadInt(),
                stream.ReadInt(),
                (byte)stream.ReadByte(),
                (ushort)stream.ReadShort(),
                stream.ReadShort(),
                ZlibStream.UncompressBuffer(
                stream.ReadData(
                stream.ReadInt())));
        }

        private void Store_Chunk(int x, int z, byte groundUp, ushort primBit, short addBit, byte[] uncompressedChunkData)
        {
            int sectioncount = Convert.ToString(primBit, 2).ToCharArray().Count(a => a == '1');

            Chunk c;
            if (MapChunks.Map.TryGetValue(new Vector2(x, z), out c))
            {
                //c.SetChunk(bitmask, chunkdata, sectioncount);
            }
            else
            {
                c = new Chunk(x, z, sectioncount, primBit, uncompressedChunkData);
                MapChunks.Map.TryAdd(new Vector2(x, z), c);
            }
        }
    }
}
