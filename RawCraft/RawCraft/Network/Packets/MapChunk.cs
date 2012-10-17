using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zlib;
using Storage;
using System.IO;
 
namespace Network.Packet
{
    class MapChunk
    {
        public MapChunk(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Map Chunks (0x33)");
            int ChunkSize;
            Store_Chunk(Reader.ReadInt(AESStream), Reader.ReadInt(AESStream), Reader.ReadUnsignedByte(AESStream), Reader.ReadUnsignedShort(AESStream), Reader.ReadSignedShort(AESStream), ChunkSize = Reader.ReadInt(AESStream), ZlibStream.UncompressBuffer(Reader.ReadData(AESStream, ChunkSize)));
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
