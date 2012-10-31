using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityEffect
    {
        public EntityEffect(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadShort();
        }
    }
}
