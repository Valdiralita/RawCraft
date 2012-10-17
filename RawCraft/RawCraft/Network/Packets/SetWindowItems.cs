using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class SetWindowItems
    {
        public SetWindowItems(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Set Window Items (0x68)");
            Reader.ReadSignedByte(AESStream);
            int Slots = Reader.ReadSignedShort(AESStream);

            for (int i = 0; i < Slots; i++)
            {
                Reader.ReadSlot(AESStream);
            }
        }
    }
}
