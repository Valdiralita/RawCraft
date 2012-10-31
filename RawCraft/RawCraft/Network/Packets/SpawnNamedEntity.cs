using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnNamedEntity 
    {
        public SpawnNamedEntity(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Named Entity (0x14)");
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
