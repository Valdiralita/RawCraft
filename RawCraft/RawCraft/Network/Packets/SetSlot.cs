using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class SetSlot
    {
        public SetSlot(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Set Slot (0x67)");
            Reader.ReadSignedByte(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadSlot(AESStream);
        }
    }
}
