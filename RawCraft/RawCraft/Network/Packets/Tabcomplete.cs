using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class TabComplete
    {
        public TabComplete(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Tab-complete (0xCB)");
            s.ReadString(s.ReadShort());
        }
    }
}
