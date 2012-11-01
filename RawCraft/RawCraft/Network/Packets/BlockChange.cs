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

            if (MapChunks.Chunks.TryGetValue(new Vector2((int)(x / 16), (int)(z / 16)), out c))
                c.ChangeBlock(new Vector3(x % 16, y, z % 16), id, meta);
        }
    }
}
