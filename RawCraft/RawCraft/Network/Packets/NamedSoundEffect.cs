using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class NamedSoundEffect
    {
        public NamedSoundEffect(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Named Sound Effect (0x3E)");
            Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream));
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadFloat(AESStream);
            Reader.ReadSignedByte(AESStream);
        }
    }
}
