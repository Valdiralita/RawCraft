using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class Tabcomplete
    {
        public Tabcomplete(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Tab-complete (0xCB)"); 
            Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream));
        }
    }
}
