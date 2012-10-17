using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class TimeUpdate
    {
        public TimeUpdate(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Time Update (0x04)");
            Reader.ReadLong(AESStream);
        }
    }
}
