using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class BlockAction
    {
        public BlockAction(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadShort();
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadShort();
        }
    }
}
