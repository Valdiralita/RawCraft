using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class PlayerAbilities
    {
        public PlayerAbilities(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Player Abilities (0xCA)"); 
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}
