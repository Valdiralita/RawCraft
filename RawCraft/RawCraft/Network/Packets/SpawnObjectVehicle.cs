using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class SpawnObjectVehicle
    {
        public SpawnObjectVehicle(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Object/Vehicle (0x17)");
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            int ThrowerID = Reader.ReadInt(AESStream);
            if (ThrowerID != 0)
            {
                Reader.ReadSignedShort(AESStream);
                Reader.ReadSignedShort(AESStream);
                Reader.ReadSignedShort(AESStream);
            }
        }
    }
}
