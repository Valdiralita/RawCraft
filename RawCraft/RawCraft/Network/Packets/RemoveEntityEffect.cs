using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class RemoveEntityEffect
    {
        public RemoveEntityEffect(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Remove Entity Effect (0x2A)");
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}
