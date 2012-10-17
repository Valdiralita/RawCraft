using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class PluginMessage
    {
        public PluginMessage(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Plugin Message (0xFA)"); 
            Storage.Misc.Log.Write(Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream)));
            Reader.ReadData(AESStream, Reader.ReadSignedShort(AESStream));
        }
    }
}
