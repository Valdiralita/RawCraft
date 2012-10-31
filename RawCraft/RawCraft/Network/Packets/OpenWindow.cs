using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class OpenWindow
    {
        public OpenWindow(EnhancedStream stream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Open Window (0x64)");
            stream.ReadByte();
            stream.ReadByte();
            stream.ReadString(stream.ReadShort());
            stream.ReadByte();
        }
    }
}
