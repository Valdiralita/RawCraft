using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class SpawnNamedEntity 
    {
        public SpawnNamedEntity(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Named Entity (0x14)");
            Reader.ReadInt(AESStream);
            Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream));
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadMetaData(AESStream);
        }
    }
}
