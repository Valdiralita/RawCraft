using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityTeleport
    {
        public EntityTeleport(EnhancedStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Teleport (0x22)");
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
        }
    }
}
