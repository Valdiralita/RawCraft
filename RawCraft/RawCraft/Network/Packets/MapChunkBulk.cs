using System;
using System.Linq;
using RawCraft.Storage.Map;
using Ionic.Zlib;
using Microsoft.Xna.Framework;

namespace RawCraft.Network.Packets
{
    class MapChunkBulk
    {
        int _chunkCount;
        byte[] _compressedChunks, _metaData;

        public MapChunkBulk(EnhancedStream stream)
        {
            _chunkCount = stream.ReadShort();
            int datasize = stream.ReadInt();
            stream.readBool();                  //TODO: implement a check if light nibble array was sent (make nether and end work)
            _compressedChunks = stream.ReadData(datasize);
            _metaData = stream.ReadData(_chunkCount * 12);
            StoreChunks(ZlibStream.UncompressBuffer(_compressedChunks));
        }

        private void StoreChunks(byte[] uncompressed) //todo: better!
        {
            int proceededSections = 0;
            int chunkcount = 0;
            for (int i = 0; i < _chunkCount; i++)
            {
                int x = BitConverter.ToInt32(_metaData.Skip(i * 12).Take(4).Reverse().ToArray(), 0);
                int z = BitConverter.ToInt32(_metaData.Skip(i * 12 + 4).Take(4).Reverse().ToArray(), 0);
                ushort bitmask = BitConverter.ToUInt16(_metaData.Skip(i * 12 + 8).Take(2).Reverse().ToArray(), 0);
                int sectioncount = Convert.ToString(bitmask, 2).ToCharArray().Count(a => a == '1');
                byte[] chunkdata = uncompressed.Skip(proceededSections * 10240 + chunkcount * 256).Take(10240 * sectioncount + 256).ToArray();
                proceededSections += sectioncount;
                chunkcount++;

                Chunk c;
                if (MapChunks.Map.TryGetValue(new Vector2(x, z), out c))
                {
                    //c.SetChunk(bitmask, chunkdata, sectioncount);
                    //TODO: implement correct way to change chunk sections
                }
                else
                {
                    c = new Chunk(x, z, sectioncount, bitmask, chunkdata);
                    MapChunks.Map.TryAdd(new Vector2(x, z), c);
                }
            }
        }
    }
}
