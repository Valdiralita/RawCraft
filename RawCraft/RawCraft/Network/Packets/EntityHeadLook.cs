using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityHeadLook
    {
        public EntityHeadLook(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadByte();
        }
    }
}
