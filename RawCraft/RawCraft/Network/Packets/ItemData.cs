using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ItemData
    {
        public ItemData(EnhancedStream s)
        {
            s.ReadShort();
            s.ReadShort();
            s.ReadData(s.ReadShort());
        }
    }
}
