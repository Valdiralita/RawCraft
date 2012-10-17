using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class EntityMetadata
    {
        public EntityMetadata(Stream AESStream) 
        {
            Reader.ReadInt(AESStream);
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Metadata (0x28)");
            Reader.ReadMetaData(AESStream);
        }
    }
}
