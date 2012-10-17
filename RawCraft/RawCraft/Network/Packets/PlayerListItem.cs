using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class PlayerListItem
    {
        public PlayerListItem(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Player List Item (0xC9)"); 
            Storage.Misc.Log.Write("PlayerName: " + Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream)));
            Reader.ReadSignedByte(AESStream);
            Storage.Misc.Log.Write("Ping: " + Reader.ReadUnsignedShort(AESStream));
        }
    }
}
