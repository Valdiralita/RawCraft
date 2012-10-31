using System;
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
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Map Chunks (0x33)");

            Store_Chunk(stream.ReadInt(),
                stream.ReadInt(),
                (byte)stream.ReadByte(),
                stream.ReadShort(),
                stream.ReadShort(),
                ZlibStream.UncompressBuffer(stream.ReadData(stream.ReadInt())));
        }

        private void Store_Chunk(int ChunkX, int ChunkZ, byte GroundUp, short PrimBit, short AddBit, byte[] UncompressedChunkData)
        {
            Chunk c = new Chunk(ChunkX, ChunkZ, (ushort)PrimBit, UncompressedChunkData);

            MapChunks.Chunks.AddOrUpdate(new Vector2(ChunkX, ChunkZ), c,
            (key, existingVal) =>
            {
                return c;
            });
        }
    }
}
