using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class EntityEquipment
    {

        public EntityEquipment(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Equipment (0x05)");
            Reader.ReadInt(AESStream);
            Reader.ReadSignedShort(AESStream);

            Reader.ReadSlot(AESStream);
        }
    }
}
