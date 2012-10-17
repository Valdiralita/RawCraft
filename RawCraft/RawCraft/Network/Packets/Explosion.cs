using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class Explosion
    {
        public Explosion(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Explosion (0x3C)");
            Reader.ReadDouble(AESStream);
            Reader.ReadDouble(AESStream);
            Reader.ReadDouble(AESStream);
            Reader.ReadFloat(AESStream);
            Reader.ReadData(AESStream, Reader.ReadInt(AESStream) * 3);
            Reader.ReadFloat(AESStream);
            Reader.ReadFloat(AESStream);
            Reader.ReadFloat(AESStream);
        }
    }
}
