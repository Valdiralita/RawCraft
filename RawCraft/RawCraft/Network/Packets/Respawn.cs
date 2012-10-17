using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class RespawnPacket
    {
        public RespawnPacket(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Respawn (0x09)");
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadSignedShort(aesStream);
            Reader.ReadString(aesStream, Reader.ReadSignedShort(aesStream));
        }
    }
}
