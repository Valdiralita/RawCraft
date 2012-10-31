using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ChatMessage
    {
        public ChatMessage(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Chat Message (0x03)");
            Storage.Misc.Log.Write(s.ReadString(s.ReadShort()));
        }
    }
}
