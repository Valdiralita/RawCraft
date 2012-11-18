using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PlayerListItem
    {
        public PlayerListItem(EnhancedStream s)
        {
            s.ReadString();
            s.ReadByte();
            s.ReadShort();
        }
    }
}
