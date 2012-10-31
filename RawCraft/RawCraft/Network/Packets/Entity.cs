using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Entity
    {
        public Entity(EnhancedStream s)
        {
            s.ReadInt();
        }
    }
}
