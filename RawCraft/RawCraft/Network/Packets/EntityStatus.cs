using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class EntityStatus
    {
        public EntityStatus(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Status (0x26)");
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}
