using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class EntityVelocity
    {
        public EntityVelocity(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Velocity (0x1C)");
            Reader.ReadInt(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadSignedShort(AESStream);
        }
    }
}
