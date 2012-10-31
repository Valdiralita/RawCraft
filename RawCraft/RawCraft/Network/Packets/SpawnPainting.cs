using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnPainting
    {
        public SpawnPainting(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadString(s.ReadShort());
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
        }
    }
}
