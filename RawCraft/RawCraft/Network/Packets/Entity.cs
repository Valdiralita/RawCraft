using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class Entity
    {
        public Entity(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity (0x1E)");
            Reader.ReadInt(AESStream);
        }
    }
}
