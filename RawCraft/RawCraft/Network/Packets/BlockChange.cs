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

        private void UpdateChunk() // TODO: check and improve performance
        {
            int chunkx = x < 0 ? ((int)((x + 1) / 16) - 1) : (int)(x / 16);
            int chunkz = z < 0 ? ((int)((x + 1) / 16) - 1) : (int)(z / 16);

            Chunk c;

            if (MapChunks.Map.TryGetValue(new Vector2(chunkx, chunkz), out c))
            {
                int offsetX, offsetZ;

                offsetX = x < 0 ? 16 + (x % 16 == 0 ? -16 : x % 16) : x % 16;
                offsetZ = z < 0 ? 16 + (z % 16 == 0 ? -16 : z % 16) : z % 16;

                c.ChangeBlock(new Vector3(offsetX, y, offsetZ), id, meta, false);
            }
        }
    }
}
