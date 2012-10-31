using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PluginMessage
    {
        public PluginMessage(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Plugin Message (0xFA)");
            Storage.Misc.Log.Write(s.ReadString(s.ReadShort()));
            s.ReadData(s.ReadShort());
        }
    }
}
