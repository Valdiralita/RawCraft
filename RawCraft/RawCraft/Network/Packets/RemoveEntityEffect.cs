using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class RemoveEntityEffect
    {
        public RemoveEntityEffect(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadByte();
        }
    }
}
