using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityHeadLook
    {
        public EntityHeadLook(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Head Look (0x23)");
            s.ReadInt();
            s.ReadByte();
        }
    }
}
