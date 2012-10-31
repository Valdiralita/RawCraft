using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityMetadata
    {
        public EntityMetadata(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadMetaData();
        }
    }
}
