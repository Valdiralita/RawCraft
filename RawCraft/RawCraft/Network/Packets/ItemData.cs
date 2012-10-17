using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class ItemData
    {
        public ItemData(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Item Data (0x83)"); 
            Reader.ReadSignedShort(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadData(AESStream, Reader.ReadUnsignedByte(AESStream));
        }
    }
}
