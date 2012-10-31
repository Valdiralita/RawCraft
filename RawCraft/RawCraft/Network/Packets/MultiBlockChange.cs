using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class MultiBlockChange
    {
        public MultiBlockChange(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadInt();
            s.ReadShort();
            s.ReadData(s.ReadInt());
        }
    }
}
