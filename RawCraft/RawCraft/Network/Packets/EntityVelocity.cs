using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityVelocity
    {
        public EntityVelocity(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Velocity (0x1C)");
            s.ReadInt();
            s.ReadShort();
            s.ReadShort();
            s.ReadShort();
        }
    }
}
