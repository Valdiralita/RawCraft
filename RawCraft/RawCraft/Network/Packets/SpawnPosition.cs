using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Storage;
using System.IO;

namespace Network.Packet
{
    class SpawnPosition
    {
        public SpawnPosition(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Position (0x06) (see compass)");
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);


        }
    }
}
