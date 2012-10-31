using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class RespawnPacket
    {
        public RespawnPacket(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadShort();
            s.ReadString(s.ReadShort());
        }
    }
}
