using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class BlockAction
    {
        public BlockAction(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Block Action (0x36)");
            Reader.ReadInt(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadSignedShort(AESStream);
        }
    }
}
