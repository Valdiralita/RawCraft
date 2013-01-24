using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RawCraft.Network.Packets
{
    class HeldItemChange
    {
        public HeldItemChange(EnhancedStream stream)
        {
            stream.ReadShort();
        }
    }
}
