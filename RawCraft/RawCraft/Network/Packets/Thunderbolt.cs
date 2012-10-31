using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Thunderbolt
    {
        public Thunderbolt(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
        }
    }
}
