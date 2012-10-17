using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class OpenWindow
    {
        public OpenWindow(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Open Window (0x64)");
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream));
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}
