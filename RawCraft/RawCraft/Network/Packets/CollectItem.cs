using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class CollectItem
    {
        public CollectItem(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadInt();
        }
    }
}
