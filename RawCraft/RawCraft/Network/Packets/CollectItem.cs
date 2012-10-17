using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class CollectItem
    {
        public CollectItem(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Collect Item (0x16)");
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
        }
    }
}
