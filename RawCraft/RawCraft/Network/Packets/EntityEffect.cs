using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityEffect
    {
        public EntityEffect(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Effect (0x29)");
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadShort();
        }
    }
}
