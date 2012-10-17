using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityTeleport
    {
        public EntityTeleport(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Teleport (0x22)");
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
        }
    }
}
