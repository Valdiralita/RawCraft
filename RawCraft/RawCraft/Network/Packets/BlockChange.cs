using System;
using System.IO;
using RawCraft.Storage.Map;
using Microsoft.Xna.Framework;

namespace RawCraft.Network.Packets
{
    class BlockChange
    {
        int x, y, z;
        byte id, meta;

        public BlockChange(EnhancedStream s)
        {
            x = s.ReadInt();
            y = s.ReadByte();
            z = s.ReadInt();
            id = (byte)s.ReadShort();
            meta = (byte)s.ReadByte();

            UpdateChunk();
        }

        private void UpdateChunk()
        {
            Chunk c;
            int chunkx = (int)(x / 16 - Math.Sign(x) == -1 ? 1 : -1);
            int chunkz = (int)(z / 16 - Math.Sign(z) == -1 ? 1 : -1);

            // the following if check is wrong, sometimes we receive a block change for a chunk we didnt receive yet.
            // TODO: check and improve performance

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
