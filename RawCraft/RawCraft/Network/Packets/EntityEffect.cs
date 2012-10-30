using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityEffect
    {
        public EntityEffect(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Effect (0x29)");
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadShort(aesStream);
        }
    }
}
