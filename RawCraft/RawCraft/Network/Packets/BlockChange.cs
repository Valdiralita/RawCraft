using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class BlockChange
    {
        public BlockChange(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
            s.ReadShort();
            s.ReadByte();
        }
    }
}
