using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class UpdateHealth
    {
        public UpdateHealth(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Health (0x08)");
            Reader.ReadSignedShort(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadFloat(AESStream);
        }
    }
}
