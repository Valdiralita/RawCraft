using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class AttachEntity
    {
        public AttachEntity(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Attach Entity (0x27)");
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
        }
    }
}
