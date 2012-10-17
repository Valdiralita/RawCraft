using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class CreativeInventoryAction
    {
        public CreativeInventoryAction(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Creative Inventory Action (0x6B)");
            Reader.ReadSignedShort(AESStream);
            Reader.ReadSlot(AESStream);
        }
    }
}
