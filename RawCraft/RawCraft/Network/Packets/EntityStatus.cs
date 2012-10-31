using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityStatus
    {
        public EntityStatus(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadByte();
        }
    }
}
