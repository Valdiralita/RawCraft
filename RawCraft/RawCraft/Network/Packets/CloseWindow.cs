using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class CloseWindow
    {
        public CloseWindow(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Close Window (0x65)");
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}
