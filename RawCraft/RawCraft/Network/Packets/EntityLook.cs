using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityLook
    {
        public EntityLook(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Look (0x20)");
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
        }
    }
}
