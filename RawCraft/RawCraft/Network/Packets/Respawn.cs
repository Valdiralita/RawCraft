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
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadString(aesStream, Reader.ReadShort(aesStream));
        }
    }
}
