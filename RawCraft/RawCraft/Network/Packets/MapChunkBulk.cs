using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Storage;
using Ionic.Zlib;
using Microsoft.Xna.Framework;
using System.IO;

namespace Network.Packet
{
    class MapChunkBulk
    {
        int count;
        byte[] CompressedChunks, MetaData;

        public MapChunkBulk(Stream Stream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Map Chunk Bulk (0x38)");
            count = (int)Reader.ReadUnsignedShort(Stream);
            CompressedChunks = Reader.ReadData(Stream, Reader.ReadInt(Stream));
            MetaData = Reader.ReadData(Stream, count * 12);
            StoreChunks(ZlibStream.UncompressBuffer(CompressedChunks));
        }

        private void StoreChunks(byte[] uncompressed)
        {
            int proceededSections = 0;
            int chunkcount = 0;
            for (int i = 0; i < count; i++)
            {
                int x = 0;
                x += MetaData[i * 12 + 0];
                x <<= 8;
                x += MetaData[i * 12 + 1];
                x <<= 8;
                x += MetaData[i * 12 + 2];
                x <<= 8;
                x += MetaData[i * 12 + 3];

                int z = 0;
                z += MetaData[i * 12 + 4];
                z <<= 8;
                z += MetaData[i * 12 + 5];
                z <<= 8;
                z += MetaData[i * 12 + 6];
                z <<= 8;
                z += MetaData[i * 12 + 7];


                int sectioncount = 0;
                ushort bitmask = BitConverter.ToUInt16(MetaData.Skip(i * 12 + 8).Take(2).Reverse().ToArray(), 0);
                for (int j = 0; j < 15; j++)
                {
                    if ((bitmask & (0x01 << j)) == 0x01 << j)
                        sectioncount++;
                }

                byte[] chunkdata = uncompressed.Skip(proceededSections * 10240 + chunkcount * 256).Take(10240 * sectioncount + 256).ToArray();
                proceededSections += sectioncount;
                chunkcount++;

                MapChunks.Chunks.TryAdd(new Vector2(x,z), new Chunk(x, z, bitmask, chunkdata));
            }
        }
    }
}
