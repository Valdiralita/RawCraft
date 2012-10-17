using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class BlockChange
    {
        public BlockChange(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Block Change (0x35)");
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedShort(AESStream);
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}
