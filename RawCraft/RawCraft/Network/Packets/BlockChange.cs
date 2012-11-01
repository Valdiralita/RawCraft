using System;
using System.IO;
using RawCraft.Storage.Map;
using Microsoft.Xna.Framework;

namespace RawCraft.Network.Packets
{
    class BlockChange
    {
        public BlockChange(EnhancedStream s)
        {
            int x = s.ReadInt();
            int y = s.ReadByte();
            int z = s.ReadInt();
            byte id = (byte)s.ReadShort();
            byte meta = (byte)s.ReadByte();

            Chunk c;

            // the following if check is wrong, sometimes we receive a block change for a chunk we didnt receive yet.
            // TODO: check and improve performance

            int chunkx = (int)(x / 16 - Math.Sign(x) == -1 ? 1 : -1);
            int chunkz = (int)(z / 16 - Math.Sign(z) == -1 ? 1 : -1);

            if (MapChunks.Chunks.TryGetValue(new Vector2(chunkx, chunkz), out c))
            {
                int offsetX, offsetZ;

                offsetX = x < 0 ? 16 + (x % 16 == 0 ? -16 : x % 16) : x % 16;
                offsetZ = z < 0 ? 16 + (z % 16 == 0 ? -16 : z % 16) : z % 16;


                c.ChangeBlock(new Vector3(offsetX, y, offsetZ), id, meta);
            }
        }
    }
}
