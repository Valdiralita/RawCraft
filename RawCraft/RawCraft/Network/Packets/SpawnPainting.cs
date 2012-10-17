using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class SpawnPainting
    {
        public SpawnPainting(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Painting (0x19)");
            Reader.ReadInt(AESStream);
            Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream));
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
        }
    }
}
