using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnMob
    {
        public SpawnMob(EnhancedStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Mob (0x18)");
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
            s.ReadShort();
            s.ReadShort();
            s.ReadShort();
            s.ReadMetaData();
        }
    }
}
