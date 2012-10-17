using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class ChatMessage
    {
        public ChatMessage(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Chat Message (0x03)");
            Storage.Misc.Log.Write(Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream)));
        }
    }
}
