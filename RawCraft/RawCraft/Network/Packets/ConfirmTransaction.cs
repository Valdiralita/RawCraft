using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class ConfirmTransaction
    {
        public ConfirmTransaction(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Confirm Transaction (0x6A)"); 
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}
