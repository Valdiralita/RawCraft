using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UseBed
    {
        public UseBed(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
        }
    }
}
