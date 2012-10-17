using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class RespawnPacket
    {
        public RespawnPacket(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Respawn (0x09)");
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream));
        }
    }
}
