using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class CloseWindow
    {
        public CloseWindow(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Close Window (0x65)");
            s.ReadByte();
        }
    }
}
