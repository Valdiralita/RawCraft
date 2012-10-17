using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class Animation
    {
        public Animation(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Animation (0x12)");
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}
