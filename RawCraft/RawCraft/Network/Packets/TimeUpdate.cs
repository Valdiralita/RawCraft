using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class TimeUpdate
    {
        public TimeUpdate(EnhancedStream s)
        {
            s.ReadLong();
            s.ReadLong();
        }
    }
}
