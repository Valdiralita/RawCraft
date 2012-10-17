using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class SetExperience
    {
        public SetExperience(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Set Experience (0x2B)");
            Reader.ReadFloat(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadSignedShort(AESStream);
        }
    }
}
