using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ChatMessage
    {
        public ChatMessage(EnhancedStream s)
        {
            s.ReadString(s.ReadShort());
        }
    }
}
