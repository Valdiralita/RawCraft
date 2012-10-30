using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityHeadLook
    {
        public EntityHeadLook(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Head Look (0x23)");
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
        }
    }
}
