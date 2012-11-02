﻿using System;
using System.Linq;
using RawCraft.Storage;
using RawCraft.Storage.Map;
using Ionic.Zlib;
using Microsoft.Xna.Framework;
using System.IO;
using RawCraft.Network.Encryption;

namespace RawCraft.Network.Packets
{
    class MapChunkBulk
    {
        int count;
        byte[] compressedChunks, metaData;

        public MapChunkBulk(EnhancedStream stream)
        {
            count = stream.ReadShort();
            compressedChunks = stream.ReadData(stream.ReadInt());
            metaData = stream.ReadData(count * 12);
            StoreChunks(ZlibStream.UncompressBuffer(compressedChunks));
        }

        private void StoreChunks(byte[] uncompressed) //todo: better!
        {
            int proceededSections = 0;
            int chunkcount = 0;
            for (int i = 0; i < count; i++)
            {
                int x, z, sectioncount;
                ushort bitmask;
                byte[] chunkdata;

                x = BitConverter.ToInt32(metaData.Skip(i * 12).Take(4).Reverse().ToArray(), 0);
                z = BitConverter.ToInt32(metaData.Skip(i * 12 + 4).Take(4).Reverse().ToArray(), 0);
                bitmask = BitConverter.ToUInt16(metaData.Skip(i * 12 + 8).Take(2).Reverse().ToArray(), 0);
                sectioncount = Convert.ToString(bitmask, 2).ToCharArray().Count(a => a == '1');
                chunkdata = uncompressed.Skip(proceededSections * 10240 + chunkcount * 256).Take(10240 * sectioncount + 256).ToArray();
                proceededSections += sectioncount;
                chunkcount++;

                Chunk c;
                if (MapChunks.Chunks.TryGetValue(new Vector2(x, z), out c))
                {
                    //c.SetChunk(bitmask, chunkdata, sectioncount);
                    //TODO: implement correct way to change chunk sections
                }
                else
                {
                    c = new Chunk(x, z, sectioncount, bitmask, chunkdata);
                    MapChunks.Chunks.TryAdd(new Vector2(x, z), c);
                }
            }
        }
    }
}
