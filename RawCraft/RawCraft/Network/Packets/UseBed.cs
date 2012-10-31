using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UseBed
    {
        public UseBed(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Use Bed (0x11)");
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
        }
    }
}
