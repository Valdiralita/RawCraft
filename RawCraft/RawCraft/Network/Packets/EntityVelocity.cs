using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityVelocity
    {
        public EntityVelocity(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Velocity (0x1C)");
            Reader.ReadInt(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadShort(aesStream);
        }
    }
}
