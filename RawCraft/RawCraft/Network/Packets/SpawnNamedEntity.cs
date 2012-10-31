using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnNamedEntity 
    {
        public SpawnNamedEntity(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadString(s.ReadShort());
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadShort();
            s.ReadMetaData();
        }
    }
}
