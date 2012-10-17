using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class Thunderbolt
    {
        public Thunderbolt(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Thunderbolt (0x47)");
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
        }
    }
}
