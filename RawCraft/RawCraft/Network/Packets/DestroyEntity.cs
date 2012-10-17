using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class DestroyEntity
    {
        public DestroyEntity(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Destroy Entity (0x1D)");
            byte count = Reader.ReadUnsignedByte(AESStream);

            for (int i = 0; i < count; i++)
            {
                Reader.ReadInt(AESStream);
            }
        }
    }
}
