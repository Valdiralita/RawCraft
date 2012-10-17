using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class EntityLookRelativeMove
    {
        public EntityLookRelativeMove(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Look and Relative Move (0x21)");
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}
