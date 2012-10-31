using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PluginMessage
    {
        public PluginMessage(EnhancedStream s)
        {
            s.ReadString(s.ReadShort());
            s.ReadData(s.ReadShort());
        }
    }
}
