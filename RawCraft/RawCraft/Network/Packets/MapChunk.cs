using System;
using System.Linq;
using Ionic.Zlib;
using System.IO;
using RawCraft.Storage.Map;
using Microsoft.Xna.Framework;

namespace RawCraft.Network.Packets
{
    class MapChunk
    {
        public MapChunk(EnhancedStream stream)
        {
            Store_Chunk(stream.ReadInt(),
                stream.ReadInt(),
                (byte)stream.ReadByte(),
                (ushort)stream.ReadShort(),
                stream.ReadShort(),
                ZlibStream.UncompressBuffer(stream.ReadData(stream.ReadInt())));
        }

        private void Store_Chunk(int x, int z, byte GroundUp, ushort PrimBit, short AddBit, byte[] UncompressedChunkData)
        {
            int sectioncount = Convert.ToString(PrimBit, 2).ToCharArray().Count(a => a == '1');

            Chunk c;
            if (MapChunks.Chunks.TryGetValue(new Vector2(x, z), out c))
            {
                //c.SetChunk(bitmask, chunkdata, sectioncount);

            }
            else
            {
                c = new Chunk(x, z, sectioncount, (ushort)PrimBit, UncompressedChunkData);
                MapChunks.Chunks.TryAdd(new Vector2(x, z), c);
            }
        }
    }
}
