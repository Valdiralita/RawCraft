using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class BlockBreakAnimation
    {
        public BlockBreakAnimation(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Block Break Animation (0x37)");
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}
