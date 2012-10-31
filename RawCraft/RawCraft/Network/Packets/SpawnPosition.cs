using System;
using System.IO;
using RawCraft.Storage;

namespace RawCraft.Network.Packets
{
    class SpawnPosition
    {
        public SpawnPosition(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
        }
    }
}
