using System;
using Ionic.Zlib;
using System.IO;

namespace RawCraft.Network.Packets
{
    class MapChunk
    {
        public MapChunk(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Map Chunks (0x33)");
            int chunkSize;
            Store_Chunk(Reader.ReadInt(aesStream), Reader.ReadInt(aesStream),
                Reader.ReadUnsignedByte(aesStream), Reader.ReadUnsignedShort(aesStream),
                Reader.ReadSignedShort(aesStream), chunkSize = Reader.ReadInt(aesStream),
                ZlibStream.UncompressBuffer(Reader.ReadData(aesStream, chunkSize)));
        }

        private void Store_Chunk(int ChunkX, int ChunkZ, byte GroundUp, ushort PrimBit, short AddBit, int Size, byte[] UncompressedChunkData)
        {
            throw new NotImplementedException("MapChunkPacket (0x33) is not implemented.");
            //if (GroundUp == 1)
            //{
            //    for (int i = 0; i <  MapChunks.Chunks.Count; i++)
            //    {
            //        if (MapChunks.Chunks[i].ChunkX == ChunkX)
            //            if (MapChunks.Chunks[i].ChunkZ == ChunkZ)
            //            {
            //                MapChunks.Chunks[i].Replace(UncompressedChunkData);
            //                break;
            //            }
            //    }
            //    MapChunks.Chunks.Add(new Chunk(ChunkX, ChunkZ, PrimBit, UncompressedChunkData));
            //}
            //else
            //{
            //    for (int i = 0; i < MapChunks.Chunks.Count; i++)
            //    {
            //        if (MapChunks.Chunks[i].ChunkX == ChunkX)
            //            if (MapChunks.Chunks[i].ChunkZ == ChunkZ)
            //            {
            //                MapChunks.Chunks[i].Replace(UncompressedChunkData);
            //                break;
            //            }
            //    }
            //    MapChunks.Chunks.Add(new Chunk(ChunkX, ChunkZ, PrimBit, UncompressedChunkData));
            //}

        }
    }
}
