using RawCraft.Storage.Map;
using Microsoft.Xna.Framework;

namespace RawCraft.Network.Packets
{
    class BlockChange
    {
        int _x, _y, _z;
        byte _id, _meta;

        public BlockChange(EnhancedStream s)
        {
            _x = s.ReadInt();
            _y = s.ReadByte();
            _z = s.ReadInt();
            _id = (byte)s.ReadShort();
            _meta = (byte)s.ReadByte();

            UpdateChunk();
        }

        private void UpdateChunk()
        {
            int chunkx = _x < 0 ? ((_x + 1) / 16 - 1) : _x / 16;
            int chunkz = _z < 0 ? ((_x + 1) / 16 - 1) : _z / 16;

            Chunk c;

            if (MapChunks.Map.TryGetValue(new Vector2(chunkx, chunkz), out c))
            {
                int offsetX = _x < 0 ? 16 + (_x % 16 == 0 ? -16 : _x % 16) : _x % 16;
                int offsetZ = _z < 0 ? 16 + (_z % 16 == 0 ? -16 : _z % 16) : _z % 16;

                c.ChangeBlock(new Vector3(offsetX, _y, offsetZ), _id, _meta, false);
            }
        }
    }
}
