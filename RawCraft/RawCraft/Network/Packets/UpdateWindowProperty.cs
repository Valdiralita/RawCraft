using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class UpdateWindowProperty
    {
        public UpdateWindowProperty(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Window Property (0x69)");
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadSignedShort(AESStream);
        }
    }
}
