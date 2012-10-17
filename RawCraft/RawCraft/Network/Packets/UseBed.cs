using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class UseBed
    {
        public UseBed(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Use Bed (0x11)");
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadInt(AESStream);
        }
    }
}
