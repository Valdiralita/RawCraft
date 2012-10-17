using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class MultiBlockChange
    {
        public MultiBlockChange(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Multi Block Change (0x34)");
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadData(AESStream, Reader.ReadInt(AESStream));
        }
    }
}
