using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class UpdateSign
    {
        public UpdateSign(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Sign (0x82)"); 
            Reader.ReadInt(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream));
            Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream));
            Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream));
            Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream));
        }
    }
}
