using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class TabComplete
    {
        public TabComplete(EnhancedStream s)
        {
            s.ReadString();
        }
    }
}
