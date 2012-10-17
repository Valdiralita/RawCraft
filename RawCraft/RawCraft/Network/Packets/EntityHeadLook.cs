using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class EntityHeadLook
    {
        public EntityHeadLook(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Head Look (0x23)");
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}
