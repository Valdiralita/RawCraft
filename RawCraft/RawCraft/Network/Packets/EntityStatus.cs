using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityStatus
    {
        public EntityStatus(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Status (0x26)");
            s.ReadInt();
            s.ReadByte();
        }
    }
}
