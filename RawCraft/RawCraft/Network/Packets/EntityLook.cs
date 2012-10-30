using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityLook
    {
        public EntityLook(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Look (0x20)");
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
        }
    }
}
